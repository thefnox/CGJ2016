using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Prime31.TransitionKit;

public class ShoesPolishView : View {

    public MeshRenderer PaintRenderer;

    public float Percent = 0f;

    public bool Done = false;

    private Texture2D tex;

    public Text TextDisplay;

    public override void FireKeyHeld()
    {
        if (Done) return;
        foreach (var hit in Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition), 100f))
        {
            if (hit.collider.GetComponent<MeshRenderer>() != null)
            {
                var uv = new Vector2(hit.textureCoord.x * tex.width, hit.textureCoord.y * tex.height);
                tex.SetPixel(Mathf.RoundToInt(uv.x), Mathf.RoundToInt(uv.y), Color.black);
                tex.Apply();
                hit.collider.GetComponent<MeshRenderer>().material.SetTexture("_SliceGuide", tex);
            }
        }
    }

    public void TransitionToNextView()
    {
        var wind = new WindTransition()
        {
            nextScene = SceneManager.GetActiveScene().buildIndex + 1,
            duration = 0.2f,
            size = 0.4f
        };
        GameController.StepCount++;
        TransitionKit.instance.transitionWithDelegate(wind);
    }

    public override void Initialize()
    {
        tex = new Texture2D(16, 16);
        PaintRenderer.material.SetTexture("_SliceGuide", tex);
        for (var y = 0; y < tex.height; ++y) 
	    {
            for (var x = 0; x < tex.width; ++x) 
		    {
                tex.SetPixel(x, y, Color.white);
            }
        }
        tex.Apply();
        StartCoroutine(PolishWorker());
    }

    public IEnumerator PolishWorker()
    {
        while (Percent < 0.75f)
        {
            TextDisplay.text = "<color=red>" + Mathf.Floor((0.75f - Percent) * 100f) + "%</color> left to polish!";
            yield return null;
        }
        TextDisplay.text = "Good job!";
        Done = true;
        TransitionToNextView();
    }

    // Update is called once per frame
    void Update () {
        if (tex != null)
        {
            Percent = 0f;
            for (var y = 0; y < tex.height; ++y)
            {
                for (var x = 0; x < tex.width; ++x)
                {
                    if (tex.GetPixel(x, y) != Color.white) Percent += (1f /( (float) tex.height *  (float) tex.width));
                }
            }
            if (!Done) GameController.CurrentTime += Time.deltaTime;
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Prime31.TransitionKit;

public class MainMenuView : View {

    public bool Transitioned = false;

    public GameObject FireText;

    public override void FireKeyPressed()
    {
        if (Transitioned) return;
        TransitionToNextView();
        Transitioned = true;
    }

    public override void Initialize()
    {
        StartCoroutine(MainMenuWorker());
    }

    public IEnumerator MainMenuWorker()
    {
        yield return new WaitForSeconds(1f);
        FireText.SetActive(true);
    }

    // Use this for initialization
    void TransitionToNextView()
    {
        var fade = new FadeTransition()
        {
            nextScene = SceneManager.GetActiveScene().buildIndex + 1,
            duration = 0.4f,
            fadeToColor = Color.black
        };
        TransitionKit.instance.transitionWithDelegate(fade);
    }
}

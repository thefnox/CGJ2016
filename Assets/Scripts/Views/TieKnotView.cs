using UnityEngine;
using System.Collections;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;

public class TieKnotView : View {

    public string[] ValidKnots;

    public GameObject Tutorial;

    public string Inputs;

    public SpriteRenderer Tie;

    public Transform[] Positions;

    public Sprite[] TieSprites1;

    public Sprite[] TieSprites2;

    public Sprite[] TieSprites3;

    public bool Started = false;

    public bool Completed = false;

    public int TotalSteps = 6;

    public int Step = 0;

    public override void DownKeyPressed()
    {
        if (Step >= TotalSteps || !Started) return;
        var found = false;
        Inputs += 'D';
        foreach (string knot in ValidKnots)
            found = found || knot.Substring(0, Step + 1) == Inputs;

        if (found) AdvanceStep();
        else ResetStep();
    }

    public override void UpKeyPressed()
    {
        if (Step >= TotalSteps || !Started) return;
        var found = false;
        Inputs += 'U';
        foreach (string knot in ValidKnots)
            found = found || knot.Substring(0, Step + 1) == Inputs;

        if (found) AdvanceStep();
        else ResetStep();
    }

    public override void LeftKeyPressed()
    {
        if (Step >= TotalSteps || !Started) return;
        var found = false;
        Inputs += 'L';
        foreach (string knot in ValidKnots)
            found = found || knot.Substring(0, Step + 1) == Inputs;

        if (found) AdvanceStep();
        else ResetStep();
    }

    public override void RightKeyPressed()
    {
        if (Step >= TotalSteps || !Started) return;
        var found = false;
        Inputs += 'R';
        foreach (string knot in ValidKnots)
            found = found || knot.Substring(0, Step + 1) == Inputs;

        if (found) AdvanceStep();
        else ResetStep();
    }

    public override void FireKeyPressed()
    {
        if (!Started)
        {
            Started = true;
            Tutorial.SetActive(false);
        }
    }

    public void SetTieSprite()
    {
        if (Step < TotalSteps)
        {
            switch (GameController.GetAnswer(TieSelectView.ViewAnswer))
            {
                case 0:
                    Tie.sprite = TieSprites1[Step];
                    break;
                case 1:
                    Tie.sprite = TieSprites1[Step];
                    break;
                case 2:
                    Tie.sprite = TieSprites1[Step];
                    break;
            }
            Tie.transform.position = Positions[Step].position;
        }
    }

    public void ResetStep()
    {
        Step = 0;
        Inputs = "";
        SetTieSprite();
    }

    public void AdvanceStep()
    {
        Step++;
        SetTieSprite();
    }

    // Use this for initialization
    public override void Initialize()
    {
        StartCoroutine(KnotWorker());
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

    public IEnumerator KnotWorker()
    {
        while (Step < TotalSteps)
            yield return null;
        TransitionToNextView();
    }

    // Update is called once per frame
    void Update () {
	    if (Started && !Completed ) GameController.CurrentTime += Time.deltaTime;
    }
}

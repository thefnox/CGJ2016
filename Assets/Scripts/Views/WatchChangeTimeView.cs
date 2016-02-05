using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Prime31.TransitionKit;
using UnityEngine.UI;

public class WatchChangeTimeView : View {

    public static int ViewAnswer = 2;

    public Text HourText;

    public int Hours = 23;

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void DownKeyPressed()
    {
        Hours--;
        if (Hours < 0) Hours = 23;
        HourText.text = "" + (Hours < 10 ? "0" + Hours : "" + Hours);
    }

    public override void UpKeyPressed()
    {
        Hours++;
        if (Hours > 23) Hours = 0;
        HourText.text = "" + (Hours < 10 ? "0" + Hours: "" + Hours);
    }

    public override void FireKeyPressed()
    {
        TransitionToNextView();
    }
    public void TransitionToNextView()
    {
        var wind = new WindTransition()
        {
            nextScene = SceneManager.GetActiveScene().buildIndex + 1,
            duration = 0.2f,
            size = 0.4f
        };
        var diff = (Hours > 12 ? Hours - 23 : Hours);
        GameController.SetAnswer(ViewAnswer, diff);
        GameController.StepCount++;
        TransitionKit.instance.transitionWithDelegate(wind);
    }

    // Update is called once per frame
    void Update () {
        GameController.CurrentTime += Time.deltaTime;
    }
}

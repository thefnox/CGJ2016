using UnityEngine;
using UnityEngine.UI;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoseView : View {

    public bool Pressed = false;

    public Text LoseReason;

    public override void Initialize()
    {
        if (!GameController.CheckAnswers())
        {
            LoseReason.text = "You didn't get what you needed for the mission!";
        }
        else if (GameController.CurrentTime > GameController.MaxTime)
        {
            LoseReason.text = "You ran out of time!";
        }
    }

    public override void FireKeyPressed()
    {
        if (!Pressed)
        {
            Pressed = true;
            TransitionToNextView();
        }
    }

    void TransitionToNextView()
    {
        var fade = new FadeTransition()
        {
            nextScene = 7,
            duration = 0.4f,
            fadeToColor = Color.black
        };
        TransitionKit.instance.transitionWithDelegate(fade);
    }


}

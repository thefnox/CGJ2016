using UnityEngine;
using System.Collections;
using Prime31.TransitionKit;

public class WinView : View {
    public bool Pressed = false;

    public override void Initialize()
    {
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

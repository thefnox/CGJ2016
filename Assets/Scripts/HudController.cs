using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HudController : MonoBehaviour {
    public Text StepText;
    public Text Countdown;
    public Text Milliseconds;

    public void Update()
    {
        StepText.text = "Step " + GameController.StepCount + "/" + GameController.StepTotal;
        var TimeLeft = Mathf.Clamp(GameController.MaxTime - GameController.CurrentTime, 0f, GameController.MaxTime);
        var mil = TimeLeft - Mathf.Floor(TimeLeft);
        Countdown.text = "" + Mathf.Floor(TimeLeft) + ".";
        Milliseconds.text = "" + Mathf.Floor(mil * 100f);
    }
}

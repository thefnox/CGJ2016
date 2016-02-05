using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;

public class MissionView : View {

    public Text BulletsText;

    public Text WatchText;

    public Text HourText;

    public Text TieText;

    public Text ShoesText;

    public Text CarText;

    public override void Initialize()
    {
        GameController.StartGame();
        SetTexts();
        StartCoroutine(MissionWorker());
    }

    public IEnumerator MissionWorker()
    {
        yield return new WaitForSeconds(7.5f);
        TransitionToNextView();
    }

    public void SetTexts()
    {
        switch (GameController.CorrectAnswers[0])
        {
            case 0:
                BulletsText.text = "* <color=blue>Bouncing </color> bullets, ";
                break;
            case 1:
                BulletsText.text = "* <color=red>Top Bull </color> bullets, ";
                break;
            case 2:
                BulletsText.text = "* <color=yellow>Explosive </color> bullets, ";
                break;
        }

        switch (GameController.CorrectAnswers[1])
        {
            case 0:
                WatchText.text = "* Circle laser watch, ";
                break;
            case 1:
                WatchText.text = "* Square digital watch, ";
                break;
            case 2:
                WatchText.text = "* Rectangular Datawatch64, ";
                break;
        }

        if (GameController.CorrectAnswers[2] == 0)
        {
            HourText.text = "* <color=red>Don't</color> change the hour on your watch,";
        }
        else if (GameController.CorrectAnswers[2] > 0)
            HourText.text = "* Set your watch <color=blue>ahead</color> by " + GameController.CorrectAnswers[2] + " hours,";
        else if (GameController.CorrectAnswers[2] < 0)
            HourText.text = "* Set your watch <color=red>back</color> by " + Mathf.Abs(GameController.CorrectAnswers[2]) + " hours,";

        switch (GameController.CorrectAnswers[3])
        {
            case 0:
                ShoesText.text = "* Sticky <color=red>wall climbing</color> shoes,";
                break;
            case 1:
                ShoesText.text = "* <color=blue>Jet pack</color> shoes,";
                break;
            case 2:
                ShoesText.text = "* <color=grey>Chainsaw</color> shoes,";
                break;
        }

        switch (GameController.CorrectAnswers[4])
        {
            case 0:
                TieText.text = "* <color=grey>Sword</color> tie,";
                break;
            case 1:
                TieText.text = "* <color=red>Flame thrower</color> tie,";
                break;
            case 2:
                TieText.text = "* <color=black>Bulletproof</color> tie,";
                break;
        }

        switch (GameController.CorrectAnswers[5])
        {
            case 0:
                CarText.text = "* <color=grey>Aston Martin</color>,";
                break;
            case 1:
                CarText.text = "* <color=yellow>Corsa Sedan</color>,";
                break;
            case 2:
                CarText.text = "* <color=red>Lamborghini</color>,";
                break;
        }
    }

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

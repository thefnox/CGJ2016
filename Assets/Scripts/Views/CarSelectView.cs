using UnityEngine;
using System.Collections;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarSelectView : View{
    public int CurrentSelection = 0;

    public static int ViewAnswer = 5;

    public SpriteRenderer Car;

    public Text CarName;

    public Sprite[] Cars;

    public string[] CarNames;

    public Transform[] ArrowPositions;

    public override void RightKeyPressed()
    {
        CurrentSelection++;
        if (CurrentSelection > 2) CurrentSelection = 0;
        Car.sprite = Cars[CurrentSelection];
        CarName.text = CarNames[CurrentSelection];
    }

    public override void LeftKeyPressed()
    {
        CurrentSelection--;
        if (CurrentSelection < 0) CurrentSelection = 2;
        Car.sprite = Cars[CurrentSelection];
        CarName.text = CarNames[CurrentSelection];
    }

    public override void FireKeyPressed()
    {
        TransitionToNextView();
    }

    public void Update()
    {
        GameController.CurrentTime += Time.deltaTime;
    }

    public void TransitionToNextView()
    {
        GameController.SetAnswer(ViewAnswer, CurrentSelection);
        var scene = 20;

        if (GameController.CurrentTime >= GameController.MaxTime || GameController.CheckAnswers())
        {
            scene = 21;
        }
        var wind = new WindTransition()
        {
            nextScene = scene,
            duration = 0.2f,
            size = 0.4f
        };
        TransitionKit.instance.transitionWithDelegate(wind);
    }
}

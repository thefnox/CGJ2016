using UnityEngine;
using System.Collections;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;

public class ShoesSelectView : View {

    public int CurrentSelection = 0;

    public static int ViewAnswer = 3;

    public GameObject Arrow;

    public Transform[] ArrowPositions;

    public override void RightKeyPressed()
    {
        CurrentSelection++;
        if (CurrentSelection > 2) CurrentSelection = 0;
        Arrow.transform.position = ArrowPositions[CurrentSelection].position;
    }

    public override void LeftKeyPressed()
    {
        CurrentSelection--;
        if (CurrentSelection < 0) CurrentSelection = 2;
        Arrow.transform.position = ArrowPositions[CurrentSelection].position;
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
        var wind = new WindTransition()
        {
            nextScene = SceneManager.GetActiveScene().buildIndex + 1,
            duration = 0.2f,
            size = 0.4f
        };
        TransitionKit.instance.transitionWithDelegate(wind);
    }

}

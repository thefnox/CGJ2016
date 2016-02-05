using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Prime31.TransitionKit;

public class OhgodIntroView : View {

    public bool Skip = false;

    public override void Initialize()
    {
        StartCoroutine(IntroWorker());
    }

    public override void FireKeyPressed()
    {
        Skip = true;
    }

    public void TransitionToNextView()
    {
        GameController.StartGame();
        var fade = new FadeTransition()
        {
            nextScene = SceneManager.GetActiveScene().buildIndex + 1,
            duration = 0.4f,
            fadeToColor = Color.black
        };
        TransitionKit.instance.transitionWithDelegate(fade);
    }

    public IEnumerator IntroWorker()
    {
        var timer = 1f;
        while ((timer -= Time.deltaTime) > 0 && !Skip) yield return null;
        TransitionToNextView();
    }
}

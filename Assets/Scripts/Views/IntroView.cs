using UnityEngine;
using System.Collections;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;

public class IntroView : View {

    public float WaitSeconds = 3f;

    public override void Initialize()
    {
        StartCoroutine(IntroWorker());
    }

    public IEnumerator IntroWorker()
    {
        yield return new WaitForSeconds(3f);
        var fader = new FadeTransition()
        {
            nextScene = SceneManager.GetActiveScene().buildIndex + 1,
            fadedDelay = 0.2f,
            fadeToColor = Color.black
        };
        TransitionKit.instance.transitionWithDelegate(fader);
    }

}

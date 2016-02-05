using UnityEngine;
using System.Collections;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;

public class BreakfastTransitionView : View {

    public override void Initialize()
    {
        StartCoroutine(TransitionWorker());
    }

    public void TransitionToNextScene()
    {
        var wind = new WindTransition()
        {
            nextScene = SceneManager.GetActiveScene().buildIndex + 1,
            duration = 0.2f,
            size = 0.4f
        };
        TransitionKit.instance.transitionWithDelegate(wind);
    }

    private IEnumerator TransitionWorker()
    {
        yield return new WaitForSeconds(1f);
        TransitionToNextScene();
    }

    // Update is called once per frame
    void Update () {
        GameController.CurrentTime += Time.deltaTime;
    }
}

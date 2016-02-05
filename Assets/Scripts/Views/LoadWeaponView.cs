using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Prime31.TransitionKit;

public class LoadWeaponView : View {

    public int Step = 0;

    public int TotalBullets = 8;

    public int BulletsLoaded = 0;

    public Sprite Answer1Box;

    public Sprite Answer2Box;

    public Sprite Answer3Box;

    public SpriteRenderer BulletBox;

    public string Step1Text = "Lift the bullet <color=red>UP!</color>";

    public string Step2Text = "Push it <color=red>RIGHT</color> to the clip!";

    public string Step3Text = "Put it <color=red>DOWN</color> into it!";

    public string Step4Text = "<color=red>FIRE</color> to secure it in!";

    public Text StepText;

    public GameObject BulletPrefab;

    public GameObject CurrentBullet;

    public Transform LoadPosition;

    public Transform FetchPosition;

    public Transform[] RoundPosition;

    public void NextStep()
    {
        StartCoroutine(StepWorker());
    }

    private IEnumerator StepWorker()
    {
        yield return null;
        Step++;
        if (Step > 3)
        {
            Step = 0;
            BulletsLoaded++;
        }
        RenderStep();
    }

    public override void Initialize()
    {
        switch (GameController.GetAnswer(LoadWeaponSelectView.ViewAnswer))
        {
            case 0:
                BulletBox.sprite = Answer1Box;
                break;
            case 1:
                BulletBox.sprite = Answer2Box;
                break;
            case 2:
                BulletBox.sprite = Answer3Box;
                break;
            default:
                break;
        }
        StartCoroutine(GameRoutine());
    }

    public void TransitionToNextView()
    {
        var wind = new WindTransition()
        {
            nextScene = SceneManager.GetActiveScene().buildIndex + 1,
            duration = 0.2f,
            size = 0.4f
        };
        TransitionKit.instance.transitionWithDelegate(wind);
        GameController.StepCount++;
    }

    public void RenderStep()
    {
        switch (Step)
        {
            case 0:
                StepText.text = Step1Text;
                if (CurrentBullet != null && BulletsLoaded < TotalBullets)
                {
                    CurrentBullet.transform.rotation = RoundPosition[BulletsLoaded].rotation;
                    CurrentBullet = null;
                }
                break;
            case 1:
                StepText.text = Step2Text;
                CurrentBullet = (GameObject)Instantiate(BulletPrefab, FetchPosition.position, FetchPosition.rotation);
                break;
            case 2:
                StepText.text = Step3Text;
                CurrentBullet.transform.position = LoadPosition.position;
                CurrentBullet.transform.rotation = LoadPosition.rotation;
                break;
            case 3:
                StepText.text = Step4Text;
                CurrentBullet.transform.position = RoundPosition[BulletsLoaded].position;
                CurrentBullet.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -15f));
                break;
            case 4:
                CurrentBullet.transform.rotation = RoundPosition[BulletsLoaded].rotation;
                break;
            case -1:
                break;
        }
    }

    public IEnumerator GameRoutine()
    {
        RenderStep();
        while (BulletsLoaded < TotalBullets)
        {
            GameController.CurrentTime += Time.deltaTime;
            yield return null;
        }
        CurrentBullet.transform.rotation = RoundPosition[BulletsLoaded - 1].rotation;
        Step = -1;
        StepText.text = "Good job!";
        TransitionToNextView();
    }

    public override void UpKeyPressed()
    {
        if (Step == 0) NextStep();
    }

    public override void RightKeyPressed()
    {
        if (Step == 1) NextStep();
    }
    
    public override void DownKeyPressed()
    {
        if (Step == 2) NextStep();
    }

    public override void FireKeyPressed()
    {
        if (Step == 3) NextStep();
    }
}

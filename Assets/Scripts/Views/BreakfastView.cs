using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Prime31.TransitionKit;
using UnityEngine.SceneManagement;

public class BreakfastView : View {

    public Text DisplayText;

    public GameObject LoafPrefab;

    public GameObject KnifePrefab;

    public GameObject CursorPrefab;

    public Vector3 TargetPos = Vector3.zero;

    private GameObject Loaf1;

    private GameObject Loaf2;

    private GameObject Loaf3;

    public int LoavesLeft = 3;

    public void CreateLoaves()
    {
        TargetPos = Camera.main.ScreenToWorldPoint(Screen.height / 2 * Random.insideUnitCircle + new Vector2(Screen.width / 2f, Screen.height*3f/5f));
        var StartPos1 = new Vector2(Random.value * Screen.width / 3f, 0f);
        var StartPos2 = new Vector2(Random.value * Screen.width * 2f / 3f, 0f);
        var StartPos3 = new Vector2(Random.value * Screen.width, 0f);
        var Rotation1 = Random.Range(-720f, 720f);
        var Rotation2 = Random.Range(-720f, 720f);
        var Rotation3 = Random.Range(-720f, 720f);
        StartPos1 = Camera.main.ScreenToWorldPoint(StartPos1);
        StartPos2 = Camera.main.ScreenToWorldPoint(StartPos2);
        StartPos3 = Camera.main.ScreenToWorldPoint(StartPos3);
        var Velocity1 = (StartPos1.x - TargetPos.x) * -2f;
        var Velocity2 = (StartPos2.x - TargetPos.x) * -2f;
        var Velocity3 = (StartPos3.x - TargetPos.x) * -2f;
        var VerticalVelocity = (Mathf.Abs(StartPos1.y - TargetPos.y) - (9.8f * (0.75f * 0.75f) / 2f)) * 2f;

        Loaf1 = (GameObject) Instantiate(LoafPrefab, StartPos1, Quaternion.Euler(new Vector3(0f, 0f, Rotation1)));
        Loaf1.GetComponent<Projectile>().Velocity = new Vector2(Velocity1, VerticalVelocity);
        Loaf1.GetComponent<Projectile>().Rotation = Rotation1;
        Loaf2 = (GameObject)Instantiate(LoafPrefab, StartPos2, Quaternion.Euler(new Vector3(0f, 0f, Rotation2)));
        Loaf2.GetComponent<Projectile>().Velocity = new Vector2(Velocity2, VerticalVelocity);
        Loaf2.GetComponent<Projectile>().Rotation = Rotation2;
        Loaf3 = (GameObject)Instantiate(LoafPrefab, StartPos3, Quaternion.Euler(new Vector3(0f, 0f, Rotation3)));
        Loaf3.GetComponent<Projectile>().Velocity = new Vector2(Velocity3, VerticalVelocity);
        Loaf3.GetComponent<Projectile>().Rotation = Rotation3;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(TargetPos, 0.5f);
        var orig = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -50f));
        Gizmos.DrawLine(orig, orig + Vector3.forward * 50f);
    }

    public void Update()
    {
        if (LoavesLeft > 0) GameController.CurrentTime += Time.deltaTime;
    }

    public override void FireKeyPressed()
    {
        StartCoroutine(ThrowKnifeRoutine());
    }

    private IEnumerator ThrowKnifeRoutine()
    {
        var orig = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -9f));
        var obj = (GameObject)Instantiate(KnifePrefab, orig + Vector3.forward * 12f, Quaternion.Euler(Vector3.zero));
        var timer = 0.1f;
        while ((timer -= Time.deltaTime) > 0f) yield return null;
        obj.GetComponent<Animator>().SetBool("hit", true);
        var hits = Physics2D.RaycastAll(orig, Vector3.forward, 100f);
        Debug.Log("Hits: " + hits.Length);
        LoavesLeft -= hits.Length;
        foreach (var hit in hits)
        {
            hit.collider.gameObject.GetComponent<Projectile>().Pin();
        }
        DisplayText.text = (LoavesLeft > 0 ? "<color=red>" + LoavesLeft + "</color> pieces of bread left!" : "Good job!");
    }

    public void TransitionNextScreen()
    {
        var wind = new WindTransition()
        {
            nextScene = SceneManager.GetActiveScene().buildIndex + 1,
            duration = 0.2f,
            size = 0.4f
        };
        GameController.StepCount++;
        TransitionKit.instance.transitionWithDelegate(wind);
    }

    public override void Initialize()
    {
        Instantiate(CursorPrefab);
        StartCoroutine(SpawnBread());
    }

    public IEnumerator SpawnBread()
    {
        while (LoavesLeft > 0)
        {
            CreateLoaves();
            yield return new WaitForSeconds(1.5f);
        }
        TransitionNextScreen();
    }

}

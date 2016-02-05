using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public Vector2 Velocity = Vector2.zero;

    public float Rotation = 90f;

    public bool move = true;

	// Use this for initialization
	void Start () {
	
	}
	
    public void Pin()
    {
        move = false;
    }

	// Update is called once per frame
	void Update () {
        if (move)
        {
            Velocity -= new Vector2(0f, 9.8f * Time.deltaTime);
            transform.position += new Vector3(Velocity.x * Time.deltaTime, Velocity.y * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(0f, 0f, transform.localRotation.eulerAngles.z + Rotation * Time.deltaTime);
            if (Camera.main.WorldToScreenPoint(transform.position).y < Screen.height * -0.2f || Camera.main.WorldToScreenPoint(transform.position).y > Screen.height * 1.2f) Destroy(gameObject);
        }
    }
}

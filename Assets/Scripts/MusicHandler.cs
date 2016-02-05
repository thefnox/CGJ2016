using UnityEngine;
using System.Collections;

public class MusicHandler : MonoBehaviour {

    public AudioSource Source;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        GameController.MusicInstance = this;
        StartMusic();
    }

    public void StartMusic()
    {
        Source.Play();
    }

    public void StopMusic()
    {
        Source.Stop();
    }
}

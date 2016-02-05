using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour {

    private List<InputCallbacks> Callbacks = new List<InputCallbacks>();

	// Use this for initialization
	void Start () {
        GameController.InputInstance = this;
        StartCoroutine(InputRoutine());
	}
	
    private IEnumerator InputRoutine()
    {
        while (true)
        {
            if (Input.GetKey(GameController.UpKey) || Input.GetKey(GameController.UpAltKey)) foreach (var callback in Callbacks) callback.OnUpKeyHeld();
            if (Input.GetKey(GameController.DownKey) || Input.GetKey(GameController.DownAltKey)) foreach (var callback in Callbacks) callback.OnDownKeyHeld();
            if (Input.GetKey(GameController.LeftKey) || Input.GetKey(GameController.LeftAltKey)) foreach (var callback in Callbacks) callback.OnLeftKeyHeld();
            if (Input.GetKey(GameController.RightKey) || Input.GetKey(GameController.RightAltKey)) foreach (var callback in Callbacks) callback.OnRightKeyHeld();
            if (Input.GetKey(GameController.FireKey) || Input.GetKey(GameController.FireAltKey))
                foreach (var callback in Callbacks) callback.OnFireKeyHeld();

            if (Input.GetKeyDown(GameController.UpKey) || Input.GetKeyDown(GameController.UpAltKey)) foreach (var callback in Callbacks) callback.OnUpKeyPressed();
            if (Input.GetKeyDown(GameController.DownKey) || Input.GetKeyDown(GameController.DownAltKey)) foreach (var callback in Callbacks) callback.OnDownKeyPressed();
            if (Input.GetKeyDown(GameController.LeftKey) || Input.GetKeyDown(GameController.LeftAltKey)) foreach (var callback in Callbacks) callback.OnLeftKeyPressed();
            if (Input.GetKeyDown(GameController.RightKey) || Input.GetKeyDown(GameController.RightAltKey)) foreach (var callback in Callbacks) callback.OnRightKeyPressed();
            if (Input.GetKeyDown(GameController.FireKey) || Input.GetKeyDown(GameController.FireAltKey))
                foreach (var callback in Callbacks) callback.OnFireKeyPressed();

            if (Input.GetKeyUp(GameController.UpKey) || Input.GetKeyUp(GameController.UpAltKey)) foreach (var callback in Callbacks) callback.OnUpKeyReleased();
            if (Input.GetKeyUp(GameController.DownKey) || Input.GetKeyUp(GameController.DownAltKey)) foreach (var callback in Callbacks) callback.OnDownKeyReleased();
            if (Input.GetKeyUp(GameController.LeftKey) || Input.GetKeyUp(GameController.LeftAltKey)) foreach (var callback in Callbacks) callback.OnLeftKeyReleased();
            if (Input.GetKeyUp(GameController.RightKey) || Input.GetKeyUp(GameController.RightAltKey)) foreach (var callback in Callbacks) callback.OnRightKeyReleased();
            if (Input.GetKeyUp(GameController.FireKey) || Input.GetKeyUp(GameController.FireAltKey)) foreach (var callback in Callbacks) callback.OnFireKeyReleased();

            if (Input.anyKey)
            {
                foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(key))
                    {
                        foreach (var callback in Callbacks) callback.OnAnyKeyPressed(key);
                        break;
                    }
                }
            }

            yield return null;
        }
    }

    public void AddCallback(InputCallbacks callback)
    {
        Callbacks.Add(callback);
    }

    public void RemoveCallback(InputCallbacks callback)
    {
        Callbacks.Add(callback);
    }

    public interface InputCallbacks
    {
        void OnUpKeyHeld();
        void OnUpKeyPressed();
        void OnUpKeyReleased();
        void OnDownKeyHeld();
        void OnDownKeyPressed();
        void OnDownKeyReleased();
        void OnLeftKeyHeld();
        void OnLeftKeyPressed();
        void OnLeftKeyReleased();
        void OnRightKeyHeld();
        void OnRightKeyPressed();
        void OnRightKeyReleased();
        void OnFireKeyHeld();
        void OnFireKeyPressed();
        void OnFireKeyReleased();
        void OnAnyKeyPressed(KeyCode key);
    }
}

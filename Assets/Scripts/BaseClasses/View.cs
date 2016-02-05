using UnityEngine;
using System.Collections;
using System;

public class View : MonoBehaviour, InputHandler.InputCallbacks {
    public void OnDownKeyHeld()
    {
        DownKeyHeld();
    }

    public virtual void DownKeyHeld()
    {

    }

    public void OnDownKeyPressed()
    {
        DownKeyPressed();
    }

    public virtual void DownKeyPressed()
    {

    }

    public void OnDownKeyReleased()
    {
        DownKeyReleased();
    }
    public virtual void DownKeyReleased()
    {

    }

    public void OnFireKeyHeld()
    {
        FireKeyHeld();
    }

    public virtual void FireKeyHeld()
    {

    }

    public void OnFireKeyPressed()
    {
        FireKeyPressed();
    }

    public virtual void FireKeyPressed()
    {

    }

    public void OnFireKeyReleased()
    {
        FireKeyReleased();
    }

    public virtual void FireKeyReleased()
    {

    }

    public void OnLeftKeyHeld()
    {
        LeftKeyHeld();
    }

    public virtual void LeftKeyHeld()
    {

    }

    public void OnLeftKeyPressed()
    {
        LeftKeyPressed();
    }
    public virtual void LeftKeyPressed()
    {

    }

    public void OnLeftKeyReleased()
    {
        LeftKeyReleased();
    }

    public virtual void LeftKeyReleased()
    {

    }

    public void OnRightKeyHeld()
    {
        RightKeyHeld();
    }

    public virtual void RightKeyHeld()
    {

    }

    public void OnRightKeyPressed()
    {
        RightKeyPressed();
    }

    public virtual void RightKeyPressed()
    {

    }

    public void OnRightKeyReleased()
    {
        RightKeyReleased();
    }

    public virtual void RightKeyReleased()
    {

    }

    public void OnUpKeyHeld()
    {
        UpKeyHeld();
    }
    public virtual void UpKeyHeld()
    {

    }

    public void OnUpKeyPressed()
    {
        UpKeyPressed();
    }

    public virtual void UpKeyPressed()
    {

    }

    public void OnUpKeyReleased()
    {
        UpKeyReleased();
    }

    public virtual void UpKeyReleased()
    {

    }

    public void OnAnyKeyPressed(KeyCode key)
    {
        AnyKeyPressed(key);
    }

    public virtual void AnyKeyPressed(KeyCode key)
    {

    }

    public virtual void Initialize()
    {
        
    }

    // Use this for initialization
    IEnumerator Start () {
        GameController.CurrentView = this;
        yield return null;
        GameController.InputInstance.AddCallback(this);
        Initialize();

    }

    public void OnDestroy()
    {
        if (GameController.InputInstance != null) GameController.InputInstance.RemoveCallback(this);
        if (GameController.CurrentView == this) GameController.CurrentView = null;
    }

}

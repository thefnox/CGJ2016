using UnityEngine;
using System.Collections;

public static class GameController {

    public static InputHandler InputInstance;

    public static MusicHandler MusicInstance;

    public static View CurrentView;

    public static KeyCode UpKey = KeyCode.UpArrow;

    public static KeyCode UpAltKey = KeyCode.W;

    public static KeyCode DownKey = KeyCode.DownArrow;

    public static KeyCode DownAltKey = KeyCode.S;

    public static KeyCode LeftKey = KeyCode.LeftArrow;

    public static KeyCode LeftAltKey = KeyCode.A;

    public static KeyCode RightKey = KeyCode.RightArrow;

    public static KeyCode RightAltKey = KeyCode.D;

    public static KeyCode FireKey = KeyCode.Space;

    public static KeyCode FireAltKey = KeyCode.Mouse0;

    public static float CurrentTime = 0f;

    public static int StepCount = 1;

    public const int StepTotal = 8;

    public const float MaxTime = 60f;

    public const int NumberAnswers = 6;

    public static int[] CorrectAnswers = new int[NumberAnswers];

    private static int[] CurrentAnswers = new int[NumberAnswers];

    public static void GenerateAnswers()
    {
        for (int i = 0; i < NumberAnswers; i++)
        {
            CorrectAnswers[i] = (i == 2 ? Random.Range(-6, 6) : Random.Range(0, 3));
            CurrentAnswers[i] = -1;
        }
    }

    public static bool CheckAnswers()
    {
        for (int i = 0; i < NumberAnswers; i++)
        {
            if (CorrectAnswers[i] != CurrentAnswers[i]) return false;
        }
        return true;
    }

    public static void SetAnswer(int i, int answer)
    {
        CurrentAnswers[i] = answer;
    }

    public static int GetAnswer(int i)
    {
        return CurrentAnswers[i];
    }

    public static void StartGame()
    {
        StepCount = 1;
        CurrentTime = 0f;
        GenerateAnswers();
    }

}

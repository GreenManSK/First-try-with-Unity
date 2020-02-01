using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public static bool isGamePaused;

    private static Text _text;
    private static string _textValue;

    private void Start()
    {
        _text = GetComponent<Text>();
        _textValue = _text.text;
        _text.text = "";
    }

    public static void Toggle()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public static void Pause()
    {
        Time.timeScale = 0f;
        _text.text = _textValue;
        isGamePaused = true;
    }

    public static void Resume()
    {
        Time.timeScale = 1f;
        _text.text = "";
        isGamePaused = false;
    }
}
using TMPro;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool isGamePaused;

    private static TextMeshProUGUI _text;
    private static string _textValue;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
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
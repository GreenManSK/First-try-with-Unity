using System.Collections.Generic;
using LocalizationHelper;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<TextAsset> localizations;

    private void Awake()
    {
        Localization.Instance().Load(localizations, false);
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = .1f;
    }

    void OnGUI()
    {
        if (Application.isEditor)
        {
            GUI.Label(new Rect(0, 0, 100, 100), "FPS: " + (int) (1.0f / Time.smoothDeltaTime));
        }
    }
}
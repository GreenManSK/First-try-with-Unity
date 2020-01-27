using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = .5f;
    }
    
    void OnGUI()
    {
        if (Application.isEditor)
        {
            GUI.Label(new Rect(0, 0, 100, 100), "FPS: " + (int) (1.0f / Time.smoothDeltaTime));
        }
    }
}

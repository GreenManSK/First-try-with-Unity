using System.Collections;
using System.Collections.Generic;
using Hud;
using UnityEngine;

public abstract class ASubHudController : MonoBehaviour
{
    public HudController HudController;

    public float x;
    public float y;
    public float width;
    public float height;

    protected void Start()
    {
        transform.position = new Vector3(x - width, height - y, 0);
    }
}

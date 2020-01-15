using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsHudController : ASubHudController
{
    protected new void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        x = HudController.GetWidth() / 2f;
        y = HudController.GetHeight() / 2f;
        var sprite = spriteRenderer.sprite;
        width = sprite.bounds.size.x;
        height = sprite.bounds.size.y;
        base.Start();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

public class MineableController : MonoBehaviour
{
    public EffectivityDictionary effectivity = new EffectivityDictionary()
    {
        {ToolType.Axe, 1f},
        {ToolType.Pickaxe, 1f},
        {ToolType.Sword, 1f}
    };

    public float MaxDurability = 10.0f;

    private float _durability;

    private void Start()
    {
        _durability = MaxDurability;
    }

    public void Damage(ToolController tool)
    {
        _durability -= tool.Power * effectivity[tool.Type];
        if (_durability <= 0)
        {
            Destroy(gameObject);
        }
    }
}

[System.Serializable]
public class EffectivityDictionary : SerializableDictionaryBase<ToolType, float>
{
}
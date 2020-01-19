using System;
using System.Collections;
using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;
using UnityEngine.Serialization;

public class MineableController : MonoBehaviour
{
    private static readonly int AnimationTime = Animator.StringToHash("Time");
    
    public EffectivityDictionary effectivity = new EffectivityDictionary()
    {
        {ToolType.Axe, 1f},
        {ToolType.Pickaxe, 1f},
        {ToolType.Sword, 1f}
    };

    public float maxDurability = 10.0f;

    public GameObject damageAnimation;

    private Animator _animator;
    private float _durability;

    private void Start()
    {
        _durability = maxDurability;
        var effect = Instantiate(
            damageAnimation,
            transform.position,
            Quaternion.identity
        );
        effect.transform.parent = transform;
        _animator = effect.GetComponent<Animator>();
        _animator.speed = 0f;
    }

    public void Damage(ToolController tool)
    {
        _durability -= tool.GetPower() * effectivity[tool.type];
        _animator.SetFloat(AnimationTime, 1 - _durability / maxDurability);
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
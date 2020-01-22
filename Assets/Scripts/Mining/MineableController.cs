using System;
using RotaryHeart.Lib.SerializableDictionary;
using Tools;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MineableController : MonoBehaviour
{
    private static readonly int AnimationTime = Animator.StringToHash("Time");
    
    public EffectivityDictionary effectivity = new EffectivityDictionary
    {
        {ToolType.Axe, 1f},
        {ToolType.Pickaxe, 1f},
        {ToolType.Sword, 1f}
    };

    public float maxDurability = 10.0f;

    public GameObject damageAnimation;
    public GameObject miningEffect;

    public AudioClip damageSound;
    
    private Animator _animator;
    private AudioSource _audioSource;
    private float _durability;
    private ParticleSystem _miningParticles;

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
        _audioSource = GetComponent<AudioSource>();
    }

    public void Damage(ToolController tool)
    {
        _durability -= tool.GetPower() * effectivity[tool.type];
        _animator.SetFloat(AnimationTime, 1 - _durability / maxDurability);
        EmitParticles();
        _audioSource.PlayOneShot(damageSound);
        if (_durability <= 0)
        {
            GetComponent<Renderer>().enabled = false;
            Destroy(gameObject, damageSound.length);
        }
    }

    private void EmitParticles()
    {
        if (_miningParticles == null)
        {
            var effect = Instantiate(
                miningEffect,
                transform.position,
                Quaternion.identity
            );
            effect.transform.parent = transform;
            _miningParticles = effect.GetComponent<ParticleSystem>();
        }
        _miningParticles.Clear();
        _miningParticles.Play();
    }
}

[Serializable]
public class EffectivityDictionary : SerializableDictionaryBase<ToolType, float>
{
}
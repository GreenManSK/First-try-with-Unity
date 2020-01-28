using System;
using RotaryHeart.Lib.SerializableDictionary;
using Tools;
using UnityEngine;

namespace Mining
{
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

        public delegate void DestroyDelegate();

        public event DestroyDelegate Destroyed;

        public delegate void DamageDelegate(float durabilityPercentage);

        public event DamageDelegate Damaged;

        public float maxDurability = 10.0f;

        public GameObject damageAnimation;
        public GameObject miningEffect;

        public AudioClip damageSound;
        public AudioClip destroySound;

        public GameObject drop;
        public int dropQuantity = 1;

        private Animator _animator;
        private AudioSource _audioSource;
        private float _durability;
        private ParticleSystem _miningParticles;

        private void Start()
        {
            _durability = maxDurability;
            if (damageAnimation)
            {
                var effect = Instantiate(
                    damageAnimation,
                    transform.position,
                    Quaternion.identity
                );
                effect.transform.parent = transform;
                _animator = effect.GetComponent<Animator>();
                _animator.speed = 0f;
            }

            _audioSource = GetComponent<AudioSource>();
        }

        public void Damage(ToolController tool)
        {
            _durability -= tool.GetPower() * effectivity[tool.type];
            Damaged?.Invoke(_durability / maxDurability);

            if (_animator != null)
                _animator.SetFloat(AnimationTime, 1 - _durability / maxDurability - 0.001f);

            if (_durability <= 0)
            {
                _audioSource.PlayOneShot(destroySound);
                SpawnDrop();
                Destroy(gameObject, destroySound.length);
            }
            else
            {
                _audioSource.PlayOneShot(damageSound);
                EmitParticles();
            }
        }

        private void SpawnDrop()
        {
            if (!drop) return;
            var item = Instantiate(drop, transform.position, Quaternion.identity);
            item.GetComponent<DropItemController>().quantity = dropQuantity;
        }

        public void SetMaxDurability(float newMaxDurability, bool adjustActualDurability)
        {
            if (adjustActualDurability)
            {
                _durability *= newMaxDurability / maxDurability;
            }

            maxDurability = newMaxDurability;
        }

        private void OnDestroy()
        {
            // We don't need to trigger Destroyed when the object is destroyed by Unity
            if (_durability <= 0)
                Destroyed?.Invoke();
        }

        private void EmitParticles()
        {
            if (miningEffect == null)
                return;
            if (_miningParticles == null)
            {
                var effect = Instantiate(
                    miningEffect,
                    transform.position,
                    miningEffect.transform.rotation
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
}
using System;
using Constants;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace Tools
{
    public class ToolController : MonoBehaviour
    {
        private static readonly int StabAnimationTrigger = Animator.StringToHash("Stab");
        private static readonly int SwingAnimationTrigger = Animator.StringToHash("Swing");

        public delegate void DestroyDelegate();

        public event DestroyDelegate Destroyed;

        public ToolType type;
        public float basePower = 1f;

        public AttackPowerDictionary attackPowers = new AttackPowerDictionary
        {
            {AttackType.Swing, 1f},
            {AttackType.Stab, 1f}
        };

        private Animator _animator;
        private AttackType _attackType;

        public void Stab()
        {
            _attackType = AttackType.Stab;
            _animator = GetComponent<Animator>();
            _animator.SetTrigger(StabAnimationTrigger);
        }

        public void Swing()
        {
            _attackType = AttackType.Swing;
            _animator = GetComponent<Animator>();
            _animator.SetTrigger(SwingAnimationTrigger);
        }

        public void OnFinish()
        {
            Destroy(gameObject);
        }

        public float GetPower()
        {
            return basePower * attackPowers[_attackType];
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Layers.Destroyable))
            {
                other.GetComponent<MineableController>()?.Damage(this);
            }
        }

        private void OnDestroy()
        {
            Destroyed?.Invoke();
        }
    }

    [Serializable]
    public class AttackPowerDictionary : SerializableDictionaryBase<AttackType, float>
    {
    }
}
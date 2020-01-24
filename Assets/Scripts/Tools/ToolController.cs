using System;
using System.Collections.Generic;
using Constants;
using Mining;
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
        private bool _shouldDelete;
        private HashSet<MineableController> _damaged = new HashSet<MineableController>();

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
            if (_shouldDelete)
            {
                Destroy(gameObject);
            }
            _damaged.Clear();
        }

        public void Delete()
        {
            _shouldDelete = true;
        }

        public float GetPower()
        {
            return basePower * attackPowers[_attackType];
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            TryTriggerCollision(other);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            TryTriggerCollision(other);
        }

        private void TryTriggerCollision(Collider2D other)
        {
            if (other.CompareTag(Tags.Destroyable))
            {
                var obj = other.GetComponent<MineableController>();
                if (obj != null && !_damaged.Contains(obj))
                {
                    _damaged.Add(obj);
                    obj.Damage(this);
                }
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
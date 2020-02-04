using Constants;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Hud
{
    public class NumberController : MonoBehaviour
    {
        public GameObject digit;
        public int size = 4;
        public int defaultValue = 9999;
        public float digitSize = 4 * Game.PIXEL;
        public float gapSize = 1 * Game.PIXEL;

        private Animator[] _animators;
        private static readonly int Time = Animator.StringToHash("Time");

        private void Awake()
        {
            if (_animators != null)
                return;
            _animators = new Animator[size];
            for (var i = 0; i < size; ++i)
            {
                _animators[i] = CreateDigit(transform.position - new Vector3(i * (digitSize + gapSize), 0, 0));
            }

            SetValue(defaultValue);
        }

        public void SetValue(int value)
        {
            for (var i = 0; i < size; ++i)
            {
                var animator = _animators[i];
                if (value != 0 || i == 0)
                {
                    animator.gameObject.SetActive(true);
                    var d = value % 10;
                    value /= 10;
                    animator.SetFloat(Time, d * 0.1f);
                }
                else
                {
                    animator.gameObject.SetActive(false);
                }
            }
        }

        private Animator CreateDigit(Vector3 position)
        {
            var digitObject = Instantiate(digit, position, Quaternion.identity);
            digitObject.transform.SetParent(transform, true);
            return digitObject.GetComponent<Animator>();
        }
    }
}
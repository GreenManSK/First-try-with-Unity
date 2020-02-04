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

        private GameObject[] digits;
        private static readonly int Time = Animator.StringToHash("Time");

        private void Awake()
        {
            if (digits != null)
                return;
            digits = new GameObject[size];
            for (var i = 0; i < size; ++i)
            {
                digits[i] = CreateDigit(GetPosition(i));
            }

            SetValue(defaultValue);
        }

        private Vector3 GetPosition(int i)
        {
            return transform.position - new Vector3(i * (digitSize + gapSize), 0, 0);
        }

        public void SetValue(int value)
        {
            var ones = 0;
            for (var i = 0; i < size; ++i)
            {
                var digit = digits[i];
                if (value != 0 || i == 0)
                {
                    digit.SetActive(true);
                    var d = value % 10;
                    value /= 10;
                    digit.GetComponent<Animator>().SetFloat(Time, d * 0.1f);
                    digit.transform.position = GetPosition(i) + new Vector3(2 * ones * Game.PIXEL, 0, 0);
                    ones += d == 1 ? 1 : 0;
                }
                else
                {
                    digit.SetActive(false);
                }
            }
        }

        private GameObject CreateDigit(Vector3 position)
        {
            var digitObject = Instantiate(digit, position, Quaternion.identity);
            digitObject.transform.SetParent(transform, true);
            return digitObject;
        }
    }
}
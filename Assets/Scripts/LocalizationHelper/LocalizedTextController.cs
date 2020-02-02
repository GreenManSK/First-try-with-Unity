using UnityEngine;
using UnityEngine.UI;

namespace LocalizationHelper
{
    [RequireComponent(typeof(Text))]
    public class LocalizedTextController : MonoBehaviour
    {
        private void Start()
        {
            var textComponent = GetComponent<Text>();
            textComponent.text = Localization._(textComponent.text);
        }
    }
}
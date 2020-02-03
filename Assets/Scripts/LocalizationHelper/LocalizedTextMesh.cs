using TMPro;
using UnityEngine;

namespace LocalizationHelper
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LocalizedTextMesh : MonoBehaviour
    {
        private void Start()
        {
            var textComponent = GetComponent<TextMeshProUGUI>();
            textComponent.text = Localization._(textComponent.text);
        }
    }
}
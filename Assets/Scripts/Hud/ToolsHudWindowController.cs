using UnityEngine;

namespace Hud
{
    public class ToolsHudWindowController : MonoBehaviour
    {
        public GameObject Active;
        public GameObject NotActive;
        public SpriteRenderer Icon;

        public void SetActive(bool active)
        {
            Active.SetActive(active);
            NotActive.SetActive(!active);
        }

        public void SetIcon(Sprite sprite)
        {
            Icon.sprite = sprite;
        }
    }
}

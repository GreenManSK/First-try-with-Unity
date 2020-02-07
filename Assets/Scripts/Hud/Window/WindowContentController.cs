using UnityEngine;

namespace Hud.Window
{
    public class WindowContentController : MonoBehaviour
    {
        
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            var rect = GetComponent<RectTransform>();
            rect.offsetMin = new Vector2(rect.rect.height, 0);
        }
    }
#endif
}
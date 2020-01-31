using System.Collections.Generic;
using Constants;
using UnityEngine;

namespace Trees
{
    public class LeavesController : MonoBehaviour
    {
        public float transparency = 0.5f;

        private List<Material> _materials;

        private void OnTriggerEnter2D(Collider2D other)
        {
            SetTransparency(other, transparency);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            SetTransparency(other, 1f);
        }

        private void SetTransparency(Component other, float value)
        {
            if (!other.gameObject.CompareTag(Tags.Player))
                return;
            if (_materials == null)
            {
                GetMaterials();
            }

            foreach (var material in _materials)
            {
                var col = material.color;
                col.a = value;
                material.color = col;
            }
        }

        private void GetMaterials()
        {
            var renderers = GetComponentsInChildren<Renderer>();
            _materials = new List<Material>();

            foreach (var r in renderers)
            {
                if (!r.gameObject.CompareTag(Tags.Drop) && r.material.HasProperty("_Color"))
                    _materials.Add(r.material);
            }
        }
    }
}
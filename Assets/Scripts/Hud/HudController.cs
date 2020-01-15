using UnityEngine;
using UnityEngine.U2D;

namespace Hud
{
    public class HudController : MonoBehaviour
    {
        public new Camera camera;

        private PixelPerfectCamera _pixelPerfectCamera;

        private void Awake()
        {
            _pixelPerfectCamera = camera.GetComponent<PixelPerfectCamera>();
        }

        private void Update()
        {
            var cameraPosition = camera.transform.position;
            cameraPosition.z = 0;
            transform.position = cameraPosition;
        }

        public float GetWidth()
        {
            return (float) _pixelPerfectCamera.refResolutionX / _pixelPerfectCamera.assetsPPU;
        }

        public float GetHeight()
        {
            return (float) _pixelPerfectCamera.refResolutionY / _pixelPerfectCamera.assetsPPU;
        }
    }
}
using UnityEngine;

namespace Hud
{
    public abstract class ASubHudController : MonoBehaviour
    {
        public HudController HudController;

        protected float X;
        protected float Y;
        protected float Width;
        protected float Height;

        protected void Start()
        {
            transform.position = new Vector3(X - Width, Height - Y, 0);
        }
    }
}

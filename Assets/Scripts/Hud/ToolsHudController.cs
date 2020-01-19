using System.Collections.Generic;
using UnityEngine;

namespace Hud
{
    public class ToolsHudController : ASubHudController
    {

        private const float WindowBaseX = -2.125f;
        private const float WindowBaseY = 0.125f;
        private const float WindowBaseXDelta = 1;
    
        public PlayerController Player;
        public GameObject ToolsHudWindowPrefab;

        private List<ToolsHudWindowController> _windows;
        protected new void Start()
        {
            X = HudController.GetWidth() / 2f;
            Y = HudController.GetHeight() / 2f;
            base.Start();

            CreateWindows();
        }

        private void CreateWindows()
        {
            _windows = new List<ToolsHudWindowController>();
            var count = 0;
            foreach (var tool in Player.tools)
            {
                var window = Instantiate(ToolsHudWindowPrefab, Vector3.zero, Quaternion.identity);
                window.transform.parent = gameObject.transform;
                window.transform.localPosition = new Vector3(WindowBaseX + count++ * WindowBaseXDelta, WindowBaseY, 0);
                var hudWindow = window.GetComponent<ToolsHudWindowController>();
                hudWindow.SetIcon(tool.GetComponentInChildren<SpriteRenderer>()?.sprite);
                hudWindow.SetActive(false);
                _windows.Add(hudWindow);
            }
            Player.ToolChanged += RefreshWindows;
            _windows[Player.GetActiveToolIndex()].SetActive(true);
        }

        private void RefreshWindows(int activeIndex)
        {
            foreach (var window in _windows)
            {
                window.SetActive(false);
            }
            _windows[activeIndex].SetActive(true);
        }
    }
}

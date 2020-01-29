using System;
using Constants;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine.UI;

namespace Hud
{
    public class InventoryHudController : ASubHudController
    {
        private const float ImageHeight = 13f / Game.PPU;

        public TextDictionary texts = new TextDictionary();
        public InventoryController inventory;
        
        protected new void Start()
        {
            Y = (-HudController.GetHeight() + ImageHeight) / 2f;
            base.Start();
            foreach (var pair in texts)
            {
                pair.Value.text = inventory.Get(pair.Key).ToString();
            }

            inventory.Changed += UpdateText;
        }

        private void UpdateText(DropType type, int newVolume)
        {
            if (texts.ContainsKey(type))
            {
                texts[type].text = newVolume.ToString();
            }
        }
    }

    [Serializable]
    public class TextDictionary : SerializableDictionaryBase<DropType, Text>
    {
    }
}
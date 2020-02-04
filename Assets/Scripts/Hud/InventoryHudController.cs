using System;
using Constants;
using RotaryHeart.Lib.SerializableDictionary;
using TMPro;

namespace Hud
{
    public class InventoryHudController : ASubHudController
    {
        private const float ImageHeight = 14f / Game.PPU;

        public TextDictionary texts = new TextDictionary();
        public InventoryController inventory;

        protected new void Start()
        {
            Y = (-HudController.GetHeight() + ImageHeight) / 2f;
            base.Start();
            foreach (var pair in texts)
            {
                pair.Value.SetValue(inventory.Get(pair.Key));
            }

            inventory.Changed += UpdateText;
        }

        private void UpdateText(DropType type, int newVolume)
        {
            if (texts.ContainsKey(type))
            {
                texts[type].SetValue(newVolume);
            }
        }
    }

    [Serializable]
    public class TextDictionary : SerializableDictionaryBase<DropType, NumberController>
    {
    }
}
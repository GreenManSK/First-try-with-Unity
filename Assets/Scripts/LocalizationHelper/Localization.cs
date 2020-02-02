using System.Collections.Generic;
using UnityEngine;

namespace LocalizationHelper
{
    public class Localization
    {
        private static Localization _instance;

        private Dictionary<string, ITranslation> defaultLocal;
        private List<Dictionary<string, ITranslation>> locals;

        private Localization()
        {
        }

        public void Load(List<TextAsset> localAssets, bool force)
        {
            if (locals != null && !force)
                return;
            locals = new List<Dictionary<string, ITranslation>>();
            foreach (var asset in localAssets)
            {
                locals.Add(LanguageParser.Parse(asset));
            }

            defaultLocal = locals[0];
        }

        public string Translate(string key, params object[] arguments)
        {
            if (defaultLocal.ContainsKey(key))
                return defaultLocal[key].Translate(arguments);
            Debug.LogWarning($"Unknown localization key {key}");
            return key;
        }

        public void SetDefault(int index)
        {
            defaultLocal = locals[index];
        }

        public static string _(string key, params object[] arguments)
        {
            return Instance().Translate(key, arguments);
        }

        public static Localization Instance()
        {
            return _instance ?? (_instance = new Localization());
        }
    }
}
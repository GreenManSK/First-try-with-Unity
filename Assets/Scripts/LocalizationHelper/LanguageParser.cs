using System.Collections.Generic;
using LocalizationHelper.Data;
using UnityEngine;

namespace LocalizationHelper
{
    public class LanguageParser
    {
        private LanguageParser()
        {
        }

        public static Dictionary<string, ITranslation> Parse(TextAsset file)
        {
            var language = JsonUtility.FromJson<Language>(file.text);
            var result = new Dictionary<string, ITranslation>();
            foreach (var group in language.groups)
            {
                ParseGroup(group, result);
            }

            return result;
        }

        private static void ParseGroup(Group group, IDictionary<string, ITranslation> result)
        {
            var keyPrefix = group.keyPrefix ?? "";
            foreach (var translation in group.translations)
            {
                if (translation.key == null)
                {
                    Debug.LogError($"Missing key for translation in group ${group.keyPrefix}");
                }

                result.Add($"{keyPrefix}{translation.key}", CreateTranslation(translation));
            }
        }

        private static ITranslation CreateTranslation(Translation translation)
        {
            if (translation.variants != null)
                return new RangedTranslation(
                    translation.argNumber != null ? int.Parse(translation.argNumber) : 0,
                    translation.variants
                );
            if (translation.text == null)
                Debug.LogError($"Missing text for {translation.key} translation");
            return new SimpleTranslation(translation.text);
        }
    }
}
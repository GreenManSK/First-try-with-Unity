using JetBrains.Annotations;

namespace LocalizationHelper.Data
{
    [System.Serializable]
    public class Language
    {
        public string name;
        public Group[] groups;
    }

    [System.Serializable]
    public class Group
    {
        public string name;
        public string keyPrefix;
        public Translation[] translations;
    }

    [System.Serializable]
    public class Translation
    {
        public string key;
        [CanBeNull] public string text;
        [CanBeNull] public string argNumber;
        [CanBeNull] public Variant[] variants;
    }

    [System.Serializable]
    public class Variant
    {
        [CanBeNull] public string lowerBound;
        [CanBeNull] public string upperBound;
        public string text;
    }
}
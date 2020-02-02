namespace LocalizationHelper
{
    public class SimpleTranslation : ITranslation
    {
        private readonly string _text;

        public SimpleTranslation(string text)
        {
            _text = text;
        }

        public string Translate(params object[] arguments)
        {
            return string.Format(_text, arguments);
        }
    }
}
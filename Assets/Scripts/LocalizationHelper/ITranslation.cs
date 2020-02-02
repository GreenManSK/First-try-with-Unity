namespace LocalizationHelper
{
    public interface ITranslation
    {
        string Translate(params object[] arguments);
    }
}
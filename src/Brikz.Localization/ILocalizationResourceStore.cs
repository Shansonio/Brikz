namespace Brikz.Localization
{
    public interface ILocalizationResourceStore
    {
        string GetLocalizedString(string code, string locale);
    }
}

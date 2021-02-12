namespace Brikz.Localization
{
    public interface IResourceStore
    {
        string GetLocalizedString(string code, string locale);
    }
}

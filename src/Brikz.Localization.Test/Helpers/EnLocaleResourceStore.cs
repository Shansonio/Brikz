using System;
using System.Collections.Generic;
using System.Text;

namespace Brikz.Localization.Test
{
    public class EnLocaleResourceStore : ILocalizationResourceStore
    {
        private Dictionary<string, Dictionary<string, string>> _localizedStrings = new Dictionary<string, Dictionary<string, string>>
            {
                {
                    TestData.Locale.En,  new Dictionary<string, string> {
                    { TestData.ArgMessageTemplateCode,TestData.ArgMessageTemplateEn },
                    { TestData.MessageTemplateCode, TestData.MessageTemplateEn },
                    { TestData.StringArgCode, TestData.StringArgEn } }
                }
            };

        public string GetLocalizedString(string code, string locale)
        {
            return _localizedStrings.ContainsKey(locale) ?
                 _localizedStrings[locale].ContainsKey(code) ?
                 _localizedStrings[locale][code] : null : null;
        }
    }

    public class EmptyLocaleResourceStore : ILocalizationResourceStore
    {
        private Dictionary<string, Dictionary<string, string>> _localizedStrings = new Dictionary<string, Dictionary<string, string>>();

        public string GetLocalizedString(string code, string locale)
        {
            return _localizedStrings.ContainsKey(locale) ?
                 _localizedStrings[locale].ContainsKey(code) ?
                 _localizedStrings[locale][code] : null : null;
        }
    }
}

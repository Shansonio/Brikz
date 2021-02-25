using System;
using System.Collections.Generic;

namespace Brikz.Localization
{
    public class LocalizableString
    {
        public string Code { get; private set; }
        
        public bool HasCode => !string.IsNullOrWhiteSpace(Code);

        public string DefaultText { get; private set; }


        private readonly Dictionary<string, string> _translations = new Dictionary<string, string>();

        public LocalizableString(string defaultText)
        {
            if (string.IsNullOrWhiteSpace(defaultText)) throw new ArgumentNullException(nameof(defaultText));

            DefaultText = defaultText;
        }

        public LocalizableString SetCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentNullException(nameof(code));
            
            Code = code;
            
            return this;
        }

        public LocalizableString SetTranslation(string locale, string text)
        {
            if (string.IsNullOrWhiteSpace(locale)) throw new ArgumentNullException(nameof(locale));
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentNullException(nameof(text));

            if (_translations.ContainsKey(locale))
                _translations[locale] = text;
            else
                _translations.Add(locale, text);

            return this;
        }

        public override string ToString()
        {
            return DefaultText;
        }

        public string ToString(string locale)
        {
            return !string.IsNullOrWhiteSpace(locale) && _translations.ContainsKey(locale) ? _translations[locale] : ToString();
        }

        public string ToString(string locale, ILocalizationResourceStore store)
        {
            if (string.IsNullOrWhiteSpace(locale)) return ToString();
            if (store == null || !HasCode) return ToString(locale);

            var localizedText = store.GetLocalizedString(Code, locale);
            if (string.IsNullOrWhiteSpace(localizedText)) return ToString(locale);

            return localizedText;
        }

        public static implicit operator LocalizableString(string text)
        {
            return text.ToLocalizableString();
        }
    }
}

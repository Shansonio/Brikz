using System;
using System.Collections.Generic;

namespace Brikz.Localization.MessageArguments
{
    public class StringMessageArgument : MessageArgument
    {
        public string Code { get; private set; }

        public bool HasCode => !string.IsNullOrWhiteSpace(Code);

        private readonly Dictionary<string, string> _translations = new Dictionary<string, string>();

        public StringMessageArgument(string value, string code = null)
            : base(value)
        {
            Code = code;
        }

        public StringMessageArgument AddTranslation(string locale, string text)
        {
            if (string.IsNullOrWhiteSpace(locale)) throw new ArgumentNullException(nameof(locale));
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentNullException(nameof(text));

            if (_translations.ContainsKey(locale))
                _translations[locale] = text;
            else
                _translations.Add(locale, text);

            return this;
        }

        public override string ToString(string locale)
        {
            return !string.IsNullOrWhiteSpace(locale) && _translations.ContainsKey(locale) ? _translations[locale] : ToString();
        }

        public override string ToString(string locale, ILocalizationResourceStore store)
        {
            if (string.IsNullOrWhiteSpace(locale)) return ToString();
            if (store == null || !HasCode) return ToString(locale);

            var localizedText = store.GetLocalizedString(Code, locale);
            if (string.IsNullOrWhiteSpace(localizedText)) return ToString(locale);

            return localizedText;
        }

        public static implicit operator StringMessageArgument(string arg)
        {
            return new StringMessageArgument(arg);
        }
    }
}

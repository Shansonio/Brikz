using System;
using System.Globalization;

namespace Brikz.Localization.MessageArguments
{
    public abstract class NonTranslatableMessageArgument<T> : MessageArgument
    {
        public string CustomFormat { get; private set; }

        protected NonTranslatableMessageArgument(T value, string customFormat = null)
            : base(value)
        {
            CustomFormat = customFormat;
        }

        public override string ToString(string locale)
        {
            if (string.IsNullOrWhiteSpace(locale)) return ToString();

            return Localize((T)Value, new CultureInfo(locale));
        }

        public override string ToString(string locale, ILocalizationResourceStore store)
        {
            return ToString(locale);
        }

        protected abstract string Localize(T value, IFormatProvider provider);
    }
}

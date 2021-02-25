using System;
using System.Globalization;

namespace Brikz.Localization.MessageArguments
{
    public abstract class ValueTypeMessageArgument<T> : MessageArgument
        where T : struct
    {
        public string CustomFormat { get; private set; }

        protected ValueTypeMessageArgument(T value, string customFormat = null)
            : base(value)
        {
            CustomFormat = customFormat;
        }

        public override string ToString()
        {
            return Localize((T)Value);
        }

        public override string ToString(string locale)
        {
            if (string.IsNullOrWhiteSpace(locale)) return Localize((T)Value);

            return Localize((T)Value, new CultureInfo(locale));
        }

        public override string ToString(string locale, ILocalizationResourceStore store)
        {
            return ToString(locale);
        }

        protected abstract string Localize(T value);
        protected abstract string Localize(T value, IFormatProvider provider);
    }
}

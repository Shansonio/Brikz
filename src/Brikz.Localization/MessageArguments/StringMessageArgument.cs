using System;
using System.Collections.Generic;

namespace Brikz.Localization.MessageArguments
{
    public class StringMessageArgument : MessageArgument
    {
        public LocalizableString Text => (LocalizableString)Value;

        public StringMessageArgument(LocalizableString value)
            : base(value)
        {
        }

        public override string ToString()
        {
            return Text.ToString();
        }

        public override string ToString(string locale)
        {
            return Text.ToString(locale);
        }

        public override string ToString(string locale, ILocalizationResourceStore store)
        {
            return Text.ToString(locale, store);
        }

        public static implicit operator StringMessageArgument(string text)
        {
            return text.ToMessageArgument();
        }
    }
}

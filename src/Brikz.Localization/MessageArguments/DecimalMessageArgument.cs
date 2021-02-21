using System;

namespace Brikz.Localization.MessageArguments
{
    public class DecimalMessageArgument : NonTranslatableMessageArgument<decimal>
    {
        public DecimalMessageArgument(decimal value, string customFormat = null)
           : base(value, customFormat)
        {
        }

        protected override string Localize(decimal value, IFormatProvider provider)
        {
            return !string.IsNullOrWhiteSpace(CustomFormat) ?
                value.ToString(CustomFormat, provider) :
                value.ToString(provider);
        }

        public static implicit operator DecimalMessageArgument(decimal arg)
        {
            return new DecimalMessageArgument(arg);
        }
    }
}

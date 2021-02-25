using System;

namespace Brikz.Localization.MessageArguments
{
    public class DecimalMessageArgument : ValueTypeMessageArgument<decimal>
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

        protected override string Localize(decimal value)
        {
            return !string.IsNullOrWhiteSpace(CustomFormat) ?
                value.ToString(CustomFormat) :
                value.ToString();
        }

        public static implicit operator DecimalMessageArgument(decimal arg)
        {
            return arg.ToMessageArgument();
        }
    }
}

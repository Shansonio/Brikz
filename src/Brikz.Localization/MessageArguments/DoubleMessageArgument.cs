using System;

namespace Brikz.Localization.MessageArguments
{
    public class DoubleMessageArgument : NonTranslatableMessageArgument<double>
    {
        public DoubleMessageArgument(double value, string customFormat = null)
           : base(value, customFormat)
        {
        }

        protected override string Localize(double value, IFormatProvider provider)
        {
            return !string.IsNullOrWhiteSpace(CustomFormat) ?
                value.ToString(CustomFormat, provider) :
                value.ToString(provider);
        }

        public static implicit operator DoubleMessageArgument(double arg)
        {
            return new DoubleMessageArgument(arg);
        }
    }
}

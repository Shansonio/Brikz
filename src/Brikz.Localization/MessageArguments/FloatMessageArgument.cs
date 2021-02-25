using System;

namespace Brikz.Localization.MessageArguments
{
    public class FloatMessageArgument : ValueTypeMessageArgument<float>
    {
        public FloatMessageArgument(float value, string customFormat = null)
           : base(value, customFormat)
        {
        }

        protected override string Localize(float value, IFormatProvider provider)
        {
            return !string.IsNullOrWhiteSpace(CustomFormat) ?
                value.ToString(CustomFormat, provider) :
                value.ToString(provider);
        }

        protected override string Localize(float value)
        {
            return !string.IsNullOrWhiteSpace(CustomFormat) ?
                value.ToString(CustomFormat) :
                value.ToString();
        }

        public static implicit operator FloatMessageArgument(float arg)
        {
            return arg.ToMessageArgument();
        }
    }
}

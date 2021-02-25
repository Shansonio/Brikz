using System;

namespace Brikz.Localization.MessageArguments
{
    public class LongMessageArgument : ValueTypeMessageArgument<long>
    {
        public LongMessageArgument(long value, string customFormat = null)
           : base(value, customFormat)
        {
        }

        protected override string Localize(long value, IFormatProvider provider)
        {
            return !string.IsNullOrWhiteSpace(CustomFormat) ?
                value.ToString(CustomFormat, provider) :
                value.ToString(provider);
        }

        protected override string Localize(long value)
        {
            return !string.IsNullOrWhiteSpace(CustomFormat) ?
                value.ToString(CustomFormat) :
                value.ToString();
        }

        public static implicit operator LongMessageArgument(long arg)
        {
            return arg.ToMessageArgument();
        }
    }
}

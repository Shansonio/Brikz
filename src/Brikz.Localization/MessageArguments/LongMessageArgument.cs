using System;

namespace Brikz.Localization.MessageArguments
{
    public class LongMessageArgument : NonTranslatableMessageArgument<long>
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

        public static implicit operator LongMessageArgument(long arg)
        {
            return new LongMessageArgument(arg);
        }
    }
}

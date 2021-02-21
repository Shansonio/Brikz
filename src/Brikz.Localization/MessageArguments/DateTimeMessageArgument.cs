using System;

namespace Brikz.Localization.MessageArguments
{
    public class DateTimeMessageArgument : NonTranslatableMessageArgument<DateTime>
    {
        public DateTimeMessageArgument(DateTime value, string customFormat = null)
            : base(value, customFormat)
        {
        }

        protected override string Localize(DateTime value, IFormatProvider provider)
        {
            return !string.IsNullOrWhiteSpace(CustomFormat) ?
                value.ToString(CustomFormat, provider) :
                value.ToString(provider);
        }

        public static implicit operator DateTimeMessageArgument(DateTime arg)
        {
            return new DateTimeMessageArgument(arg);
        }
    }
}

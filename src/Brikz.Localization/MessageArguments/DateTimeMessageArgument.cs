using System;

namespace Brikz.Localization.MessageArguments
{
    public class DateTimeMessageArgument : ValueTypeMessageArgument<DateTime>
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

        protected override string Localize(DateTime value)
        {
            return !string.IsNullOrWhiteSpace(CustomFormat) ?
                value.ToString(CustomFormat) :
                value.ToString();
        }

        public static implicit operator DateTimeMessageArgument(DateTime arg)
        {
            return arg.ToMessageArgument();
        }
    }
}

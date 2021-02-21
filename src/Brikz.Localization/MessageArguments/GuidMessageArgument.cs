using System;

namespace Brikz.Localization.MessageArguments
{
    public class GuidMessageArgument : NonTranslatableMessageArgument<Guid>
    {
        public GuidMessageArgument(Guid value, string customFormat = null)
           : base(value, customFormat)
        {
        }

        protected override string Localize(Guid value, IFormatProvider provider)
        {
            return !string.IsNullOrWhiteSpace(CustomFormat) ?
                value.ToString(CustomFormat, provider) :
                value.ToString();
        }

        public static implicit operator GuidMessageArgument(Guid arg)
        {
            return new GuidMessageArgument(arg);
        }
    }
}

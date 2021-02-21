using System;

namespace Brikz.Localization.MessageArguments
{
    public class IntegerMessageArgument : NonTranslatableMessageArgument<int>
    {
        public IntegerMessageArgument(int value, string customFormat = null)
           : base(value, customFormat)
        {
        }

        protected override string Localize(int value, IFormatProvider provider)
        {
            return !string.IsNullOrWhiteSpace(CustomFormat) ?
                value.ToString(CustomFormat, provider) :
                value.ToString(provider);
        }

        public static implicit operator IntegerMessageArgument(int arg)
        {
            return new IntegerMessageArgument(arg);
        }
    }
}

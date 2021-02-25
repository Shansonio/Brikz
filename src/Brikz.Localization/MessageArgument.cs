using Brikz.Localization.MessageArguments;
using System;

namespace Brikz.Localization
{
    public abstract class MessageArgument
    {
        public object Value { get; private set; }

        protected MessageArgument(object value)
        {            
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public abstract string ToString(string locale);

        public abstract string ToString(string locale, ILocalizationResourceStore store);


        public static implicit operator MessageArgument(string arg)
        {
            return arg.ToMessageArgument();
        }

        public static implicit operator MessageArgument(DateTime arg)
        {
            return arg.ToMessageArgument();
        }

        public static implicit operator MessageArgument(decimal arg)
        {
            return arg.ToMessageArgument();
        }

        public static implicit operator MessageArgument(double arg)
        {
            return arg.ToMessageArgument();
        }

        public static implicit operator MessageArgument(float arg)
        {
            return arg.ToMessageArgument();
        }

        public static implicit operator MessageArgument(int arg)
        {
            return arg.ToMessageArgument();
        }

        public static implicit operator MessageArgument(long arg)
        {
            return arg.ToMessageArgument();
        }

        public static implicit operator MessageArgument(Guid arg)
        {
            return arg.ToMessageArgument();
        }
    }
}

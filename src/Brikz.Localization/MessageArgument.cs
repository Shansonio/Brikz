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

        public override string ToString()
        {
            return Value.ToString();
        }

        public abstract string ToString(string locale);

        public abstract string ToString(string locale, ILocalizationResourceStore store);


        public static implicit operator MessageArgument(string arg)
        {
            return new StringMessageArgument(arg);
        }

        public static implicit operator MessageArgument(DateTime arg)
        {
            return new DateTimeMessageArgument(arg);
        }

        public static implicit operator MessageArgument(decimal arg)
        {
            return new DecimalMessageArgument(arg);
        }

        public static implicit operator MessageArgument(double arg)
        {
            return new DoubleMessageArgument(arg);
        }

        public static implicit operator MessageArgument(float arg)
        {
            return new FloatMessageArgument(arg);
        }

        public static implicit operator MessageArgument(int arg)
        {
            return new IntegerMessageArgument(arg);
        }

        public static implicit operator MessageArgument(long arg)
        {
            return new LongMessageArgument(arg);
        }

        public static implicit operator MessageArgument(Guid arg)
        {
            return new GuidMessageArgument(arg);
        }
    }
}

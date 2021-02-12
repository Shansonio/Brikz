using System;
using System.Globalization;

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

        public abstract string ToString(string locale, IResourceStore store);

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

        public static implicit operator MessageArgument(Enum arg)
        {
            return new EnumMessageArgument(arg);
        }
    }

    public abstract class MessageArgument<T> : MessageArgument
    {
        public string CustomFormat { get; private set; }

        protected MessageArgument(T value, string customFormat = null) 
            : base(value)
        {
            CustomFormat = customFormat;
        }

        public override string ToString(string locale, IResourceStore store)
        {            
            return string.IsNullOrWhiteSpace(locale) ?
                Value.ToString() : Localize((T)Value, new CultureInfo(locale));
        }

        protected abstract string Localize(T value, IFormatProvider provider);
    }

    public class StringMessageArgument : MessageArgument
    {
        public string Code { get; private set; }

        public StringMessageArgument(string value, string code = null) 
            : base(value)
        {
            Code = code;
        }        

        public static implicit operator StringMessageArgument(string arg)
        {
            return new StringMessageArgument(arg);
        }

        public override string ToString(string locale, IResourceStore store)
        {
            if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(locale) || store == null) return (string)Value;

            var localized = store.GetLocalizedString(Code, locale);
            if(string.IsNullOrEmpty(localized)) return (string)Value;

            return localized;
        }
    }

    public class DateTimeMessageArgument : MessageArgument<DateTime>
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

    public class DecimalMessageArgument : MessageArgument<decimal>
    {
        public DecimalMessageArgument(decimal value, string customFormat = null)
           : base(value, customFormat)
        {
        }

        protected override string Localize(decimal value, IFormatProvider provider)
        {
            return !string.IsNullOrWhiteSpace(CustomFormat) ?
                value.ToString(CustomFormat, provider) :
                value.ToString(provider);
        }

        public static implicit operator DecimalMessageArgument(decimal arg)
        {
            return new DecimalMessageArgument(arg);
        }
    }

    public class DoubleMessageArgument : MessageArgument<double>
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

    public class FloatMessageArgument : MessageArgument<float>
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

        public static implicit operator FloatMessageArgument(float arg)
        {
            return new FloatMessageArgument(arg);
        }
    }

    public class IntegerMessageArgument : MessageArgument<int>
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

    public class LongMessageArgument : MessageArgument<long>
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

    public class GuidMessageArgument : MessageArgument<Guid>
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

    public class EnumMessageArgument : MessageArgument<Enum>
    {
        public EnumMessageArgument(Enum value, string customFormat = null)
           : base(value, customFormat)
        {
        }

        protected override string Localize(Enum value, IFormatProvider provider)
        {
            return !string.IsNullOrWhiteSpace(CustomFormat) ?
                value.ToString(CustomFormat) :
                value.ToString();
        }

        public static implicit operator EnumMessageArgument(Enum arg)
        {
            return new EnumMessageArgument(arg);
        }
    }
}

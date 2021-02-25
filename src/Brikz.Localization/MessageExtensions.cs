using Brikz.Localization.MessageArguments;
using System;

namespace Brikz.Localization
{
    public static class MessageExtensions
    {
        public static LocalizableString ToLocalizableString(this string text)
        {
            return string.IsNullOrWhiteSpace(text) ? null : new LocalizableString(text);
        }

        public static LocalizableString SetCode(this string text, string code)
        {
            return text.ToLocalizableString()?.SetCode(code);
        }

        public static LocalizableString SetTranslation(this string text, string locale, string translation)
        {
            return text.ToLocalizableString()?.SetTranslation(locale, translation);
        }

        public static Message ToMessage(this string message, params MessageArgument[] args)
        {
            return message.ToLocalizableString().ToMessage(args);
        }

        public static Message ToMessageWithCode(this string message, string code, params MessageArgument[] args)
        {
            return message.SetCode(code).ToMessage(args);
        }

        public static Message ToMessage(this LocalizableString text, params MessageArgument[] args)
        {
            return text == null ? null : new Message(text, args);
        }

        public static StringMessageArgument ToMessageArgument(this LocalizableString text)
        {
            return text == null ? null : new StringMessageArgument(text);
        }

        public static StringMessageArgument ToMessageArgument(this string arg, string code = null)
        {
            return string.IsNullOrWhiteSpace(code) ?
                arg.ToLocalizableString().ToMessageArgument() :
                arg.SetCode(code).ToMessageArgument();
        }

        public static DateTimeMessageArgument ToMessageArgument(this DateTime arg, string customFormat = null)
        {
            return new DateTimeMessageArgument(arg, customFormat);
        }

        public static DecimalMessageArgument ToMessageArgument(this decimal arg, string customFormat = null)
        {
            return new DecimalMessageArgument(arg, customFormat);
        }

        public static DoubleMessageArgument ToMessageArgument(this double arg, string customFormat = null)
        {
            return new DoubleMessageArgument(arg, customFormat);
        }

        public static FloatMessageArgument ToMessageArgument(this float arg, string customFormat = null)
        {
            return new FloatMessageArgument(arg, customFormat);
        }

        public static IntegerMessageArgument ToMessageArgument(this int arg, string customFormat = null)
        {
            return new IntegerMessageArgument(arg, customFormat);
        }

        public static LongMessageArgument ToMessageArgument(this long arg, string customFormat = null)
        {
            return new LongMessageArgument(arg, customFormat);
        }

        public static GuidMessageArgument ToMessageArgument(this Guid arg, string customFormat = null)
        {
            return new GuidMessageArgument(arg, customFormat);
        }
    }
}

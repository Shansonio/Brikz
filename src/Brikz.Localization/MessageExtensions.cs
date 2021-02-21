using Brikz.Localization.MessageArguments;
using System;

namespace Brikz.Localization
{
    public static class MessageExtensions
    {
        public static Message ToMessage(this string message, params MessageArgument[] args)
        {
            return message == null ? null : new Message(new MessageTemplate(null, message), args);
        }

        public static Message ToMessageWithCode(this string message, string code, params MessageArgument[] args)
        {
            return message == null ? null : new Message(new MessageTemplate(code, message), args);
        }

        public static MessageTemplate ToMessageTemplate(this string message)
        {
            return message == null ? null : new MessageTemplate(null, message);
        }

        public static MessageTemplate ToMessageTemplateWithCode(this string message, string code)
        {
            return message == null ? null : new MessageTemplate(code, message);
        }

        public static Message ToMessage(this MessageTemplate template, params MessageArgument[] args)
        {
            return template == null ? null : new Message(template, args);
        }

        public static MessageArgument ToMessageArgument(this string arg, string code)
        {
            return new StringMessageArgument(arg, code);
        }

        public static MessageArgument ToMessageArgument(this DateTime arg, string customFormat)
        {
            return new DateTimeMessageArgument(arg, customFormat);
        }

        public static MessageArgument ToMessageArgument(this decimal arg, string customFormat)
        {
            return new DecimalMessageArgument(arg, customFormat);
        }

        public static MessageArgument ToMessageArgument(this double arg, string customFormat)
        {
            return new DoubleMessageArgument(arg, customFormat);
        }

        public static MessageArgument ToMessageArgument(this float arg, string customFormat)
        {
            return new FloatMessageArgument(arg, customFormat);
        }

        public static MessageArgument ToMessageArgument(this int arg, string customFormat)
        {
            return new IntegerMessageArgument(arg, customFormat);
        }

        public static MessageArgument ToMessageArgument(this long arg, string customFormat)
        {
            return new LongMessageArgument(arg, customFormat);
        }

        public static MessageArgument ToMessageArgument(this Guid arg, string customFormat)
        {
            return new GuidMessageArgument(arg, customFormat);
        }
    }
}

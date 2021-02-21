using System;
using System.Runtime.Serialization;
using System.Text;

namespace Brikz.Localization
{
    [Serializable]
    public class LocalizableMessageException : Exception
    {
        public readonly Message LocalizableMessage;
        public override string Message => LocalizableMessage?.ToString();

        public LocalizableMessageException()
            : base()
        {
        }

        public LocalizableMessageException(Message message)
            : this()
        {
            LocalizableMessage = message;
        }

        public LocalizableMessageException(MessageTemplate template, params MessageArgument[] args)
            : this(template?.ToMessage(args))
        {
        }

        public LocalizableMessageException(Exception inner, Message message)
            : base(message?.ToString(), inner)
        {
            LocalizableMessage = message;
        }

        public LocalizableMessageException(Exception inner, MessageTemplate template, params MessageArgument[] args)
            : this(inner, template?.ToMessage(args))
        {
        }

        protected LocalizableMessageException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        public string ToString(string locale)
        {
            if (string.IsNullOrWhiteSpace(locale)) return ToString();

            return GetFullString(LocalizableMessage.ToString(locale));
        }

        public string ToString(string locale, ILocalizationResourceStore store)
        {            
            if (string.IsNullOrWhiteSpace(locale)) return ToString();
            if (store == null) return ToString(locale);

            return GetFullString(LocalizableMessage.ToString(locale, store));
        }

        private string GetFullString(string localizedString)
        {
            var message = $"{GetType().FullName}: {localizedString}";

            if (InnerException != null)
                message += $"\r\n ---> {InnerException}\r\n   --- End of inner exception stack trace ---";

            if (!string.IsNullOrWhiteSpace(StackTrace))
                message += $"\r\n{StackTrace}";

            return message;
        }
    }
}

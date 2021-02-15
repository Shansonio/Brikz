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

        public LocalizableMessageException(string message, params MessageArgument[] args)
            : this(message?.ToMessage(args))
        {
        }

        public LocalizableMessageException(Exception inner, Message message)
            : base(message?.ToString(), inner)
        {
            LocalizableMessage = message;
        }

        public LocalizableMessageException(Exception inner, string message, params MessageArgument[] args)
            : this(inner, message?.ToMessage(args))
        {
        }

        protected LocalizableMessageException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        public string ToString(string locale, IResourceStore store)
        {            
            if (string.IsNullOrWhiteSpace(locale) || store == null) return ToString();

            var message = $"{GetType().FullName}: {LocalizableMessage.ToString(locale, store)}";

            if (InnerException != null)
                message += $"\r\n ---> {InnerException}\r\n   --- End of inner exception stack trace ---";

            if (!string.IsNullOrWhiteSpace(StackTrace))
                message += $"\r\n{StackTrace}";

            return message;
        }
    }
}

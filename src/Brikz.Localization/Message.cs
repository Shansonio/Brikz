using System;
using System.Linq;

namespace Brikz.Localization
{
    public class Message
    {
        public LocalizableString Text { get; private set; }

        public MessageArgument[] Args { get; private set; }

        public Message(LocalizableString text, params MessageArgument[] args)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Args = args ?? new MessageArgument[0];
        }

        public override string ToString()
        {
            return string.Format(Text.ToString(), Args.Select(a => a.ToString()).ToArray());
        }

        public string ToString(string locale)
        {
            return string.Format(Text.ToString(locale), Args.Select(a => a.ToString(locale)).ToArray());
        }

        public string ToString(string locale, ILocalizationResourceStore store)
        {
            return string.Format(Text.ToString(locale, store), Args.Select(a => a.ToString(locale, store)).ToArray());
        }

        public static implicit operator Message(string message)
        {
            return message.ToMessage();
        }

        public static implicit operator Message(LocalizableString text)
        {
            return text.ToMessage();
        }
    }
}

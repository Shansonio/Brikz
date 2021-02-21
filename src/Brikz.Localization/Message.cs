using System;
using System.Linq;

namespace Brikz.Localization
{
    public class Message
    {
        public MessageTemplate Template { get; private set; }

        public MessageArgument[] Args { get; private set; }

        public Message(MessageTemplate template, params MessageArgument[] args)
        {
            Template = template ?? throw new ArgumentNullException(nameof(template));
            Args = args ?? new MessageArgument[0];
        }

        public override string ToString()
        {
            return string.Format(Template.ToString(), Args.Select(a => a.ToString()).ToArray());
        }

        public string ToString(string locale)
        {
            return string.Format(Template.ToString(locale), Args.Select(a => a.ToString(locale)).ToArray());
        }

        public string ToString(string locale, ILocalizationResourceStore store)
        {
            return string.Format(Template.ToString(locale, store), Args.Select(a => a.ToString(locale, store)).ToArray());
        }

        public static implicit operator Message(string message)
        {
            return message?.ToMessage();
        }

        public static implicit operator Message(MessageTemplate template)
        {
            return template?.ToMessage();
        }
    }
}

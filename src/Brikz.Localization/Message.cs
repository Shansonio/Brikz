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
            return Template.HasText ? string.Format(Template.Text, Args) : Template.Code;
        }

        public string ToString(string locale, IResourceStore store)
        {
            if (string.IsNullOrWhiteSpace(locale) || store == null) return ToString();

            var localizedMessage = Template.HasCode ? store.GetLocalizedString(Template.Code, locale) : Template.Text;
            if (string.IsNullOrWhiteSpace(localizedMessage)) localizedMessage = Template.Text;

            var localizedArguments = Args.Select(arg => arg.ToString(locale, store)).ToArray();

            return string.Format(localizedMessage, localizedArguments);
        }

        public static implicit operator Message(string message)
        {
            return new Message(message);
        }

        public static implicit operator Message(MessageTemplate template)
        {
            return template?.ToMessage();
        }
    }
}

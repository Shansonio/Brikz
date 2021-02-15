using System;

namespace Brikz.Localization
{
    public class MessageTemplate
    {
        public string Code { get; private set; }

        public bool HasCode => !string.IsNullOrWhiteSpace(Code);

        public string Text { get; private set; }

        public bool HasText => !string.IsNullOrWhiteSpace(Text);

        public MessageTemplate(string text)
            : this(null, text)
        {
        }

        public MessageTemplate(string code, string text)
        {
            if (code == null && text == null) throw new ArgumentNullException(nameof(text));

            Code = code;
            Text = text;
        }
        
        public static implicit operator MessageTemplate(string message)
        {
            return new MessageTemplate(message);
        }
    }
}

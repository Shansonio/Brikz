using System;
using Xunit;

namespace Brikz.Localization.Test
{
    public class SimpleMessageTest
    {
        [Fact]
        public void MessageToStringTest()
        {
            string testMessage = "Test message.";

            var message = testMessage.ToMessage();

            Assert.Equal(testMessage, message.ToString());
        }

        [Fact]
        public void MessageImplicitCastingTest()
        {
            string testMessage = "Test message.";
            Message createMessage(Message m) { return m; }
                        
            Assert.Equal(testMessage, createMessage(testMessage).ToString());
            Assert.Equal(testMessage, createMessage(new MessageTemplate(testMessage)).ToString());
        }

        [Fact]
        public void MessageWithArgumentsTest()
        {
            string testMessage = "Test message aith args {0} and {1} and {2}.";
            decimal decimalArg = 1;
            DateTime datetimeArg = DateTime.Today;
            string stringArg = "string";

            var message = new Message(testMessage, stringArg, decimalArg, datetimeArg);

            Assert.Equal(string.Format(testMessage, stringArg, decimalArg, datetimeArg), message.ToString());
            Assert.Equal(string.Format(testMessage, stringArg, decimalArg, datetimeArg), 
                testMessage.ToMessage(stringArg, decimalArg, datetimeArg).ToString());
        }

        [Fact]
        public void MessageTemplateTest()
        {
            string testMessage = "Test message aith args {0}.";

            var messageTemplate = testMessage.ToMessageTemplate();
            decimal decimalArg = 1;
            DateTime datetimeArg = DateTime.Today;
            string stringArg = "string";

            Assert.Equal(string.Format(testMessage, decimalArg), messageTemplate.ToMessage(decimalArg).ToString());
            
            Assert.Equal(string.Format(testMessage, datetimeArg), messageTemplate.ToMessage(datetimeArg).ToString());
            
            Assert.Equal(string.Format(testMessage, stringArg), messageTemplate.ToMessage(stringArg).ToString());
        }

        [Fact]
        public void MessageTemplateImplicitCastingTest()
        {
            string testMessage = "Test message template.";
            MessageTemplate createTemplate(MessageTemplate m) { return m; }

            Assert.Equal(testMessage, createTemplate(testMessage).ToMessage().ToString());
        }
    }
}

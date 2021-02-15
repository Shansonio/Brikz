using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace Brikz.Localization.Test
{
    public class LocalizedMessageTest
    {
        private const string En = "en-US";
        private const string De = "de-DE";

        private const string ArgMessageTemplateEn = "This is message template with arg - {0}.";
        private const string ArgMessageTemplateRu = "Это шаблон с аргументом - {0}.";
        private const string ArgMessageTemplateCode = "ArgMessageTemplate";

        private const string MessageTemplateEn = "This is message template.";
        private const string MessageTemplateRu = "Это шаблон.";
        private const string MessageTemplateCode = "MessageTemplate";

        private const string ArgEn = "This is arg.";
        private const string ArgRu = "Это аргумент.";
        private const string ArgCode = "Arg";

        class ResourceStore : IResourceStore
        {
            private Dictionary<string, Dictionary<string, string>> _localizedStrings = new Dictionary<string, Dictionary<string, string>>
            {
                {
                    En,  new Dictionary<string, string> {
                    { ArgMessageTemplateCode, ArgMessageTemplateEn },
                    { MessageTemplateCode, MessageTemplateEn },
                    { ArgCode, ArgEn } }
                }
            };

            public string GetLocalizedString(string code, string locale)
            {
                return _localizedStrings.ContainsKey(locale) ?
                     _localizedStrings[locale].ContainsKey(code) ?
                     _localizedStrings[locale][code] : null : null;
            }
        }


        [Fact]
        public void SimpleMessageLocalizationTest()
        {
            var resourceStore = new ResourceStore();

            var message = MessageTemplateRu.ToMessageWithCode(MessageTemplateCode).ToString(En, resourceStore);
            
            Assert.Equal(MessageTemplateEn, message);
        }

        [Fact]
        public void MessageWithLocalizableArgLocalizationTest()
        {
            var resourceStore = new ResourceStore();

            var message = ArgMessageTemplateRu
                .ToMessageWithCode(ArgMessageTemplateCode, ArgRu.ToMessageArgument(ArgCode))
                .ToString(En, resourceStore);

            Assert.Equal(string.Format(ArgMessageTemplateEn, ArgEn) , message);
        }

        [Fact]
        public void MessageWithLocalizableArgWithoutLocaleTest()
        {
            var resourceStore = new ResourceStore();

            var message = ArgMessageTemplateRu
                .ToMessageWithCode(ArgMessageTemplateCode, ArgRu.ToMessageArgument(ArgCode))
                .ToString(De, resourceStore);

            Assert.Equal(string.Format(ArgMessageTemplateRu, ArgRu), message);
        }

        [Fact]
        public void MessageArgumentsLocalizationTest()
        {
            var resourceStore = new ResourceStore();
            var messageTemplate = ArgMessageTemplateRu.ToMessageTemplateWithCode(ArgMessageTemplateCode);

            decimal decimalArg = 1;
            DateTime datetimeArg = DateTime.Today;

            Assert.Equal(string.Format(ArgMessageTemplateEn, decimalArg.ToString(new CultureInfo(En))), 
                messageTemplate.ToMessage(decimalArg).ToString(En, resourceStore));

            Assert.Equal(string.Format(ArgMessageTemplateEn, datetimeArg.ToString(new CultureInfo(En))), 
                messageTemplate.ToMessage(datetimeArg).ToString(En, resourceStore));
        }

        [Fact]
        public void MessageArgumentsWithCustomFormatLocalizationTest()
        {
            var resourceStore = new ResourceStore();
            var messageTemplate = ArgMessageTemplateRu.ToMessageTemplateWithCode(ArgMessageTemplateCode);

            DateTime datetimeArg = DateTime.Today;

            Assert.Equal(string.Format(ArgMessageTemplateEn, datetimeArg.ToString("dd.MM.yyyy", new CultureInfo(En))),
                messageTemplate.ToMessage(datetimeArg.ToMessageArgument("dd.MM.yyyy")).ToString(En, resourceStore));
        }

        [Fact]
        public void MessageTemplateWithoutCodeArgumentsLocalizationTest()
        {
            var resourceStore = new ResourceStore();
            var messageTemplate = ArgMessageTemplateRu.ToMessageTemplate();

            decimal decimalArg = 1;
            DateTime datetimeArg = DateTime.Today;

            Assert.Equal(string.Format(ArgMessageTemplateRu, decimalArg.ToString(new CultureInfo(En))),
                messageTemplate.ToMessage(decimalArg).ToString(En, resourceStore));

            Assert.Equal(string.Format(ArgMessageTemplateRu, datetimeArg.ToString(new CultureInfo(En))),
                messageTemplate.ToMessage(datetimeArg).ToString(En, resourceStore));
        }

        [Fact]
        public void LocalizedMessageExceptionTest()
        {
            var resourceStore = new ResourceStore();
            var innerException = new Exception("inner");
            var simpleExceptionRu = new Exception(MessageTemplateRu);
            var simpleExceptionEn = new Exception(MessageTemplateEn);

            var localizedException = new LocalizableMessageException(MessageTemplateRu.ToMessageWithCode(MessageTemplateCode));

            Assert.Equal(simpleExceptionEn.ToString().Replace("System.Exception", "Brikz.Localization.LocalizableMessageException"), 
                localizedException.ToString(En, resourceStore));
            Assert.Equal(simpleExceptionRu.ToString().Replace("System.Exception", "Brikz.Localization.LocalizableMessageException"), localizedException.ToString());
        }       
    }
}

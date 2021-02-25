using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xunit;

namespace Brikz.Localization.Test
{
    public class InCodeLocalizationTest
    {
        [Fact]
        public void MessageWithTranslationShouldBeTranslated()
        {
            var message = TestData.MessageTemplateRu
                .SetTranslation(TestData.Locale.En, TestData.MessageTemplateEn)
                .ToMessage();

            Assert.Equal(TestData.MessageTemplateEn, message.ToString(TestData.Locale.En));
        }

        [Fact]
        public void ArgumentsShouldBeFormattedAccordingLocale()
        {
            var message = TestData.ArgMessageTemplateRu
                .SetTranslation(TestData.Locale.En, TestData.ArgMessageTemplateEn)
                .ToMessage(DateTime.Today);

            Assert.Equal(string.Format(TestData.ArgMessageTemplateEn, DateTime.Today.ToString(new CultureInfo(TestData.Locale.En))),
                message.ToString(TestData.Locale.En));
            Assert.Equal(string.Format(TestData.ArgMessageTemplateRu, DateTime.Today.ToString(new CultureInfo(TestData.Locale.De))),
                message.ToString(TestData.Locale.De));
        }

        [Fact]
        public void DefaultTextShouldBeGottenIfTranslationForLocaleNotExists()
        {
            var message = TestData.MessageTemplateRu
                .SetTranslation(TestData.Locale.En, TestData.MessageTemplateEn)
                .ToMessage();

            Assert.Equal(TestData.MessageTemplateRu, message.ToString(TestData.Locale.De));
        }

        [Fact]
        public void StringArgumentShouldBeTranslatedEvenIfMessageNot()
        {
            var message = TestData.ArgMessageTemplateRu
                .ToMessage(TestData.StringArgRu
                .SetTranslation(TestData.Locale.En, TestData.StringArgEn)
                .ToMessageArgument());

            Assert.Equal(string.Format(TestData.ArgMessageTemplateRu, TestData.StringArgRu), message.ToString(TestData.Locale.Ru));
            Assert.Equal(string.Format(TestData.ArgMessageTemplateRu, TestData.StringArgEn), message.ToString(TestData.Locale.En));
        }

        [Fact]
        public void LocalizedMessageExceptionTest()
        {
            var simpleExceptionRu = new Exception(TestData.MessageTemplateRu);
            var simpleExceptionEn = new Exception(TestData.MessageTemplateEn);

            var localizedException = new LocalizableMessageException(TestData.MessageTemplateRu
                .SetTranslation(TestData.Locale.En, TestData.MessageTemplateEn));

            Assert.Equal(simpleExceptionEn.ToString().Replace("System.Exception", "Brikz.Localization.LocalizableMessageException"),
                localizedException.ToString(TestData.Locale.En));
            Assert.Equal(simpleExceptionRu.ToString().Replace("System.Exception", "Brikz.Localization.LocalizableMessageException"), localizedException.ToString());
        }
    }
}

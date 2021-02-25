using System;
using System.Globalization;
using Xunit;

namespace Brikz.Localization.Test
{
    public class NoLocalizationTest
    {
        [Fact]
        public void MessageWithoutCodeAndTranslationShouldNotBeTranslated()
        {
            Assert.Equal(TestData.MessageTemplateRu, MessageBuilder.CreateMessage(TestData.MessageTemplateRu).ToString());
            Assert.Equal(TestData.MessageTemplateRu, MessageBuilder.CreateMessage(TestData.MessageTemplateRu).ToString(TestData.Locale.En));
            Assert.Equal(TestData.MessageTemplateRu, MessageBuilder.CreateMessage(TestData.MessageTemplateRu).ToString(TestData.Locale.En, new EnLocaleResourceStore()));
        }

        [Fact]
        public void OneTemplateCanBeUsedWithDifferentArguments()
        {
            var template = TestData.ArgMessageTemplateRu.ToLocalizableString();

            decimal decimalArg = 1.5m;
            DateTime datetimeArg = DateTime.Today;
            string stringArg = "string";

            Assert.Equal(string.Format(TestData.ArgMessageTemplateRu, decimalArg), template.ToMessage(decimalArg).ToString());
            Assert.Equal(string.Format(TestData.ArgMessageTemplateRu, datetimeArg), template.ToMessage(datetimeArg).ToString());
            Assert.Equal(string.Format(TestData.ArgMessageTemplateRu, stringArg), template.ToMessage(stringArg).ToString());
        }

        [Fact]
        public void StringArgumentWithoutCodeShouldNotBeTranslated()
        {
            var template = TestData.ArgMessageTemplateRu.ToLocalizableString();
            string stringArg = "string";

            Assert.Equal(string.Format(TestData.ArgMessageTemplateRu, stringArg), template.ToMessage(stringArg).ToString());
            Assert.Equal(string.Format(TestData.ArgMessageTemplateRu, stringArg), template.ToMessage(stringArg).ToString(TestData.Locale.En));
            Assert.Equal(string.Format(TestData.ArgMessageTemplateRu, stringArg), template.ToMessage(stringArg).ToString(TestData.Locale.En, new EnLocaleResourceStore()));
        }

        [Fact]
        public void MessageArgumentFormatShouldChangeAccordingToLocale()
        {
            var template = TestData.ArgMessageTemplateRu.ToLocalizableString();
            DateTime datetimeArg = DateTime.Today;

            Assert.Equal(string.Format(TestData.ArgMessageTemplateRu, datetimeArg), template.ToMessage(datetimeArg).ToString());
            Assert.Equal(string.Format(TestData.ArgMessageTemplateRu, datetimeArg.ToString(new CultureInfo(TestData.Locale.En))), template.ToMessage(datetimeArg).ToString(TestData.Locale.En));
            Assert.Equal(string.Format(TestData.ArgMessageTemplateRu, datetimeArg.ToString(new CultureInfo(TestData.Locale.De))), template.ToMessage(datetimeArg).ToString(TestData.Locale.De));
        }

        [Fact]
        public void MessageArgumentWithCustomFormatShouldNotChangeItsFormat()
        {
            var template = TestData.ArgMessageTemplateRu.ToLocalizableString();
            var currentDate = DateTime.Today;
            var datetimeArg = currentDate.ToMessageArgument("dd.MM.yyyy");

            Assert.Equal(string.Format(TestData.ArgMessageTemplateRu, currentDate.ToString("dd.MM.yyyy")), template.ToMessage(datetimeArg).ToString());
            Assert.Equal(string.Format(TestData.ArgMessageTemplateRu, currentDate.ToString("dd.MM.yyyy")), template.ToMessage(datetimeArg).ToString(TestData.Locale.En));
            Assert.Equal(string.Format(TestData.ArgMessageTemplateRu, currentDate.ToString("dd.MM.yyyy")), template.ToMessage(datetimeArg).ToString(TestData.Locale.De));

        }
    }
}

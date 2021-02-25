using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace Brikz.Localization.Test
{
    public class ResourceStoreLocalizationTest
    {
        [Fact]
        public void MessageWithCodeShouldBeTranslated()
        {
            var resourceStore = new EnLocaleResourceStore();

            var message = TestData.MessageTemplateRu
                .ToMessageWithCode(TestData.MessageTemplateCode);

            Assert.Equal(TestData.MessageTemplateEn, message.ToString(TestData.Locale.En, resourceStore));
        }

        [Fact]
        public void MessageWithoutCodeShouldFallbackToOtherTranslationMethods()
        {
            var resourceStore = new EnLocaleResourceStore();

            Assert.Equal(TestData.MessageTemplateRu, TestData.MessageTemplateRu.ToMessage().ToString(TestData.Locale.En, resourceStore));
            Assert.Equal(TestData.MessageTemplateEn,
                TestData.MessageTemplateRu.SetTranslation(TestData.Locale.En, TestData.MessageTemplateEn)
                .ToMessage().ToString(TestData.Locale.En, resourceStore));
        }

        [Fact]
        public void MessageWithoutTranslationInResourceStoreShouldFallbackToOtherTranslationMethods()
        {
            var resourceStore = new EmptyLocaleResourceStore();

            var template = TestData.MessageTemplateRu
                .SetCode(TestData.MessageTemplateCode);

            Assert.Equal(TestData.MessageTemplateRu, template.ToMessage().ToString(TestData.Locale.En, resourceStore));
            Assert.Equal(TestData.MessageTemplateEn,
                template.SetTranslation(TestData.Locale.En, TestData.MessageTemplateEn)
                .ToMessage().ToString(TestData.Locale.En, resourceStore));
        }

        [Fact]
        public void StringArgumentWithCodeShouldBeTranslated()
        {
            var resourceStore = new EnLocaleResourceStore();
            var message = TestData.ArgMessageTemplateRu
               .ToMessage(TestData.StringArgRu.ToMessageArgument(TestData.StringArgCode));

            Assert.Equal(string.Format(TestData.ArgMessageTemplateRu, TestData.StringArgRu), message.ToString(TestData.Locale.Ru, resourceStore));
            Assert.Equal(string.Format(TestData.ArgMessageTemplateRu, TestData.StringArgEn), message.ToString(TestData.Locale.En, resourceStore));
        }

        [Fact]
        public void StringArgumentWithoutTranslationInResourceStoreShouldFallbackToOtherTranslationMethods()
        {
            var resourceStore = new EnLocaleResourceStore();
            var message = TestData.ArgMessageTemplateRu.SetCode(TestData.ArgMessageTemplateCode)
               .ToMessage(TestData.StringArgRu.ToMessageArgument());

            Assert.Equal(string.Format(TestData.ArgMessageTemplateRu, TestData.StringArgRu), message.ToString(TestData.Locale.Ru, resourceStore));
            Assert.Equal(string.Format(TestData.ArgMessageTemplateEn, TestData.StringArgRu), message.ToString(TestData.Locale.En, resourceStore));
        }

        
        
        [Fact]
        public void LocalizedMessageExceptionTest()
        {
            var resourceStore = new EnLocaleResourceStore();
            var simpleExceptionRu = new Exception(TestData.MessageTemplateRu);
            var simpleExceptionEn = new Exception(TestData.MessageTemplateEn);

            var localizedException = new LocalizableMessageException(TestData.MessageTemplateRu.ToMessageWithCode(TestData.MessageTemplateCode));

            Assert.Equal(simpleExceptionEn.ToString().Replace("System.Exception", "Brikz.Localization.LocalizableMessageException"), 
                localizedException.ToString(TestData.Locale.En, resourceStore));
            Assert.Equal(simpleExceptionRu.ToString().Replace("System.Exception", "Brikz.Localization.LocalizableMessageException"), localizedException.ToString());
        }       
    }
}

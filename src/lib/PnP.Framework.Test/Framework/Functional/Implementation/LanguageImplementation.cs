﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PnP.Framework.Provisioning.Model;
using PnP.Framework.Provisioning.ObjectHandlers;
using PnP.Framework.Test.Framework.Functional.Validators;

namespace PnP.Framework.Test.Framework.Functional.Implementation
{
    internal class LanguageImplementation : ImplementationBase
    {
        internal void SiteCollectionLanguageSettings(string url)
        {
            using (var cc = TestCommon.CreateClientContext(url))
            {
                // Explicitely clear out the base template for this test as otherwise we're not getting any results back
                ProvisioningTemplateCreationInformation ptci = new ProvisioningTemplateCreationInformation(cc.Web)
                {
                    BaseTemplate = null,
                    HandlersToProcess = Handlers.SupportedUILanguages,
                };

                var result = TestProvisioningTemplate(cc, "languagesettings_add.xml", Handlers.SupportedUILanguages, null, ptci);
                LanguageSettingsValidator lv = new LanguageSettingsValidator();
                Assert.IsTrue(lv.Validate(result.SourceTemplate.SupportedUILanguages, result.TargetTemplate.SupportedUILanguages, result.TargetTokenParser));

                // Delta test: check if we also can remove a set language
                var result2 = TestProvisioningTemplate(cc, "languagesettings_delta.xml", Handlers.SupportedUILanguages, null, ptci);
                Assert.IsTrue(lv.Validate(result2.SourceTemplate.SupportedUILanguages, result2.TargetTemplate.SupportedUILanguages, result2.TargetTokenParser));
            }
        }

        internal void WebLanguageSettings(string url)
        {
            using (var cc = TestCommon.CreateClientContext(url))
            {
                // Explicitely clear out the base template for this test as otherwise we're not getting any results back
                ProvisioningTemplateCreationInformation ptci = new ProvisioningTemplateCreationInformation(cc.Web)
                {
                    BaseTemplate = null,
                    HandlersToProcess = Handlers.SupportedUILanguages,
                };

                var result = TestProvisioningTemplate(cc, "languagesettings_add.xml", Handlers.SupportedUILanguages, null, ptci);
                LanguageSettingsValidator lv = new LanguageSettingsValidator();
                Assert.IsTrue(lv.Validate(result.SourceTemplate.SupportedUILanguages, result.TargetTemplate.SupportedUILanguages, result.TargetTokenParser));

                // Delta test: check if we also can remove a set language
                var result2 = TestProvisioningTemplate(cc, "languagesettings_delta.xml", Handlers.SupportedUILanguages, null, ptci);
                Assert.IsTrue(lv.Validate(result2.SourceTemplate.SupportedUILanguages, result2.TargetTemplate.SupportedUILanguages, result2.TargetTokenParser));
            }
        }
    }
}
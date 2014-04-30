#region Usings - System
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion
#region Usings - SWD
using Swd.Core;
using Swd.Core.Pages;
using Swd.Core.WebDriver;
using Swd.Core.Configuration;
#endregion
#region Usings - WebDriver
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
#endregion

namespace Demo.TestModel.IPMPpages.PanelFunctionality
{
    public class ServicesPage : PanelGeneralFunctionalityPage
    {
        public ServicesPage()
        {
            expectedUnitTitle = "PANEL";
            expectedPanelFunctionalityPage = "Services";
        }

        #region WebElements
        
        [FindsBy(How = How.CssSelector, Using = @"#unitFeaturesBusyButton")]
        protected IWebElement labelAllInfoLabels { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#fee_messaging_module")]
        protected IWebElement checkboxMessagingModule { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#fee_security_module")]
        protected IWebElement checkboxSecurityModule { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#fee_hdevice_module")]
        protected IWebElement checkboxHomeDeviceModule { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#fee_camera_module")]
        protected IWebElement checkboxCameraModule { get; set; }

        #endregion

        #region Invoke() and IsDisplayed()
        public override void Invoke()
        {
            var loginPage = GetLoginPage();
            var tycoPage = loginPage.Login();
            var PanelsPage = tycoPage.Panels();
            PanelsPage.Search(Config.panelID);
            var PanelGeneralPage = PanelsPage.PanelIDClick();
            PanelGeneralPage.ServicesClick();
        }

        #endregion

        public override void VerifyExpectedElementsAreDisplayed()
        {
            #region General Header locators
            VerifyElementVisible("tabPanels", tabPanels);
            VerifyElementVisible("tabGroups", tabGroups);
            VerifyElementVisible("tabEvents", tabEvents);
            VerifyElementVisible("tabProcesses", tabProcesses);
            VerifyElementVisible("tabSystem", tabSystem);
            VerifyElementVisible("labelVersion", labelVersion);
            VerifyElementVisible("labelCurrentUser", labelCurrentUser);
            VerifyElementVisible("linkSettings", linkSettings);
            VerifyElementVisible("linkLogout", linkLogout);
            VerifyElementVisible("linkHelp", linkHelp);
            #endregion

            #region Panel Functionality locators
            VerifyElementVisible("labelUnitTitle", labelUnitTitle);
            VerifyElementVisible("btnRefreshPanel", btnRefreshPanel);
            VerifyElementVisible("btnEditPanel", btnEditPanel);
            VerifyElementVisible("btnRemovePanel", btnRemovePanel);
            VerifyElementVisible("linkStatus", linkStatus);
            VerifyElementVisible("labelOnlineStatus", labelOnlineStatus);
            VerifyElementVisible("blockUnitNavigation", blockUnitNavigation);
            VerifyElementVisible("linkGeneral", linkGeneral);
            VerifyElementVisible("linkServices", linkServices);
            VerifyElementVisible("linkLocation", linkLocation);
            VerifyElementVisible("linkDiagnostics", linkDiagnostics);
            VerifyElementVisible("linkRemoteInspections", linkRemoteInspections);
            VerifyElementVisible("linkSetState", linkSetState);
            VerifyElementVisible("linkSetGetConfiguration", linkSetGetConfiguration);
            VerifyElementVisible("linkZonesCustomization", linkZonesCustomization);
            VerifyElementVisible("linkStandardLog", linkStandardLog);
            VerifyElementVisible("linkLegacyLog", linkLegacyLog);
            #endregion

            #region Caption locator
            VerifyElementVisible("labelCaption", labelCaption);
            #endregion

            VerifyElementVisible("labelUnitTitle", labelUnitTitle);
            VerifyElementVisible("labelAllInfoLabels", labelAllInfoLabels);
        }

        public override void WaitLoadPage()
        {
            Wait.UntilVisible(labelAllInfoLabels, 20000);
            Wait.UntilDisapear(mainModalDialog, 20000);
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Expected: " + expectedPanelFunctionalityPage + ", Current: " + currentPanelFunctionalityPage());
            }
        }
    }
}

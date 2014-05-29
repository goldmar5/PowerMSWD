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

namespace Demo.TestModel.IPMPpages
{
    public class DiagnosticsPage : PanelGeneralFunctionalityPage
    {
        public DiagnosticsPage()
        {
            expectedUnitTitle = "PANEL";
            expectedPanelFunctionalityPage = "Diagnostics";
        }

        #region WebElements 

        [FindsBy(How = How.CssSelector, Using = @".diagnosticFilterLine")]
        protected IWebElement blockDiagnosticFilter { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".diagnosticBtn button")]
        protected IWebElement dropdownActions { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".dijitTitlePaneTextNode")]
        protected IWebElement textDevicesTitle { get; set; }

        #endregion

        #region Invoke() and IsDisplayed()
        public override void Invoke()
        {
            var loginPage = GetLoginPage();
            var tycoPage = loginPage.Login();
            var PanelsPage = tycoPage.Panels();
            PanelsPage.Search(Config.panelID);
            var PanelGeneralPage = PanelsPage.PanelIDClick();
            PanelGeneralPage.DiagnosticsClick();
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

            VerifyElementVisible("blockDiagnosticFilter", blockDiagnosticFilter);
            VerifyElementVisible("dropdownActions", dropdownActions);
        }

        public override void WaitLoadPage()
        {
            Wait.UntilDisapear(mainModalDialog, 20000);
            Wait.UntilVisible(textDevicesTitle, 20000);
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Expected: " + expectedPanelFunctionalityPage + ", Current: " + currentPanelFunctionalityPage());
            }
        }
    }
}

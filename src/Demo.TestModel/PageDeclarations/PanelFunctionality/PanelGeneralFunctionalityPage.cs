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
namespace Demo.TestModel.PageDeclarations
{
    public class PanelGeneralFunctionalityPage : GeneralHeaderPage
    {
        public PanelGeneralFunctionalityPage()
        {
            expectedUnitTitle = "PANEL ";
        }

        #region WebElements

        #region Panel General locators

        [FindsBy(How = How.CssSelector, Using = @"#unitRefreshBusyButton")]
        protected IWebElement btnRefreshPanel { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".menu .btn")]
        protected IWebElement btnEditPanel { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#unitRemoveBusyButton")]
        protected IWebElement btnRemovePanel { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".txt")]
        protected IWebElement linkStatus { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#unitMaintenanceStatus")]
        protected IWebElement labelOnlineStatus { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#quickUnitNavigation")]
        protected IWebElement blockUnitNavigation { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#dojox_widget_Toaster_2 .dijitToasterContent")]
        protected IWebElement toasterMessage { get; set; }

        //=====================================================================================================
        [FindsBy(How = How.CssSelector, Using = @".unitGeneralMenuGroup:nth-of-type(1) a[href*='general']")]
        protected IWebElement linkGeneral { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".unitGeneralMenuGroup:nth-of-type(1) a[href*='services']")]
        protected IWebElement linkServices { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".unitGeneralMenuGroup:nth-of-type(1) a[href*='location']")]
        protected IWebElement linkLocation { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".unitGeneralMenuGroup:nth-of-type(2) a[href*='diagnostic']")]
        protected IWebElement linkDiagnostics { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".unitGeneralMenuGroup:nth-of-type(2) a[href*='remoteinspection']")]
        protected IWebElement linkRemoteInspections { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".unitGeneralMenuGroup:nth-of-type(2) a[href*='pmaxstate']")]
        protected IWebElement linkSetState { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".unitGeneralMenuGroup:nth-of-type(2) a[href*='pmaxconfig']")]
        protected IWebElement linkSetGetConfiguration { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".unitGeneralMenuGroup:nth-of-type(2) a[href*='locations']")]
        protected IWebElement linkZonesCustomization { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".unitGeneralMenuGroup:nth-of-type(3) a[href*='pmaxlog/standard']")]
        protected IWebElement linkStandardLog { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".unitGeneralMenuGroup:nth-of-type(3) a[href*='pmaxlog/legacy']")]
        protected IWebElement linkLegacyLog { get; set; }
        //===========================================================================================================
        #endregion

        #endregion

        #region Invoke() and IsDisplayed()
        public override void Invoke()
        {
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
        }

        public override void WaitLoadPage()
        {
            Wait.UntilVisible(labelUnitTitle, 20000);
            Wait.UntilDisapear(mainModalDialog, 20000);
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Expected: " + expectedUnitTitle + ", Current: " + CurrentUnitTitle());
            }
        }

        public void RefreshPanelClick()
        {
            Wait.UntilVisible(btnRefreshPanel, 20000);
            btnRefreshPanel.Click();
            Wait.UntilVisible(toasterMessage, 20000);
            string ToasterMassage = toasterMessage.GetElementText();
            if (!ToasterMassage.Contains("task added to queue"))
                throw new NotFoundException("Toaster message uppeared but not matched by 'task added to queue'. Real toaster is '" + ToasterMassage + "'");
        }

        public EditUnitPage EditPanelClick()
        {
            Wait.UntilVisible(btnEditPanel, 20000);
            btnEditPanel.Click();
            EditUnitPage EditUnitPage = new EditUnitPage();
            EditUnitPage.WaitLoadPage();
            return EditUnitPage;
        }

        public void RemovePanelClickYes()
        {
            Wait.UntilVisible(btnRemovePanel, 20000);
            btnRemovePanel.Click();
        }

        public void RemovePanelClickCancel()
        {
            Wait.UntilVisible(btnRemovePanel, 20000);
            btnRemovePanel.Click();
        }

    }
}

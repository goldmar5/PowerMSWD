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
using Demo.TestModel.IPMPpages.PanelFunctionality;
namespace Demo.TestModel.IPMPpages
{
    public class PanelGeneralFunctionalityPage : GeneralHeaderPage
    {       

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

        public override void Open()
        {

        }

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

        public GeneralPage GeneralClick()
        {
            Wait.UntilVisible(linkGeneral, 20000).Click();
            GeneralPage PanelgeneralPage = new GeneralPage();
            PanelgeneralPage.WaitLoadPage();
            return PanelgeneralPage;
        }

        public ServicesPage ServicesClick()
        {
            Wait.UntilVisible(linkServices, 20000).Click();
            ServicesPage ServicesPage = new ServicesPage();
            ServicesPage.WaitLoadPage();
            return ServicesPage;
        }

        public LocationPage LocationClick() 
        {
            Wait.UntilVisible(linkLocation, 20000).Click();
            LocationPage LocationPage = new LocationPage();
            LocationPage.WaitLoadPage();
            return LocationPage;
        }

        public DiagnosticsPage DiagnosticsClick()
        {
            Wait.UntilVisible(linkDiagnostics, 20000).Click();
            DiagnosticsPage DiagnosticsPage = new DiagnosticsPage();
            DiagnosticsPage.WaitLoadPage();
            return DiagnosticsPage;
        }

        public RemoteInspectionsPage RemoteInspectionsClick()
        {
            Wait.UntilVisible(linkRemoteInspections, 20000).Click();
            RemoteInspectionsPage RemoteInspectionsPage = new RemoteInspectionsPage();
            RemoteInspectionsPage.WaitLoadPage();
            return RemoteInspectionsPage;
        }

        public SetStatePage SetStateClick()
        {
            Wait.UntilVisible(linkSetState, 20000).Click();
            SetStatePage SetStatePage = new SetStatePage();
            SetStatePage.WaitLoadPage();
            return SetStatePage;
        }

        public SetGetConfigurationPage SetGetConfigurationClick()
        {
            Wait.UntilVisible(linkSetGetConfiguration, 20000).Click();
            SetGetConfigurationPage SetGetConfigurationPage = new SetGetConfigurationPage();
            SetGetConfigurationPage.WaitLoadPage();
            return SetGetConfigurationPage;
        }

        public ZonesCustomizationPage ZonesCustomizationClick()
        {
            Wait.UntilVisible(linkZonesCustomization, 20000).Click();
            ZonesCustomizationPage ZonesCustomizationPage = new ZonesCustomizationPage();
            ZonesCustomizationPage.WaitLoadPage();
            return ZonesCustomizationPage;
        }

        public StandardLogPage StandardLogClick()
        {
            Wait.UntilVisible(linkStandardLog, 20000).Click();
            StandardLogPage StandardLogPage = new StandardLogPage();
            StandardLogPage.WaitLoadPage();
            return StandardLogPage;
        }

        public LegacyLogPage LegacyLogClick()
        {
            Wait.UntilVisible(linkLegacyLog, 20000).Click();
            LegacyLogPage LegacyLogPage = new LegacyLogPage();
            LegacyLogPage.WaitLoadPage();
            return LegacyLogPage;
        }

        public void RefreshPanelClick()
        {
            Wait.UntilVisible(btnRefreshPanel, 20000).Click();
            ExpectedToaster("task added to queue");
        }

        public EditUnitPage EditPanelClick()
        {
            Wait.UntilVisible(btnEditPanel, 20000).Click();
            EditUnitPage EditUnitPage = new EditUnitPage();
            EditUnitPage.WaitLoadPage();
            return EditUnitPage;
        }

        public void RemovePanelClickYes()
        {
            Wait.UntilVisible(btnRemovePanel, 20000).Click();
            Wait.UntilVisible(modalDialogYes, 20000).Click();
            ExpectedToaster("was deleted successful");
        }

        public void RemovePanelClickCancel()
        {
            Wait.UntilVisible(btnRemovePanel, 20000).Click();
            Wait.UntilVisible(modalDialogCancel, 20000).Click();
        }

    }
}

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
#endregion
#region Usings - WebDriver
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
#endregion
using Demo.TestModel;

namespace Demo.TestModel.IPMPpages
{
    public class PanelsPage : SearchFilterPage
    {
        public PanelsPage()
        {
            expectedCaption = "UNIT LIST";
        }

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = @".panelsSubmenu a:nth-child(1)")]
        protected IWebElement btnAllPanels { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".panelsSubmenu a:nth-child(2)")]
        protected IWebElement btnFaultsMonitoring { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".panelsSubmenu a:nth-child(3)")]
        protected IWebElement btnSuspendedFaults { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".panelsSubmenu a:nth-child(4)")]
        protected IWebElement btnRemoteInspection { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".add")]
        protected IWebElement btnAddUnit { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"[id$=RemoveBusyButton]")]
        protected IWebElement btnRemoveUnit { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"div.section + span")]
        protected IWebElement ddbActions { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".gridCellLink")]
        protected IWebElement linkPanelID { get; set; }

        #endregion

        #region Invoke() and IsDisplayed()
        public override void Invoke()
        {
            var loginPage = GetLoginPage();
            var tycoPage = loginPage.Login();
            tycoPage.Panels();
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
            #region Search and Filters, Caption locators
            VerifyElementVisible("blockFilters", blockFilters);
            VerifyElementVisible("blockSearch", blockSearch);
            VerifyElementVisible("labelCaption", labelCaption);
            #endregion
            VerifyElementVisible("btnAllPanels", btnAllPanels);
            VerifyElementVisible("btnFaultsMonitoring", btnFaultsMonitoring);
            VerifyElementVisible("btnSuspendedFaults", btnSuspendedFaults);
            VerifyElementVisible("btnRemoteInspection", btnRemoteInspection);
            VerifyElementVisible("btnAddUnit", btnAddUnit);
            VerifyElementVisible("btnRemoveUnit", btnRemoveUnit);
            VerifyElementVisible("ddbActions", ddbActions);

            VerifyElementVisible("gridBlockBase", gridBlockBase);
        }

        public FaultsMonitoringPage FaultsMonitoring()
        {
            btnFaultsMonitoring.Click();
            FaultsMonitoringPage FaultsMonitoringPage = new FaultsMonitoringPage();
            FaultsMonitoringPage.WaitLoadPage();
            return FaultsMonitoringPage;
        }

        public SuspendedFaultsPage SuspendedFaults()
        {
            btnSuspendedFaults.Click();
            SuspendedFaultsPage SuspendedFaultsPage = new SuspendedFaultsPage();
            SuspendedFaultsPage.WaitLoadPage();
            return SuspendedFaultsPage;
        }

        public RemoteInspectionPage RemoteInspection()
        {
            btnRemoteInspection.Click();
            RemoteInspectionPage RemoteInspectionPage = new RemoteInspectionPage();
            RemoteInspectionPage.WaitLoadPage();
            return RemoteInspectionPage;
        }

        public AddUnitPage AddUnitClick()
        {
            btnAddUnit.Click();
            AddUnitPage AddUnitPage = new AddUnitPage();
            AddUnitPage.WaitLoadPage();
            return AddUnitPage;
        }

        public void RemoveUnitClick()
        {
            btnRemoveUnit.Click();
        }

        public GeneralPage PanelIDClick()
        {
            Wait.UntilVisible(linkPanelID, 20000);
            linkPanelID.Click();
            GeneralPage PanelGeneralPage = new GeneralPage();
            PanelGeneralPage.WaitLoadPage();
            return PanelGeneralPage;
            //Log.output(Current Page is "expectedUnitTitle");
        }

        public void Search(string SearchText)
        {
            txtSearch.SendKeys(SearchText);
            linkSearch.Click();            
        }
        
    }
}

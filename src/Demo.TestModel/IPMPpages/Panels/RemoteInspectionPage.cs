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
namespace Demo.TestModel.IPMPpages
{
    public class RemoteInspectionPage : SearchFilterPage
    {

        public RemoteInspectionPage()
        {
            expectedCaption = "REMOTE INSPECTION LIST";
        }

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = @"#unitRemoteInspectionScheduleBusyButton")]
        protected IWebElement btnSchedule { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#unitRemoteInspectionInitiateBusyButton")]
        protected IWebElement btnInitiateInspection { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".unitRemoteInspectionFilter")]
        protected IWebElement blockRemoteInspectionFilter { get; set; }

        #endregion

        #region Open() and IsDisplayed()
        public override void Open()
        {
            var loginPage = GetLoginPage();
            var tycoPage = loginPage.Login();
            var panelsPage = tycoPage.Panels();
            panelsPage.RemoteInspection();
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

            #region Search and Filters
            VerifyElementVisible("blockFilters", blockFilters);
            VerifyElementVisible("blockSearch", blockSearch);
            #endregion

            #region Caption locator
            VerifyElementVisible("labelCaption", labelCaption);
            #endregion

            VerifyElementVisible("btnSchedule", btnSchedule);
            VerifyElementVisible("btnInitiateInspection", btnInitiateInspection);
            VerifyElementVisible("blockRemoteInspectionFilter", blockRemoteInspectionFilter);

            VerifyElementVisible("gridBlockBase", gridBlockBase);
        }

        public override void WaitLoadPage()
        {
            Wait.UntilVisible(btnSchedule, 20000);
            Wait.UntilDisapear(mainModalDialog, 20000);
            WaitLoadGrid();
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Expected: " + expectedCaption + ", Current: " + CurrentCaption());
            }
        }
    }
}

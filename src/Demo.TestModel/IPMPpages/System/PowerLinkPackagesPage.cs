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

namespace Demo.TestModel.IPMPpages.System
{
    public class PowerLinkPackagesPage : SearchFilterPage
    {
        public PowerLinkPackagesPage()
        {
            expectedCaption = "SOFTWARE PACKAGE LIST";
            expectedHeadersCount = 4;
        }

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = @"#swupgradeRepoSyncBusyButton")]
        protected IWebElement btnSynchronizeWithRepository { get; set; }

        //[FindsBy(How = How.CssSelector, Using = @".dojoxGridSortNode")]
        //protected IWebElement allHeadersColumn { get; set; }

        #endregion

        #region Open()
        public override void Open()
        {
            var loginPage = GetLoginPage();
            var tycoPage = loginPage.Login();
            var systemPage = tycoPage.System();
            systemPage.PowerLinkPackages();
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

            VerifyElementVisible("gridBlockBase", gridBlockBase);

            VerifyElementVisible("btnSynchronizeWithRepository", btnSynchronizeWithRepository);
        }

        public override void WaitLoadPage()
        {
            Wait.UntilVisible(btnSynchronizeWithRepository, 20000);
            Wait.UntilDisapear(mainModalDialog, 20000);
            WaitLoadGrid();
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Expected: " + expectedCaption + ", Current: " + CurrentCaption() + 
                                                " Exp columns: " + expectedHeadersCount + ", Cur columns: " + CurruntHeadersCount());
            }
        }

        public override bool ItIsYou()
        {
            if (CurrentCaption() == expectedCaption & CurruntHeadersCount() == expectedHeadersCount)
                return true;
            return false;
        }
    }
}
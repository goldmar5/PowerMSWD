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
    public class UserActionLogPage : SearchFilterPage
    {
        public UserActionLogPage()
        {
            expectedCaption = "USER ACTION LOG";
        }

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = @"#useractionloglist")]
        protected IWebElement gridUserActionLogList { get; set; }
        
        #endregion

        #region Open()
        public override void Open()
        {
            var LoginPage = GetLoginPage();
            var tycoPage = LoginPage.Login();
            var systemPage = tycoPage.System();
            systemPage.UserActionLog();
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
            VerifyElementVisible("gridUserActionLogList", gridUserActionLogList);
        }

        public override void WaitLoadPage()
        {
            Wait.UntilVisible(gridUserActionLogList, 20000);
            Wait.UntilDisapear(mainModalDialog, 20000);
            WaitLoadGrid();
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Expected: " + expectedCaption + ", Current: " + CurrentCaption());
            }
        }
    }
}
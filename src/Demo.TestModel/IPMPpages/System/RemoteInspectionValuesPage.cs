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
    public class RemoteInspectionValuesPage : SearchFilterPage
    {
        public RemoteInspectionValuesPage()
        {
            expectedCaption = "REMOTE INSPECTION VALUES";
        }

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = @"#systemRemoteInspectionOptionsBusyButton")]
        protected IWebElement btnSaveChangesRemoteInspectionOptions { get; set; }

        #endregion

        #region Invoke()
        public override void Invoke()
        {
            var LoginPage = GetLoginPage();
            var tycoPage = LoginPage.Login();
            var systemPage = tycoPage.System();
            systemPage.RemoteInspectionValues();
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

            VerifyElementVisible("btnSaveChangesRemoteInspectionOptions", btnSaveChangesRemoteInspectionOptions);

        }

        public override void WaitLoadPage()
        {
            Wait.UntilVisible(btnSaveChangesRemoteInspectionOptions, 20000);
            Wait.UntilDisapear(mainModalDialog, 20000);
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Expected: " + expectedCaption + ", Current: " + CurrentCaption());
            }
        }
    }
}


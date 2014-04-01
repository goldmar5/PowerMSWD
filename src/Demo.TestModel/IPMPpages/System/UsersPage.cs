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
    public class UsersPage : SearchFilterPage
    {
        public UsersPage()
        {
            expectedCaption = "USER LIST";
        }

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = @".add")]
        protected IWebElement btnAddUser { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#userRemoveBusyButton")]
        protected IWebElement btnRemoveUser { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#userSuspendBusyButton")]
        protected IWebElement btnToggleSuspendUser { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".gridCellLink")]
        protected IWebElement linkEditUser { get; set; }

        #endregion

        #region Invoke()
        public override void Invoke()
        {
            var loginPage = GetLoginPage();
            var tycoPage = loginPage.Login();
            var systemPage = tycoPage.System();
            systemPage.Users();
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

            VerifyElementVisible("btnAddUser", btnAddUser);
            VerifyElementVisible("btnRemoveUser", btnRemoveUser);
            VerifyElementVisible("btnToggleSuspendUser", btnToggleSuspendUser);
            VerifyElementVisible("linkEditUser", linkEditUser);
        }

        public override void WaitLoadPage()
        {
            Wait.UntilVisible(btnAddUser, 20000);
            Wait.UntilDisapear(mainModalDialog, 20000);
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Expected: " + expectedCaption + ", Current: " + CurrentCaption());
            }
        }

        public AddUserPage AddUserClick()
        {
            btnAddUser.Click();            
            AddUserPage AddUserPage = new AddUserPage();
            AddUserPage.WaitLoadPage();
            return AddUserPage;
        }

        public EditUserPage EditUserClick()
        {
            Wait.UntilVisible(linkEditUser, 20000);
            linkEditUser.Click();
            EditUserPage EditUserPage = new EditUserPage();
            EditUserPage.WaitLoadPage();
            return EditUserPage;
        }
    }
}

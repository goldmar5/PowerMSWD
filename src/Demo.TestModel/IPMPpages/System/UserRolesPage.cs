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
    public class UserRolesPage : SearchFilterPage
    {
        public UserRolesPage()
        {
            expectedCaption = "ROLE LIST";
        }

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = @".add")]
        protected IWebElement btnAddRole { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#roleRemoveBusyButton")]
        protected IWebElement btnRemoveRole { get; set; }

        #endregion

        #region Open()
        public override void Open()
        {
            var loginPage = GetLoginPage();
            var tycoPage = loginPage.Login();
            var systemPage = tycoPage.System();
            systemPage.UserRoles();
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

            VerifyElementVisible("btnAddRole", btnAddRole);
            VerifyElementVisible("btnRemoveRole", btnRemoveRole);
            VerifyElementVisible("linkEditRole", gridLink);
        }

        public override void WaitLoadPage()
        {
            Wait.UntilVisible(btnAddRole, 20000);
            Wait.UntilDisapear(mainModalDialog, 20000);
            WaitLoadGrid();
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Expected: " + expectedCaption + ", Current: " + CurrentCaption());
            }
        }

        public AddUserRolePage AddRoleClick()
        {
            btnAddRole.Click();
            AddUserRolePage AddUserRolePage = new AddUserRolePage();
            AddUserRolePage.WaitLoadPage();
            return AddUserRolePage;
        }

        public void RemoveRoleClick()
        {
            Wait.UntilVisible(btnRemoveRole, 20000);
            btnRemoveRole.Click();
        }

        public EditUserRolePage EditRoleClick()
        {
            Wait.UntilVisible(gridLink, 20000);
            gridLink.Click();
            EditUserRolePage EditUserRolePage = new EditUserRolePage();
            EditUserRolePage.WaitLoadPage();
            return EditUserRolePage;
        }
    }
}
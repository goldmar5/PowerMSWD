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
namespace Demo.TestModel.PageDeclarations
{
    public class AddUserPage : AddEditBasePage
    {

        public AddUserPage()
        {
            expectedCaption = "ADD USER";
        }

        #region WebElements        

        [FindsBy(How = How.CssSelector, Using = @"#userAddBusyButtonTop")]
        protected IWebElement btnSaveChangesAddUserTop { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#userAddBusyButtonBottom")]
        protected IWebElement btnSaveChangesAddUserBottom { get; set; }

        #endregion

        #region Invoke()
        public override void Invoke()
        {
            var LoginPage = GetLoginPage();
            var tycoPage = LoginPage.Login();
            var systemPage = tycoPage.System();
            var usersPage = systemPage.Users();
            usersPage.AddUserClick();
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

            #region Caption locator
            VerifyElementVisible("labelCaption", labelCaption);
            #endregion

            #region Add Edit Page locators
            VerifyElementVisible("labelStayOnPage", labelStayOnPage);
            VerifyElementVisible("checkboxStayOnPageTop", checkboxStayOnPageTop);
            VerifyElementVisible("checkboxStayOnPageBottom", checkboxStayOnPageBottom);
            VerifyElementVisible("btnSaveChangesTop", btnSaveChangesAddUserTop);
            VerifyElementVisible("btnSaveChangesBottom", btnSaveChangesAddUserBottom);
            VerifyElementVisible("btnDiscardChanges", btnDiscardChanges);
            VerifyElementVisible("addEditGrid", addEditGrid);
            VerifyElementVisible("pagePathNextToCaption", pagePathNextToCaption);
            #endregion
        }

        public override void WaitLoadPage()
        {
            Wait.UntilVisible(btnSaveChangesAddUserTop, 20000);
            Wait.UntilDisapear(mainModalDialog, 20000);
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Expected: " + expectedCaption + ", Current: " + CurrentCaption());
            }
        }
    }
}


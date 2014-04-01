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
    public class EditUserRolePage : AddEditBasePage
    {

        public EditUserRolePage()
        {
            expectedCaption = "EDIT ROLE";
        }

        #region WebElements        

        [FindsBy(How = How.CssSelector, Using = @"#roleEditBusyButtonTop")]
        protected IWebElement btnSaveChangesEditRoleTop { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#roleEditBusyButtonBottom")]
        protected IWebElement btnSaveChangesEditRoleBottom { get; set; }

        #endregion

        #region Invoke()
        public override void Invoke()
        {
            var LoginPage = GetLoginPage();
            var tycoPage = LoginPage.Login();
            var systemPage = tycoPage.System();
            var userRolePage = systemPage.UserRoles();
            userRolePage.EditRoleClick();
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
            VerifyElementVisible("btnSaveChangesTop", btnSaveChangesEditRoleTop);
            VerifyElementVisible("btnSaveChangesBottom", btnSaveChangesEditRoleBottom);
            VerifyElementVisible("btnDiscardChanges", btnDiscardChanges);
            VerifyElementVisible("addEditGrid", addEditGrid);
            VerifyElementVisible("pagePathNextToCaption", pagePathNextToCaption);
            #endregion
        }

        public override void WaitLoadPage()
        {
            Wait.UntilVisible(btnSaveChangesEditRoleTop, 20000);
            Wait.UntilDisapear(mainModalDialog, 20000);
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Expected: " + expectedCaption + ", Current: " + CurrentCaption());
            }
        }
    }
}




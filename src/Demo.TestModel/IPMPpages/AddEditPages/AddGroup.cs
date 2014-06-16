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
    public class AddGroup : AddEditBasePage
    {

        public AddGroup()
        {
            expectedCaption = "ADD UNIT GROUP";
        }

        #region WebElements        

        [FindsBy(How = How.CssSelector, Using = @"#groupAddBusyButtonTop")]
        protected IWebElement btnSaveChangesAddGroupTop { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#groupAddBusyButtonBottom")]
        protected IWebElement btnSaveChangesAddGroupBottom { get; set; }

        #endregion

        #region Open()
        public override void Open()
        {            
            var loginPage = GetLoginPage();
            var tycoPage = loginPage.Login();
            var groupPage = tycoPage.Groups();
            groupPage.AddGroupClick();
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
            VerifyElementVisible("btnSaveChangesTop", btnSaveChangesAddGroupTop);
            VerifyElementVisible("btnSaveChangesBottom", btnSaveChangesAddGroupBottom);
            VerifyElementVisible("btnDiscardChanges", btnDiscardChanges);
            VerifyElementVisible("addEditGrid", addEditGrid);
            VerifyElementVisible("pagePathNextToCaption", pagePathNextToCaption);
            #endregion
        }

        public override void WaitLoadPage()
        {
            Wait.UntilVisible(btnSaveChangesAddGroupTop, 20000);
            Wait.UntilDisapear(mainModalDialog, 20000);
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Expected: " + expectedCaption + ", Current: " + CurrentCaption());
            }
        }
    }
}



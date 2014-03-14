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
    public class GroupPage : MyPageBase
    {
        #region WebElements

        #region Search and Filters

        [FindsBy(How = How.CssSelector, Using = @".panel")]
        protected IWebElement blockFilters { get; set; }


        [FindsBy(How = How.CssSelector, Using = @".search")]
        protected IWebElement blockSearch { get; set; }

        #endregion

        [FindsBy(How = How.CssSelector, Using = @".add")]
        protected IWebElement btnAddGroup { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#unitRemoveBusyButton")]
        protected IWebElement btnRemoveGroup { get; set; }

        #endregion

        #region Invoke() and IsDisplayed()
        public override void Invoke()
        {
            var LoginPage = new LoginPage();
            var tycoPage = LoginPage.Login();
            tycoPage.WaitLoadPage();
            var GroupsPage = tycoPage.Groups();
            if (!GroupsPage.WaitLoadPage())
                throw new NotFoundException();
        }

        public override bool IsDisplayed()
        {
            throw new NotImplementedException();
            return true;
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
            VerifyElementVisible("textVersion", textVersion);
            VerifyElementVisible("textCurrentUser", textCurrentUser);
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

            VerifyElementVisible("btnAddGroup", btnAddGroup);
            VerifyElementVisible("btnRemoveGroup", btnRemoveGroup);
        }

        public bool WaitLoadPage()
        {
            Wait.UntilVisible(labelCaption, 10000);
            string pageName = WhoAreYouPage();
            Wait.UntilDisapear(mainModalDialog, 15000);

            if (pageName == "UNIT GROUP LIST")
                return true;
            else
                return false;
        }
    }
}

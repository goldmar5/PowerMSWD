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
using Demo.TestModel;

namespace Demo.TestModel.IPMPpages
{
    public class GroupPage : SearchFilterPage
    {
        public GroupPage()
        {
            expectedCaption = "UNIT GROUP LIST";
        }

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = @".add")]
        protected IWebElement btnAddGroup { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#unitRemoveBusyButton")]
        protected IWebElement btnRemoveGroup { get; set; }

        #endregion

        #region Open() and IsDisplayed()
        public override void Open()
        {
            var loginPage = GetLoginPage();
            var tycoPage = loginPage.Login();
            tycoPage.Groups();
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

            VerifyElementVisible("btnAddGroup", btnAddGroup);
            VerifyElementVisible("btnRemoveGroup", btnRemoveGroup);

            VerifyElementVisible("gridBlockBase", gridBlockBase);
        }

        public AddGroup AddGroupClick()
        {
            btnAddGroup.Click();
            AddGroup AddGroup = new AddGroup();
            AddGroup.WaitLoadPage();
            return AddGroup;
        }

        public EditGroup EditGroupClick()
        {
            Wait.UntilVisible(gridLink, 20000).Click();
            EditGroup EditGroup = new EditGroup();
            EditGroup.WaitLoadPage();
            return EditGroup;
        }

        public void RemoveGroupClickYes()
        {
            Wait.UntilVisible(btnRemoveGroup, 20000).Click();
            Wait.UntilVisible(modalDialogYes, 20000).Click();
            ExpectedToaster("was deleted successful");
        }

        public void RemoveGroupClickCancel()
        {
            Wait.UntilVisible(btnRemoveGroup, 20000).Click();
            Wait.UntilVisible(modalDialogCancel, 20000).Click();
        }
    }
}

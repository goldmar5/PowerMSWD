﻿#region Usings - System
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

namespace Demo.TestModel.PageDeclarations.System
{
    public class PowerMaxPackagesPage : SearchFilterPage
    {
        public PowerMaxPackagesPage()
        {
            expectedCaption = "SOFTWARE PACKAGE LIST";
        }

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = @"#swupgradeRepoSyncBusyButton")]
        protected IWebElement btnSynchronizeWithRepository { get; set; }

        #endregion

        #region Invoke()
        public override void Invoke()
        {
            var loginPage = GetLoginPage();
            var tycoPage = loginPage.Login();
            var systemPage = tycoPage.System();
            systemPage.PowerMaxPackages();
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
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Expected: " + expectedCaption + ", Current: " + CurrentCaption());
            }
        }
    }
}
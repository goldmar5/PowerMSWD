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
    public class SuspendedFaultsPage : SearchFilterPage
    {
        #region WebElements

        [FindsBy(How = How.CssSelector, Using = @"#unitReassignBusyButton")]
        protected IWebElement btnReassign { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#unitResumeFaultsBusyButton")]
        protected IWebElement btnResumeFaults { get; set; }

        #endregion

        #region Invoke() and IsDisplayed()
        public override void Invoke()
        {
            var LoginPage = new LoginPage();
            var tycoPage = LoginPage.Login();
            tycoPage.WaitLoadPage();
            var PanelsPage = tycoPage.Panels();
            PanelsPage.WaitLoadPage();
            var SuspendedFaults = PanelsPage.SuspendedFaults();
            SuspendedFaults.WaitLoadPage();
        }

        public override bool IsDisplayed()
        {
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

            VerifyElementVisible("btnReassign", btnReassign);
            VerifyElementVisible("btnResumeFaults", btnResumeFaults);
        }
    }
}

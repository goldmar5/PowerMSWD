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
    public class LogoutMenuPage : GeneralHeaderPage
    {
        #region WebElements

        [FindsBy(How = How.CssSelector, Using = @"#logout_alink")]
        protected IWebElement linkFullLogout { get; set; }

        #endregion

        #region Invoke() and IsDisplayed()
        public override void Invoke()
        {
            var LoginPage = new LoginPage();
            var tycoPage = LoginPage.Login();
            tycoPage.WaitLoadPage();
            var LogoutPage = tycoPage.Logout();
            LogoutPage.WaitLoadPage();
        }

        public override bool IsDisplayed()
        {
            return SwdBrowser.Driver.PageSource.Contains(@"class='caption'>Logout Menu");
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

            VerifyElementVisible("linkFullLogout", linkFullLogout);
        }

        public void FullLogout()
        {
            linkFullLogout.Click();
        }
    }
}
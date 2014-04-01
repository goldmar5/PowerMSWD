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
    public class LogoTycoPage : GeneralHeaderPage
    {
        #region WebElements

        [FindsBy(How = How.CssSelector, Using = @".welcome")]
        protected IWebElement imgWelcome { get; set; }

        #endregion

        #region Invoke() and IsDisplayed()
        public override void Invoke()
        {
            var LoginPage = GetLoginPage();
            LoginPage.Login();
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
            VerifyElementVisible("imgWelcome", imgWelcome);
        }

        public override void WaitLoadPage()
        {
            Wait.UntilVisible(imgWelcome, 20000);
            Wait.UntilDisapear(mainModalDialog, 15000);
            if (this.ItIsYou())
            {
                throw new NoSuchElementException("LogoTycoPage didn't appear as expected");
            }
        }

        public override bool ItIsYou()
        {
            if (imgWelcome.Displayed)
                return false;
            return true;
        }
    }
}
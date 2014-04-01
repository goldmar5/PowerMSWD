#region Usings - System
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
#endregion
#region Usings - SWD
using Swd.Core;
using Swd.Core.Pages;
using Swd.Core.WebDriver;
using Swd.Core.Configuration;
#endregion
#region Usings - WebDriver
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
#endregion
namespace Demo.TestModel.PageDeclarations
{
    public class LoginPage : BasePage
    {      

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = @".loginContent")]
        protected IWebElement containerLogin { get; set; }

        [FindsBy(How = How.XPath, Using = @"id(""dijit_form_ValidationTextBox_0"")")]
        protected IWebElement txtLogin { get; set; }


        [FindsBy(How = How.XPath, Using = @"id(""dijit_form_ValidationTextBox_1"")")]
        protected IWebElement txtPassword { get; set; }


        [FindsBy(How = How.XPath, Using = @"id(""dijit_form_Button_0"")")]
        protected IWebElement buttonLogIn { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#loginform .link")]
        protected IWebElement linkForgot { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".messageContainer.errorMessage")]
        protected IWebElement labelInvalidEmailPass { get; set; }

        #endregion

        #region Invoke() and IsDisplayed()
        public override void Invoke()
        {            
            var loginPage = new LoginPage();
            SwdBrowser.Driver.Url = Config.applicationMainUrl;
            loginPage.WaitLoadPage();
        }

        #endregion

        public override void VerifyExpectedElementsAreDisplayed()
        {
            VerifyElementVisible("containerLogin", containerLogin);
            VerifyElementVisible("txtLogin", txtLogin);
            VerifyElementVisible("txtPassword", txtPassword);
            VerifyElementVisible("buttonLogIn", buttonLogIn);
            VerifyElementVisible("linkForgot", linkForgot);
        }

        public bool ItIsYou()
        {
            if (containerLogin.Displayed)
                return true;
            return false;
        }

        public void WaitLoadPage()
        {
            Wait.UntilVisible(containerLogin, 20000);
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Something gone wrong. it's not a loginPage");
            }
        }

        public LogoTycoPage Login()
        {
            txtLogin.SendKeys(Config.applicationUserLogin);
            txtPassword.SendKeys(Config.applicationUserPassword);
            buttonLogIn.Click();
            for (int i = 0; i < 50; i++)
            {
                if (labelInvalidEmailPass.IsDisplayedSafe())
                    throw new ApplicationException("Invalid Email or Password");
                Thread.Sleep(100);
            }            
            var logoTycoPage = new LogoTycoPage();
            logoTycoPage.WaitLoadPage();
            return logoTycoPage;
        }
    }
}
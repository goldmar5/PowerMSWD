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
using Swd.Core.Configuration;
#endregion
#region Usings - WebDriver
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
#endregion
namespace Demo.TestModel.PageDeclarations
{
    public class LoginPage : MyPageBase
    {
        #region WebElements

        [FindsBy(How = How.XPath, Using = @"id(""dijit_form_ValidationTextBox_0"")")]
        protected IWebElement txtLogin { get; set; }


        [FindsBy(How = How.XPath, Using = @"id(""dijit_form_ValidationTextBox_1"")")]
        protected IWebElement txtPassword { get; set; }


        [FindsBy(How = How.XPath, Using = @"id(""dijit_form_Button_0"")")]
        protected IWebElement buttonLogIn { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#loginform .link")]
        protected IWebElement linkForgot { get; set; }

        #endregion

        #region Invoke() and IsDisplayed()
        public override void Invoke()
        {
            SwdBrowser.Driver.Url = Config.applicationMainUrl;
        }

        public override bool IsDisplayed()
        {
            return SwdBrowser.Driver.Url.Contains(@"212.90.164");
        }
        #endregion

        public override void VerifyExpectedElementsAreDisplayed()
        {
            VerifyElementVisible("txtLogin", txtLogin);
            VerifyElementVisible("txtPassword", txtPassword);
            VerifyElementVisible("buttonLogIn", buttonLogIn);
            VerifyElementVisible("linkForgot", linkForgot);
        }        

        public TycoPowerManagePage Login()
        {
            MyPages.LoginPage.Invoke();
            txtLogin.SendKeys("admin@visonic.com");
            txtPassword.SendKeys("Admin123");
            buttonLogIn.Click();
            return new TycoPowerManagePage();
        }
    }
}
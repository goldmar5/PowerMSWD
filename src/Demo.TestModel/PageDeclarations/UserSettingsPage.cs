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
    public class UserSettingsPage : GeneralHeaderPage
    {

        public UserSettingsPage()
        {
            expectedCaption = "SETTINGS MENU";
        }

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = @"#usr_phone")]
        protected IWebElement txtUsr_phone { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#coy_id")]
        protected IWebElement txtCountry { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#newpassword")]
        protected IWebElement txtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#confirmpassword")]
        protected IWebElement txtConfirmPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#text")]
        protected IWebElement labelStayOnPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#stayOnPageTop")]
        protected IWebElement checkboxStayOnPageTop { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#stayOnPageBottom")]
        protected IWebElement checkboxStayOnPageBottom { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#settingsMenuBusyButtonTop")]
        protected IWebElement btnSaveChangesTop { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#settingsMenuBusyButtonBottom")]
        protected IWebElement btnSaveChangesBottom { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"[class*=subTitle] .btnSimple")]
        protected IWebElement btnDiscardChanges { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".label.required")]
        protected IWebElement labelPhone { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#coy_id_label")]
        protected IWebElement labelCountry { get; set; }

        #endregion

        #region Invoke() and IsDisplayed()
        public override void Invoke()
        {
            var LoginPage = GetLoginPage();
            var tycoPage = LoginPage.Login();
            var UserSettingsPage = tycoPage.Settings();
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

            VerifyElementVisible("txtUsr_phone", txtUsr_phone);
            VerifyElementVisible("txtCountry", txtCountry);
            VerifyElementVisible("txtPassword", txtPassword);
            VerifyElementVisible("txtConfirmPassword", txtConfirmPassword);
            VerifyElementVisible("labelStayOnPage", labelStayOnPage);
            VerifyElementVisible("checkboxStayOnPageTop", checkboxStayOnPageTop);
            VerifyElementVisible("checkboxStayOnPageBottom", checkboxStayOnPageBottom);
            VerifyElementVisible("btnSaveChangesTop", btnSaveChangesTop);
            VerifyElementVisible("btnSaveChangesBottom", btnSaveChangesBottom);
            VerifyElementVisible("btnDiscardChanges", btnDiscardChanges);
            VerifyElementVisible("labelPhone", labelPhone);
            VerifyElementVisible("labelCountry", labelCountry);
        }
    }
}

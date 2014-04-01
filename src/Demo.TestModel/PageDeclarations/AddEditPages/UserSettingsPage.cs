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
    public class UserSettingsPage : AddEditBasePage
    {

        public UserSettingsPage()
        {
            expectedCaption = "SETTINGS MENU";
        }

        #region WebElements   

        [FindsBy(How = How.CssSelector, Using = @"#settingsMenuBusyButtonTop")]
        protected IWebElement btnSaveChangesSettingsMenuTop { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#settingsMenuBusyButtonBottom")]
        protected IWebElement btnSaveChangesSettingsMenuBottom { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#usr_phone")]
        protected IWebElement txtUsr_phone { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#coy_id")]
        protected IWebElement txtCountry { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#newpassword")]
        protected IWebElement txtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#confirmpassword")]
        protected IWebElement txtConfirmPassword { get; set; }

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
            tycoPage.Settings();
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
            VerifyElementVisible("btnSaveChangesTop", btnSaveChangesSettingsMenuTop);
            VerifyElementVisible("btnSaveChangesBottom", btnSaveChangesSettingsMenuBottom);
            VerifyElementVisible("btnDiscardChanges", btnDiscardChanges);
            VerifyElementVisible("addEditGrid", addEditGrid);
            VerifyElementVisible("pagePathNextToCaption", pagePathNextToCaption);
            #endregion

            VerifyElementVisible("txtUsr_phone", txtUsr_phone);
            VerifyElementVisible("txtCountry", txtCountry);
            VerifyElementVisible("txtPassword", txtPassword);
            VerifyElementVisible("txtConfirmPassword", txtConfirmPassword);
            VerifyElementVisible("labelPhone", labelPhone);
            VerifyElementVisible("labelCountry", labelCountry);
        }

        public override void WaitLoadPage()
        {
            Wait.UntilVisible(btnSaveChangesSettingsMenuTop, 20000);
            Wait.UntilDisapear(mainModalDialog, 20000);
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Expected: " + expectedCaption + ", Current: " + CurrentCaption());
            }
        }
    }
}

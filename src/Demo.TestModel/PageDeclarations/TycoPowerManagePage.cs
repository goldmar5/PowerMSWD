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
    public class TycoPowerManagePage : MyPageBase
    {
        #region WebElements

        [FindsBy(How = How.CssSelector, Using = @"#menuItem_units_all a")]
        protected IWebElement tabPanels { get; set; }


        [FindsBy(How = How.CssSelector, Using = @"#menuItem_group a")]
        protected IWebElement tabGroups { get; set; }


        [FindsBy(How = How.CssSelector, Using = @"#menuItem_event a")]
        protected IWebElement tabEvents { get; set; }


        [FindsBy(How = How.CssSelector, Using = @"#menuItem_process a")]
        protected IWebElement tabProcesses { get; set; }


        [FindsBy(How = How.CssSelector, Using = @"#menuItem_system a")]
        protected IWebElement tabSystem { get; set; }


        [FindsBy(How = How.CssSelector, Using = @".productVersion")]
        protected IWebElement textVersion { get; set; }


        [FindsBy(How = How.CssSelector, Using = @"#userImploadName")]
        protected IWebElement textCurrentUser { get; set; }


        [FindsBy(How = How.CssSelector, Using = @"#app_layout_AnimatedLink_0")]
        protected IWebElement linkSettings { get; set; }


        [FindsBy(How = How.CssSelector, Using = @"#app_layout_AnimatedLink_1")]
        protected IWebElement linkLogout { get; set; }


        [FindsBy(How = How.CssSelector, Using = @".help")]
        protected IWebElement linkHelp { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".welcome")]
        protected IWebElement imgWelcome { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#mainModalDialog")]
        protected IWebElement mainModalDialog { get; set; }

        #endregion

        #region Invoke() and IsDisplayed()
        public override void Invoke()
        {
            var LoginPage = new ipmpLoginPage();
            var tycoPage = LoginPage.Login();
            tycoPage.WaitLoadPage();
        }

        public override bool IsDisplayed()
        {
            return SwdBrowser.Driver.PageSource.Contains("class='welcome'");
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
            VerifyElementVisible("imgWelcome", imgWelcome);
        }

        public void WaitLoadPage()
        {
            Wait.UntilVisible(imgWelcome, 10000);
            Wait.UntilDisapear(mainModalDialog, 15000);
        }

        public UnitListPage Panels()
        {
            tabPanels.Click();
            return new UnitListPage();
        }

        public GroupPage Groups()
        {
            tabGroups.Click();
            return new GroupPage();
        }

        public EventsPage Events()
        {
            tabEvents.Click();
            return new EventsPage();
        }

        public ProcessesPage Processes()
        {
            tabProcesses.Click();
            return new ProcessesPage();
        }

        public SystemPage System()
        {
            tabSystem.Click();
            return new SystemPage();
        }

        public LogoutMenuPage Logout()
        {
            linkLogout.Click();
            return new LogoutMenuPage();
        }
    }
}
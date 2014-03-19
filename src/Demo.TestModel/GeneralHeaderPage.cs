using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Swd.Core;
using Swd.Core.Pages;
using OpenQA.Selenium;
using Demo.TestModel.PageDeclarations;
using OpenQA.Selenium.Support.PageObjects;
using Swd.Core.WebDriver;

namespace Demo.TestModel
{
    public abstract class GeneralHeaderPage : BasePage
    {
        public string caption;

        #region WebElements

        #region General Header WebElements

        [FindsBy(How = How.CssSelector, Using = @".Header.clear")]
        protected IWebElement classHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".Title.clear")]
        protected IWebElement classTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".logoTyco")]
        protected IWebElement tabLogoTyco { get; set; }

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
        protected IWebElement labelVersion { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#userImploadName")]
        protected IWebElement labelCurrentUser { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#app_layout_AnimatedLink_0")]
        protected IWebElement linkSettings { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#app_layout_AnimatedLink_1")]
        protected IWebElement linkLogout { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".help")]
        protected IWebElement linkHelp { get; set; }
        #endregion

        #region Caption and mainModalDialog

        [FindsBy(How = How.CssSelector, Using = @"#mainModalDialog")]
        protected IWebElement mainModalDialog { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".caption")]
        protected IWebElement labelCaption { get; set; }

        #endregion

        #endregion      

        public string GetCaption()
        {
            return labelCaption.GetElementText();
        }

        public virtual bool ItIsYou()
        {
            if (GetCaption() == caption)
                return true;
            else
                return false;
        }

        public virtual void WaitLoadPage()
        {
            Wait.UntilVisible(labelCaption, 20000);
            Wait.UntilDisapear(mainModalDialog, 20000);
        }

        public LogoTycoPage LogoTyco()
        {
            tabLogoTyco.Click();
            return new LogoTycoPage();
        }

        public PanelsPage Panels()
        {
            tabPanels.Click();
            return new PanelsPage();
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

        public UserSettingsPage Settings()
        {
            linkSettings.Click();
            return new UserSettingsPage();
        }

        public LogoutMenuPage Logout()
        {
            linkLogout.Click();
            return new LogoutMenuPage();
        }

        public void Help()
        {
            linkHelp.Click();
        }
    }
}



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
        public string expectedCaption;

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

        public string CurrentCaption()
        {
            return labelCaption.GetElementText();
        }

        public virtual bool ItIsYou()
        {
            if (CurrentCaption() == expectedCaption)
                return true;
            return false;
        }

        public virtual void WaitLoadPage()
        {
            Wait.UntilDisapear(mainModalDialog, 20000);
            Wait.UntilVisible(labelCaption, 20000);
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Expected: " + expectedCaption + ", Current: " + CurrentCaption());
            }
        }

        public LogoTycoPage LogoTyco()
        {
            tabLogoTyco.Click();
            LogoTycoPage LogoTycoPage = new LogoTycoPage();
            LogoTycoPage.WaitLoadPage();
            return LogoTycoPage;
        }

        public PanelsPage Panels()
        {
            tabPanels.Click();
            PanelsPage panelPage = new PanelsPage();
            panelPage.WaitLoadPage();
            return panelPage;
        }

        public GroupPage Groups()
        {
            tabGroups.Click();
            GroupPage GroupPage = new GroupPage();
            GroupPage.WaitLoadPage();
            return GroupPage;            
        }

        public EventsPage Events()
        {
            tabEvents.Click();
            EventsPage EventsPage = new EventsPage();
            EventsPage.WaitLoadPage();
            return EventsPage;
        }

        public ProcessesPage Processes()
        {
            tabProcesses.Click();
            ProcessesPage ProcessesPage = new ProcessesPage();
            ProcessesPage.WaitLoadPage();
            return ProcessesPage;
        }

        public SystemPage System()
        {
            tabSystem.Click();
            SystemPage SystemPage = new SystemPage();
            SystemPage.WaitLoadPage();
            return SystemPage;
        }

        public UserSettingsPage Settings()
        {
            linkSettings.Click();
            UserSettingsPage UserSettingsPage = new UserSettingsPage();
            UserSettingsPage.WaitLoadPage();
            return UserSettingsPage;
        }

        public LogoutMenuPage Logout()
        {
            linkLogout.Click();
            LogoutMenuPage logoutPage = new LogoutMenuPage();
            logoutPage.WaitLoadPage();
            return logoutPage;
        }

        public void Help()
        {
            linkHelp.Click();
        }
    }
}



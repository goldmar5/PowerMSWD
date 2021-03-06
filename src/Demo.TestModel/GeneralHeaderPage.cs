﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Swd.Core;
using Swd.Core.Pages;
using OpenQA.Selenium;
using Demo.TestModel.IPMPpages;
using OpenQA.Selenium.Support.PageObjects;
using Swd.Core.WebDriver;

namespace Demo.TestModel
{
    public class GeneralHeaderPage : BasePage
    {
        public string expectedCaption;
        public string expectedUnitTitle;
        public string expectedPanelFunctionalityPage;
        public int expectedHeadersCount;

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

        [FindsBy(How = How.CssSelector, Using = @"#app_layout_AnimatedLink_2")]
        protected IWebElement linkHelp { get; set; }
        #endregion

        #region Caption and mainModalDialog

        [FindsBy(How = How.CssSelector, Using = @"#mainModalDialog")]
        protected IWebElement mainModalDialog { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".caption")]
        protected IWebElement labelCaption { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".unitTitle")]
        protected IWebElement labelUnitTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".selected")]
        protected IWebElement selectedPanelFunctionalityPage { get; set; }

        #endregion

        [FindsBy(How = How.CssSelector, Using = @"#dojox_widget_Toaster_2 .dijitToasterContent")]
        protected IWebElement toasterMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".dojoxGridLoading")]
        protected IWebElement GridLoading { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".dojoxGridMasterMessages")]
        protected IWebElement NoDataFoundMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".gridCellLink")]
        protected IWebElement gridLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#modalDialogConfirm")]
        protected IWebElement modalDialogYes { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#modalDialogCancel")]
        protected IWebElement modalDialogCancel { get; set; }

        #endregion

        public override void Open()
        {

        }
        public override void VerifyExpectedElementsAreDisplayed()
        {
            
        }

        public void WaitLoadGrid()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(500);
                    if (GridLoading.Enabled | GridLoading.Displayed)
                        Thread.Sleep(500);
                    if (gridLink.Displayed)
                        break;
                    if (NoDataFoundMessage.Displayed)
                        break;
                }
            }
            catch (NoSuchElementException)
            {
            }
            catch (StaleElementReferenceException)
            {
            }
        }

        public string CurrentCaption()
        {
            return labelCaption.GetElementText();
        }

        public string CurrentUnitTitle()
        {
            return labelUnitTitle.GetElementText();
        }

        public int CurruntHeadersCount()
        {
            return Driver.FindElements(By.CssSelector(".dojoxGridSortNode")).Count;
        }

        public string currentPanelFunctionalityPage()
        {
            return selectedPanelFunctionalityPage.GetElementText();
        }

        public virtual bool ItIsYou()
        {
            if (CurrentCaption() == expectedCaption)
                return true;
            if (CurrentUnitTitle().Contains(expectedUnitTitle) & (currentPanelFunctionalityPage() == expectedPanelFunctionalityPage))
                return true;
            return false;
        }

        public virtual void WaitLoadPage()
        {
            Wait.UntilVisible(labelCaption, 20000);
            Wait.UntilDisapear(mainModalDialog, 20000);
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

        public void ExpectedToaster(string expectedToasterText)
        {
            Wait.UntilVisible(toasterMessage, 20000);
            string ToasterMassage = toasterMessage.GetElementText();
            if (ToasterMassage.Contains(expectedToasterText))
                Console.WriteLine("Toaster message '" + ToasterMassage + "' matched to expected '" + expectedToasterText + "'");
            //LOG.("Toaster message '" + ToasterMassage + "' matched to expected '" + expectedToasterText + "'");
            else
                throw new NotFoundException("Toaster message uppeared but not matched by '" + expectedToasterText + "'. Real toaster is '" + ToasterMassage + "'");

        }
    }
}



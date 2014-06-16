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
using Demo.TestModel.IPMPpages;

namespace Demo.TestModel
{
    public class SearchFilterPage : GeneralHeaderPage
    {
        #region WebElements

        #region Search and Filters

        [FindsBy(How = How.CssSelector, Using = @".panel")]
        protected IWebElement blockFilters { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".search")]
        protected IWebElement blockSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#searchField")]
        protected IWebElement txtSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".search>a")]
        protected IWebElement linkSearch { get; set; }

        #endregion
        
        [FindsBy(How = How.CssSelector, Using = @".block")]
        protected IWebElement gridBlockBase { get; set; }

        #endregion

        #region Open() and IsDisplayed()
        public override void Open()
        {
            
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

            #region Search and Filters
            VerifyElementVisible("blockFilters", blockFilters);
            VerifyElementVisible("blockSearch", blockSearch);
            #endregion

            #region Caption locator
            VerifyElementVisible("labelCaption", labelCaption);
            #endregion

            VerifyElementVisible("gridBlockBase", gridBlockBase);
        }

        public override void WaitLoadPage()
        {
            Wait.UntilVisible(labelCaption, 20000);
            Wait.UntilDisapear(mainModalDialog, 20000);
            WaitLoadGrid();
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Expected: " + expectedCaption + ", Current: " + CurrentCaption());
            }
        }
    }
}

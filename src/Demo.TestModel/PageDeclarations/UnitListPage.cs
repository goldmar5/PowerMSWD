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
    public class UnitListPage : MyPageBase
    {
        #region WebElements

        #region General Header WebElements
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
#endregion

        #region Search and Filters, Caption

        [FindsBy(How = How.CssSelector, Using = @".panel")]
        protected IWebElement blockFilters { get; set; }


        [FindsBy(How = How.CssSelector, Using = @".search")]
        protected IWebElement blockSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".caption")]
        protected IWebElement labelCaption { get; set; }

        #endregion

        #region mainModalDialog

        [FindsBy(How = How.CssSelector, Using = @"#mainModalDialog")]
        protected IWebElement mainModalDialog { get; set; }

        #endregion

        [FindsBy(How = How.CssSelector, Using = @".panelsSubmenu a:nth-child(1)")]
        protected IWebElement btnAllPanels { get; set; }


        [FindsBy(How = How.CssSelector, Using = @".panelsSubmenu a:nth-child(2)")]
        protected IWebElement btnFaultsMonitoring { get; set; }


        [FindsBy(How = How.CssSelector, Using = @".panelsSubmenu a:nth-child(3)")]
        protected IWebElement btnSuspendedFaults { get; set; }


        [FindsBy(How = How.CssSelector, Using = @".panelsSubmenu a:nth-child(4)")]
        protected IWebElement btnRemoteInspection { get; set; }


        [FindsBy(How = How.CssSelector, Using = @".add")]
        protected IWebElement btnAddUnit { get; set; }


        [FindsBy(How = How.CssSelector, Using = @"[id$=RemoveBusyButton]")]
        protected IWebElement btnRemoveUnit { get; set; }


        [FindsBy(How = How.CssSelector, Using = @"div.section + span")]
        protected IWebElement ddbActions { get; set; }

        #endregion

        #region Invoke() and IsDisplayed()
        public override void Invoke()
        {
            var LoginPage = new ipmpLoginPage();
            var tycoPage = LoginPage.Login();
            tycoPage.WaitLoadPage();
            var PanelsPage = tycoPage.Panels();
            PanelsPage.WaitLoadPage();
        }

        public override bool IsDisplayed()
        {
            throw new NotImplementedException();
            return true;
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
            #region Search and Filters, Caption locators
            VerifyElementVisible("blockFilters", blockFilters);
            VerifyElementVisible("blockSearch", blockSearch);
            VerifyElementVisible("labelCaption", labelCaption);
            #endregion
            VerifyElementVisible("btnAllPanels", btnAllPanels);
            VerifyElementVisible("btnFaultsMonitoring", btnFaultsMonitoring);
            VerifyElementVisible("btnSuspendedFaults", btnSuspendedFaults);
            VerifyElementVisible("btnRemoteInspection", btnRemoteInspection);
            VerifyElementVisible("btnAddUnit", btnAddUnit);
            VerifyElementVisible("btnRemoveUnit", btnRemoveUnit);
            VerifyElementVisible("ddbActions", ddbActions);            
        }

        public void WaitLoadPage()
        {
            Wait.UntilVisible(labelCaption, 10000);
            Wait.UntilDisapear(mainModalDialog, 15000);
        }
    }
}

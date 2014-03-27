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
    public class PanelGeneralPage : GeneralHeaderPage
    {
        #region WebElements

        #region Panel General locators

        [FindsBy(How = How.CssSelector, Using = @"#unitRefreshBusyButton")]
        protected IWebElement btnRefreshPanel { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".menu .btn>span>b")]
        protected IWebElement btnEditPanel { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#unitRemoveBusyButton")]
        protected IWebElement btnRemovePanel { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".txt")]
        protected IWebElement linkStatus { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#unitMaintenanceStatus")]
        protected IWebElement labelOnlineStatus { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".unitTitle")]
        protected IWebElement labelUnitTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#quickUnitNavigation")]
        protected IWebElement blockUnitNavigation { get; set; }

        //.unitGeneralMenuGroup:nth-of-type(1) a[href*="general"]
        //.unitGeneralMenuGroup:nth-of-type(1) a[href*="services"]
        //.unitGeneralMenuGroup:nth-of-type(1) a[href*="location"]
        //.unitGeneralMenuGroup:nth-of-type(2) a[href*="diagnostic"]
        //.unitGeneralMenuGroup:nth-of-type(2) a[href*="remoteinspection"]
        //.unitGeneralMenuGroup:nth-of-type(2) a[href*="pmaxstate"]
        //.unitGeneralMenuGroup:nth-of-type(2) a[href*="pmaxconfig"]
        //.unitGeneralMenuGroup:nth-of-type(2) a[href*="locations"]
        //.unitGeneralMenuGroup:nth-of-type(3) a[href*="pmaxlog/standard"]
        //.unitGeneralMenuGroup:nth-of-type(3) a[href*="pmaxlog/legacy"]
 
        #endregion

        #endregion

        #region Invoke() and IsDisplayed()
        public override void Invoke()
        {
            var LoginPage = new LoginPage();
            var tycoPage = LoginPage.Login();
            tycoPage.WaitLoadPage();
            var PanelsPage = tycoPage.Panels();
            PanelsPage.WaitLoadPage();
            PanelsPage.Search(Config.panelID);

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
            VerifyElementVisible("labelVersion", labelVersion);
            VerifyElementVisible("labelCurrentUser", labelCurrentUser);
            VerifyElementVisible("linkSettings", linkSettings);
            VerifyElementVisible("linkLogout", linkLogout);
            VerifyElementVisible("linkHelp", linkHelp);
            #endregion

            #region General Header locators
            VerifyElementVisible("btnRefreshPanel", btnRefreshPanel);
            VerifyElementVisible("btnEditPanel", btnEditPanel);
            VerifyElementVisible("btnRemovePanel", btnRemovePanel);
            VerifyElementVisible("linkStatus", linkStatus);
            VerifyElementVisible("labelOnlineStatus", labelOnlineStatus);
            VerifyElementVisible("labelUnitTitle", labelUnitTitle);
            VerifyElementVisible("blockUnitNavigation", blockUnitNavigation);
            #endregion

            #region Caption locator
            VerifyElementVisible("labelCaption", labelCaption);
            #endregion
        }
    }
}
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

namespace Demo.TestModel.IPMPpages.System
{
    public class CentralStationsPage : SearchFilterPage
    {
        public CentralStationsPage()
        {
            expectedCaption = "CENTRAL STATIONS LIST";
        }

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = @".add")]
        protected IWebElement btnAddCentralStation { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#centralstationRemoveBusyButton")]
        protected IWebElement btnRemoveCentralStation { get; set; }

        #endregion

        #region Open()
        public override void Open()
        {
            var loginPage = GetLoginPage();
            var tycoPage = loginPage.Login();
            var systemPage = tycoPage.System();
            systemPage.CentralStations();
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

            VerifyElementVisible("btnAddCentralStation", btnAddCentralStation);
            VerifyElementVisible("btnRemoveCentralStation", btnRemoveCentralStation);
        }

        public override void WaitLoadPage()
        {
            Wait.UntilVisible(btnAddCentralStation, 20000);
            Wait.UntilDisapear(mainModalDialog, 20000);
            WaitLoadGrid();
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Expected: " + expectedCaption + ", Current: " + CurrentCaption());
            }
        }

        public AddCS AddCSClick()
        {
            btnAddCentralStation.Click();
            AddCS AddCS = new AddCS();
            AddCS.WaitLoadPage();
            return AddCS;
        }

        public EditCS EditCSClick()
        {
            Wait.UntilVisible(gridLink, 20000).Click();
            EditCS EditCS = new EditCS();
            EditCS.WaitLoadPage();
            return EditCS;
        }

        public void RemoveCSClickYes()
        {
            Wait.UntilVisible(btnRemoveCentralStation, 20000).Click();
            Wait.UntilVisible(modalDialogYes, 20000).Click();
            ExpectedToaster("was deleted successful");
        }

        public void RemoveCSClickCancel()
        {
            Wait.UntilVisible(btnRemoveCentralStation, 20000).Click();
            Wait.UntilVisible(modalDialogCancel, 20000).Click();
        }
    }
}
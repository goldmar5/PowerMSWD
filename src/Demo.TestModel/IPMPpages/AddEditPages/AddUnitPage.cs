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
namespace Demo.TestModel.IPMPpages
{
    public class AddUnitPage : AddEditBasePage
    {

        public AddUnitPage()
        {
            expectedCaption = "ADD UNIT";
        }

        #region WebElements        

        [FindsBy(How = How.CssSelector, Using = @"#unitsAllAddBusyButtonTop")]
        protected IWebElement btnSaveChangesAddUnitTop { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#unitsAllAddBusyButtonBottom")]
        protected IWebElement btnSaveChangesAddUnitBottom { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#unt_serial")]
        protected IWebElement txtPanelID { get; set; }

        #endregion

        #region Open()
        public override void Open()
        {
            var LoginPage = GetLoginPage();
            var tycoPage = LoginPage.Login();
            var panelsPage = tycoPage.Panels();
            panelsPage.AddUnitClick();
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
            VerifyElementVisible("btnSaveChangesTop", btnSaveChangesAddUnitTop);
            VerifyElementVisible("btnSaveChangesBottom", btnSaveChangesAddUnitBottom);
            VerifyElementVisible("btnDiscardChanges", btnDiscardChanges);
            VerifyElementVisible("addEditGrid", addEditGrid);
            VerifyElementVisible("pagePathNextToCaption", pagePathNextToCaption);
            #endregion            

            VerifyElementVisible("txtPanelID", txtPanelID);
        }

        public override void WaitLoadPage()
        {
            Wait.UntilVisible(btnSaveChangesAddUnitTop, 20000);
            Wait.UntilDisapear(mainModalDialog, 20000);
            if (!this.ItIsYou())
            {
                throw new NoSuchElementException("Expected: " + expectedCaption + ", Current: " + CurrentCaption());
            }
        }
    }
}


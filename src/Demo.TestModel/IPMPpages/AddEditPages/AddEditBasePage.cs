﻿#region Usings - System
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
    public class AddEditBasePage : GeneralHeaderPage
    {
        #region WebElements

        #region Add Edit locators

        [FindsBy(How = How.CssSelector, Using = @"#text")]
        protected IWebElement labelStayOnPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#stayOnPageTop")]
        protected IWebElement checkboxStayOnPageTop { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#stayOnPageBottom")]
        protected IWebElement checkboxStayOnPageBottom { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"[class*=subTitle] .btnSimple")]
        protected IWebElement btnDiscardChanges { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".scroll")]
        protected IWebElement addEditGrid { get; set; }

        [FindsBy(How = How.CssSelector, Using = @".breadCrumbs")]
        protected IWebElement pagePathNextToCaption { get; set; }

        #endregion

        #endregion

        public override void Open()
        {

        }

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
            VerifyElementVisible("btnDiscardChanges", btnDiscardChanges);
            VerifyElementVisible("addEditGrid", addEditGrid);
            VerifyElementVisible("pagePathNextToCaption", pagePathNextToCaption);
            #endregion
        }
    }
}


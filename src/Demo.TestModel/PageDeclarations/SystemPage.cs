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
using Demo.TestModel.PageDeclarations.System;
namespace Demo.TestModel.PageDeclarations
{
    public class SystemPage : GeneralHeaderPage
    {

        public SystemPage()
        {
            expectedCaption = "SYSTEM MENU";
        }

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = @"#users_alink")]
        protected IWebElement linkUsers { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#userroles_alink")]
        protected IWebElement linkUserRoles { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#useractionlog_alink")]
        protected IWebElement linkUserActionlog { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"[class*=floatL]:nth-of-type(2) li:nth-of-type(1) a")]
        protected IWebElement linkPowerMaxPackages { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"[class*=floatL]:nth-of-type(2) li:nth-of-type(2) a")]
        protected IWebElement linkPowerLinkPackages { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#pmaxconfigs_alink")]
        protected IWebElement linkManageBaseConfiguration { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#centralstations_alink")]
        protected IWebElement linkCentralStations { get; set; }

        [FindsBy(How = How.CssSelector, Using = @"#remoteinspection_alink")]
        protected IWebElement linkRemoteInspectionValues { get; set; }

        #endregion

        #region Invoke() and IsDisplayed()
        public override void Invoke()
        {
            var LoginPage = GetLoginPage();
            var tycoPage = LoginPage.Login();
            tycoPage.System();
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
        }

        public UsersPage Users()
        {
            linkUsers.Click();
            UsersPage UsersPage = new UsersPage();
            UsersPage.WaitLoadPage();
            return UsersPage;
        }

        public UserRolesPage UserRoles()
        {
            linkUserRoles.Click();
            UserRolesPage UserRolesPage = new UserRolesPage();
            UserRolesPage.WaitLoadPage();
            return UserRolesPage;
        }

        public UserActionLogPage UserActionLog()
        {
            linkUserActionlog.Click();
            UserActionLogPage UserActionLogPage = new UserActionLogPage();
            UserActionLogPage.WaitLoadPage();
            return UserActionLogPage;
        }

        public PowerMaxPackagesPage PowerMaxPackages()
        {
            linkPowerLinkPackages.Click();
            PowerMaxPackagesPage PowerMaxPackagesPage = new PowerMaxPackagesPage();
            PowerMaxPackagesPage.WaitLoadPage();
            return PowerMaxPackagesPage;
        }

        public PowerLinkPackagesPage PowerLinkPackages()
        {
            linkPowerLinkPackages.Click();
            PowerLinkPackagesPage PowerLinkPackagesPage = new PowerLinkPackagesPage();
            PowerLinkPackagesPage.WaitLoadPage();
            return PowerLinkPackagesPage;
        }

        public ManageBaseConfigurationsPage ManageBaseConfigurations()
        {
            linkManageBaseConfiguration.Click();
            ManageBaseConfigurationsPage ManageBaseConfigurationsPage = new ManageBaseConfigurationsPage();
            ManageBaseConfigurationsPage.WaitLoadPage();
            return ManageBaseConfigurationsPage;
        }

        public CentralStationsPage CentralStations()
        {
            linkCentralStations.Click();
            CentralStationsPage CentralStationsPage = new CentralStationsPage();
            CentralStationsPage.WaitLoadPage();
            return CentralStationsPage;
        }

        public RemoteInspectionValuesPage RemoteInspectionValues()
        {
            linkRemoteInspectionValues.Click();
            RemoteInspectionValuesPage RemoteInspectionValuesPage = new RemoteInspectionValuesPage();
            RemoteInspectionValuesPage.WaitLoadPage();
            return RemoteInspectionValuesPage;
        }
    }
}

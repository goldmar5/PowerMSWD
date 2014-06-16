using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

using Demo.TestModel;
using Swd.Core.Pages;
using Demo.TestModel.IPMPpages;
using Swd.Core.WebDriver;
using OpenQA.Selenium;

namespace PowerManageGUI.Tests
{
    [TestClass]
    public class MainTests
    {

        public void MakeScreenshot<PAGE>(PAGE page, string screenName) where PAGE : BasePage, new()
        {            
            using (page)
            {
                try
                {
                    page.Open();
                    Screenshot ss = ((ITakesScreenshot)page.Driver).GetScreenshot();
                    ss.SaveAsFile("screen\\" + screenName, System.Drawing.Imaging.ImageFormat.Png);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    SwdBrowser.CloseDriver();
                }
            }
        }

        [TestMethod]
        [Test]
        public void GetLoginPageAfterLogout()
        {
            var loginPage = BasePage.GetLoginPage();
            var tycoPage = loginPage.Login();
            var logoutPage = tycoPage.Logout();
            logoutPage.FullLogout();
        }

        [TestMethod]
        [Test]
        public void GetToasterMessageTest()
        {
            var loginPage = BasePage.GetLoginPage();
            var tycoPage = loginPage.Login();
            var panelsPage = tycoPage.Panels();
            var generalPanelPage = panelsPage.PanelIDClick();
            generalPanelPage.RefreshPanelClick();
        }

        [TestMethod]
        [Test]
        public void ScreenOfAllPages()
        {
            MakeScreenshot(Pages.LoginPage,        "LoginPage.png");
            MakeScreenshot(Pages.WrongLoginPage,   "WrongLoginPage.png");
            MakeScreenshot(Pages.LogoTycoPage,     "LogoTycoPage.png");
            MakeScreenshot(Pages.PanelsPage,       "PanelsPage.png");
            MakeScreenshot(Pages.GroupPage,        "GroupPage.png");
            MakeScreenshot(Pages.EventsPage,       "EventsPage.png");
            MakeScreenshot(Pages.ProcessesPage,    "ProcessesPage.png");
            MakeScreenshot(Pages.SystemPage,       "SystemPage.png");
            MakeScreenshot(Pages.LogoutMenuPage,   "LogoutMenuPage.png");

            MakeScreenshot(Pages.AddUnitPage,      "AddUnitPage.png");
            MakeScreenshot(Pages.AddUserPage,      "AddUserPage.png");
            MakeScreenshot(Pages.AddUserRolePage,  "AddUserRolePage.png");
            MakeScreenshot(Pages.AddCS,            "AddCS.png");
            MakeScreenshot(Pages.AddGroup,         "AddGroup.png");
            MakeScreenshot(Pages.EditUnitPage,     "EditUnitPage.png");
            MakeScreenshot(Pages.EditUserPage,     "EditUserPage.png");
            MakeScreenshot(Pages.EditUserRolePage, "EditUserRolePage.png");
            MakeScreenshot(Pages.EditCS,           "EditCS.png");
            MakeScreenshot(Pages.EditGroup,        "EditGroup.png");
            MakeScreenshot(Pages.UserSettingsPage, "UserSettingsPage.png");

            MakeScreenshot(Pages.FaultsMonitoringPage,  "FaultsMonitoringPage.png");
            MakeScreenshot(Pages.RemoteInspectionPage,  "RemoteInspectionPage.png");
            MakeScreenshot(Pages.SuspendedFaultsPage,   "SuspendedFaultsPage.png");

            MakeScreenshot(Pages.UsersPage,                    "UsersPage.png");
            MakeScreenshot(Pages.UserRolesPage,                "UserRolesPage.png");
            MakeScreenshot(Pages.UserActionLogPage,            "UserActionLogPage.png");
            MakeScreenshot(Pages.PowerMaxPackagesPage,         "PowerMaxPackagesPage.png");
            MakeScreenshot(Pages.PowerLinkPackagesPage,        "PowerLinkPackagesPage.png");
            MakeScreenshot(Pages.ManageBaseConfigurationsPage, "ManageBaseConfigurationsPage.png");
            MakeScreenshot(Pages.CentralStationsPage,          "CentralStationsPage.png");
            MakeScreenshot(Pages.RemoteInspectionValuesPage,   "RemoteInspectionValuesPage.png");

            MakeScreenshot(Pages.GeneralPage,              "GeneralPage.png");
            MakeScreenshot(Pages.LocationPage,             "LocationPage.png");
            MakeScreenshot(Pages.ServicesPage,             "ServicesPage.png");
            MakeScreenshot(Pages.DiagnosticsPage,          "DiagnosticsPage.png");
            MakeScreenshot(Pages.RemoteInspectionsPage,    "RemoteInspectionsPage.png");
            MakeScreenshot(Pages.SetStatePage,             "SetStatePage.png");
            MakeScreenshot(Pages.SetGetConfigurationPage,  "SetGetConfigurationPage.png");
            MakeScreenshot(Pages.ZonesCustomizationPage,   "ZonesCustomizationPage.png");
            MakeScreenshot(Pages.StandardLogPage,          "StandardLogPage.png");
            MakeScreenshot(Pages.LegacyLogPage,            "LegacyLogPage.png");
        }
    }
}

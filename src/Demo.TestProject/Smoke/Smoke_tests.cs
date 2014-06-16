using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

using Demo.TestModel;
using Swd.Core.Pages;
using Demo.TestModel.IPMPpages;
using Swd.Core.WebDriver;

namespace PowerManageGUI.Smoke
{
    [TestClass]
    public class Smoke_tests
    {

        public void PageTest<PAGE>(PAGE page) where PAGE : BasePage, new()
        {
            // Implement Dispose inside page object in order to do cleanup
            using (page)
            {
                try
                {
                    page.Open();
                    page.VerifyExpectedElementsAreDisplayed();
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

        
        // Add testMethods for your new pages here:
        // *PageName*_VerifyExpectedElements()

        [TestMethod]
        [Test]
        public void LogoutMenuPage_VerifyExpectedElements()
        {
            PageTest(Pages.LogoutMenuPage);
        }

        [TestMethod]
        [Test]
        public void TycoPowerManagePage_VerifyExpectedElements()
        {
            PageTest(Pages.LogoTycoPage);
        }

        [TestMethod]
        [Test]
        public void LoginPage_VerifyExpectedElements()
        {
            PageTest(Pages.LoginPage);
        }

        [TestMethod]
        [Test]
        public void PanelsPage_VerifyExpectedElements()
        {
            PageTest(Pages.PanelsPage);
        }

        [TestMethod]
        [Test]
        public void GroupPage_VerifyExpectedElements()
        {
            PageTest(Pages.GroupPage);
        }

        [TestMethod]
        [Test]
        public void EventsPage_VerifyExpectedElements()
        {
            PageTest(Pages.EventsPage);
        }

        [TestMethod]
        [Test]
        public void ProcessesPage_VerifyExpectedElements()
        {
            PageTest(Pages.ProcessesPage);
        }

        [TestMethod]
        [Test]
        public void SystemPage_VerifyExpectedElements()
        {
            PageTest(Pages.SystemPage);
        }

        // ====================== PANELS ============================================//
        [TestMethod]
        [Test]
        public void FaultsMonitoringPage_VerifyExpectedElements()
        {
            PageTest(Pages.FaultsMonitoringPage);
        }

        [TestMethod]
        [Test]
        public void SuspendedFaultsPage_VerifyExpectedElements()
        {
            PageTest(Pages.SuspendedFaultsPage);
        }

        [TestMethod]
        [Test]
        public void RemoteInspectionPage_VerifyExpectedElements()
        {
            PageTest(Pages.RemoteInspectionPage);
        }

        // ====================== SYSTEM ============================================//

        [TestMethod]
        [Test]
        public void UsersPage_VerifyExpectedElements()
        {
            PageTest(Pages.UsersPage);
        }

        [TestMethod]
        [Test]
        public void UserRolesPage_VerifyExpectedElements()
        {
            PageTest(Pages.UserRolesPage);
        }

        [TestMethod]
        [Test]
        public void UserActionLogPage_VerifyExpectedElements()
        {
            PageTest(Pages.UserActionLogPage);
        }

        [TestMethod]
        [Test]
        public void PowerMaxPackagesPage_VerifyExpectedElements()
        {
            PageTest(Pages.PowerMaxPackagesPage);
        }

        [TestMethod]
        [Test]
        public void PowerLinkPackagesPage_VerifyExpectedElements()
        {
            PageTest(Pages.PowerLinkPackagesPage);
        }

        [TestMethod]
        [Test]
        public void ManageBaseConfigurationsPage_VerifyExpectedElements()
        {
            PageTest(Pages.ManageBaseConfigurationsPage);
        }

        [TestMethod]
        [Test]
        public void CentralStationsPage_VerifyExpectedElements()
        {
            PageTest(Pages.CentralStationsPage);
        }

        [TestMethod]
        [Test]
        public void RemoteInspectionValuesPage_VerifyExpectedElements()
        {
            PageTest(Pages.RemoteInspectionValuesPage);
        }

        // ====================== ADD EDIT PAGES ============================================//

        [TestMethod]
        [Test]
        public void AddUnitPage_VerifyExpectedElements()
        {
            PageTest(Pages.AddUnitPage);
        }

        [TestMethod]
        [Test]
        public void EditUnitPage_VerifyExpectedElements()
        {
            PageTest(Pages.EditUnitPage);
        }

        [TestMethod]
        [Test]
        public void AddUserRolePage_VerifyExpectedElements()
        {
            PageTest(Pages.AddUserRolePage);
        }

        [TestMethod]
        [Test]
        public void EditUserRolePage_VerifyExpectedElements()
        {
            PageTest(Pages.EditUserRolePage);
        }

        [TestMethod]
        [Test]
        public void AddUserPage_VerifyExpectedElements()
        {
            PageTest(Pages.AddUserPage);
        }

        [TestMethod]
        [Test]
        public void EditUserPage_VerifyExpectedElements()
        {
            PageTest(Pages.EditUserPage);
        }

        [TestMethod]
        [Test]
        public void AddCS_VerifyExpectedElements()
        {
            PageTest(Pages.AddCS);
        }

        [TestMethod]
        [Test]
        public void EditCS_VerifyExpectedElements()
        {
            PageTest(Pages.EditCS);
        }

        [TestMethod]
        [Test]
        public void AddGroup_VerifyExpectedElements()
        {
            PageTest(Pages.AddGroup);
        }

        [TestMethod]
        [Test]
        public void EditGroup_VerifyExpectedElements()
        {
            PageTest(Pages.EditGroup);
        }

        [TestMethod]
        [Test]
        public void UserSettingsPage_VerifyExpectedElements()
        {
            PageTest(Pages.UserSettingsPage);
        }

        // ====================== PANEL FUNCTIONALITY PAGES ============================================//

        [TestMethod]
        [Test]
        public void GeneralPanelPage_VerifyExpectedElements()
        {
            PageTest(Pages.GeneralPage);
        }

        [TestMethod]
        [Test]
        public void ServicesPanelPage_VerifyExpectedElements()
        {
            PageTest(Pages.ServicesPage);
        }

        [TestMethod]
        [Test]
        public void LocationPage_VerifyExpectedElements()
        {
            PageTest(Pages.LocationPage);
        }

        [TestMethod]
        [Test]
        public void DiagnosticsPage_VerifyExpectedElements()
        {
            PageTest(Pages.DiagnosticsPage);
        }

        [TestMethod]
        [Test]
        public void RemoteInspectionsPage_VerifyExpectedElements()
        {
            PageTest(Pages.RemoteInspectionsPage);
        }

        [TestMethod]
        [Test]
        public void SetStatePage_VerifyExpectedElements()
        {
            PageTest(Pages.SetStatePage);
        }

        [TestMethod]
        [Test]
        public void SetGetConfigurationPage_VerifyExpectedElements()
        {
            PageTest(Pages.SetGetConfigurationPage);
        }

        [TestMethod]
        [Test]
        public void ZonesCustomizationPage_VerifyExpectedElements()
        {
            PageTest(Pages.ZonesCustomizationPage);
        }

        [TestMethod]
        [Test]
        public void StandardLogPage_VerifyExpectedElements()
        {
            PageTest(Pages.StandardLogPage);
        }

        [TestMethod]
        [Test]
        public void LegacyLogPage_VerifyExpectedElements()
        {
            PageTest(Pages.LegacyLogPage);
        }

    }
}

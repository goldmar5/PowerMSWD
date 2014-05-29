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
                    page.Invoke();
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
            PageTest(MyPages.LogoutMenuPage);
        }

        [TestMethod]
        [Test]
        public void TycoPowerManagePage_VerifyExpectedElements()
        {
            PageTest(MyPages.TycoPowerManagePage);
        }

        [TestMethod]
        [Test]
        public void LoginPage_VerifyExpectedElements()
        {
            PageTest(MyPages.LoginPage);
        }

        [TestMethod]
        [Test]
        public void PanelsPage_VerifyExpectedElements()
        {
            PageTest(MyPages.PanelsPage);
        }

        [TestMethod]
        [Test]
        public void GroupPage_VerifyExpectedElements()
        {
            PageTest(MyPages.GroupPage);
        }

        [TestMethod]
        [Test]
        public void EventsPage_VerifyExpectedElements()
        {
            PageTest(MyPages.EventsPage);
        }

        [TestMethod]
        [Test]
        public void ProcessesPage_VerifyExpectedElements()
        {
            PageTest(MyPages.ProcessesPage);
        }

        [TestMethod]
        [Test]
        public void SystemPage_VerifyExpectedElements()
        {
            PageTest(MyPages.SystemPage);
        }

        // ====================== PANELS ============================================//
        [TestMethod]
        [Test]
        public void FaultsMonitoringPage_VerifyExpectedElements()
        {
            PageTest(MyPages.FaultsMonitoringPage);
        }

        [TestMethod]
        [Test]
        public void SuspendedFaultsPage_VerifyExpectedElements()
        {
            PageTest(MyPages.SuspendedFaultsPage);
        }

        [TestMethod]
        [Test]
        public void RemoteInspectionPage_VerifyExpectedElements()
        {
            PageTest(MyPages.RemoteInspectionPage);
        }

        // ====================== SYSTEM ============================================//

        [TestMethod]
        [Test]
        public void UsersPage_VerifyExpectedElements()
        {
            PageTest(MyPages.UsersPage);
        }

        [TestMethod]
        [Test]
        public void UserRolesPage_VerifyExpectedElements()
        {
            PageTest(MyPages.UserRolesPage);
        }

        [TestMethod]
        [Test]
        public void UserActionLogPage_VerifyExpectedElements()
        {
            PageTest(MyPages.UserActionLogPage);
        }

        [TestMethod]
        [Test]
        public void PowerMaxPackagesPage_VerifyExpectedElements()
        {
            PageTest(MyPages.PowerMaxPackagesPage);
        }

        [TestMethod]
        [Test]
        public void PowerLinkPackagesPage_VerifyExpectedElements()
        {
            PageTest(MyPages.PowerLinkPackagesPage);
        }

        [TestMethod]
        [Test]
        public void ManageBaseConfigurationsPage_VerifyExpectedElements()
        {
            PageTest(MyPages.ManageBaseConfigurationsPage);
        }

        [TestMethod]
        [Test]
        public void CentralStationsPage_VerifyExpectedElements()
        {
            PageTest(MyPages.CentralStationsPage);
        }

        [TestMethod]
        [Test]
        public void RemoteInspectionValuesPage_VerifyExpectedElements()
        {
            PageTest(MyPages.RemoteInspectionValuesPage);
        }

        // ====================== ADD EDIT PAGES ============================================//

        [TestMethod]
        [Test]
        public void AddUnitPage_VerifyExpectedElements()
        {
            PageTest(MyPages.AddUnitPage);
        }

        [TestMethod]
        [Test]
        public void EditUnitPage_VerifyExpectedElements()
        {
            PageTest(MyPages.EditUnitPage);
        }

        [TestMethod]
        [Test]
        public void AddUserRolePage_VerifyExpectedElements()
        {
            PageTest(MyPages.AddUserRolePage);
        }

        [TestMethod]
        [Test]
        public void EditUserRolePage_VerifyExpectedElements()
        {
            PageTest(MyPages.EditUserRolePage);
        }

        [TestMethod]
        [Test]
        public void AddUserPage_VerifyExpectedElements()
        {
            PageTest(MyPages.AddUserPage);
        }

        [TestMethod]
        [Test]
        public void EditUserPage_VerifyExpectedElements()
        {
            PageTest(MyPages.EditUserPage);
        }

        [TestMethod]
        [Test]
        public void UserSettingsPage_VerifyExpectedElements()
        {
            PageTest(MyPages.UserSettingsPage);
        }

        // ====================== PANEL FUNCTIONALITY PAGES ============================================//

        [TestMethod]
        [Test]
        public void GeneralPanelPage_VerifyExpectedElements()
        {
            PageTest(MyPages.GeneralPage);
        }

        [TestMethod]
        [Test]
        public void ServicesPanelPage_VerifyExpectedElements()
        {
            PageTest(MyPages.ServicesPage);
        }

        [TestMethod]
        [Test]
        public void LocationPage_VerifyExpectedElements()
        {
            PageTest(MyPages.LocationPage);
        }

        [TestMethod]
        [Test]
        public void DiagnosticsPage_VerifyExpectedElements()
        {
            PageTest(MyPages.DiagnosticsPage);
        }

        [TestMethod]
        [Test]
        public void RemoteInspectionsPage_VerifyExpectedElements()
        {
            PageTest(MyPages.RemoteInspectionsPage);
        }

        [TestMethod]
        [Test]
        public void SetStatePage_VerifyExpectedElements()
        {
            PageTest(MyPages.SetStatePage);
        }

        [TestMethod]
        [Test]
        public void SetGetConfigurationPage_VerifyExpectedElements()
        {
            PageTest(MyPages.SetGetConfigurationPage);
        }

        [TestMethod]
        [Test]
        public void ZonesCustomizationPage_VerifyExpectedElements()
        {
            PageTest(MyPages.ZonesCustomizationPage);
        }

        [TestMethod]
        [Test]
        public void StandardLogPage_VerifyExpectedElements()
        {
            PageTest(MyPages.StandardLogPage);
        }

        [TestMethod]
        [Test]
        public void LegacyLogPage_VerifyExpectedElements()
        {
            PageTest(MyPages.LegacyLogPage);
        }

    }
}

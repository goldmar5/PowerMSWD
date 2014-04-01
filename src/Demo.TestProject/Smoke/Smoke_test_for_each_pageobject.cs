using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Demo.TestModel;
using Swd.Core.Pages;
using Demo.TestModel.IPMPpages;
using Swd.Core.WebDriver;

namespace Demo.TestProject.Smoke
{
    [TestClass]
    public class Smoke_test_for_each_pageobject
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
        public void LogoutMenuPage_VerifyExpectedElements()
        {
            PageTest(MyPages.LogoutMenuPage);
        }

        [TestMethod]
        public void TycoPowerManagePage_VerifyExpectedElements()
        {
            PageTest(MyPages.TycoPowerManagePage);
        }

        [TestMethod]
        public void LoginPage_VerifyExpectedElements()
        {
            PageTest(MyPages.LoginPage);
        }

        [TestMethod]
        public void PanelsPage_VerifyExpectedElements()
        {
            PageTest(MyPages.PanelsPage);
        }

        [TestMethod]
        public void GroupPage_VerifyExpectedElements()
        {
            PageTest(MyPages.GroupPage);
        }

        [TestMethod]
        public void EventsPage_VerifyExpectedElements()
        {
            PageTest(MyPages.EventsPage);
        }

        [TestMethod]
        public void ProcessesPage_VerifyExpectedElements()
        {
            PageTest(MyPages.ProcessesPage);
        }

        [TestMethod]
        public void SystemPage_VerifyExpectedElements()
        {
            PageTest(MyPages.SystemPage);
        }

        // ====================== PANELS ============================================//
        [TestMethod]
        public void FaultsMonitoringPage_VerifyExpectedElements()
        {
            PageTest(MyPages.FaultsMonitoringPage);
        }

        [TestMethod]
        public void SuspendedFaultsPage_VerifyExpectedElements()
        {
            PageTest(MyPages.SuspendedFaultsPage);
        }

        [TestMethod]
        public void RemoteInspectionPage_VerifyExpectedElements()
        {
            PageTest(MyPages.RemoteInspectionPage);
        }

        // ====================== SYSTEM ============================================//

        [TestMethod]
        public void UsersPage_VerifyExpectedElements()
        {
            PageTest(MyPages.UsersPage);
        }

        [TestMethod]
        public void UserRolesPage_VerifyExpectedElements()
        {
            PageTest(MyPages.UserRolesPage);
        }

        [TestMethod]
        public void UserActionLogPage_VerifyExpectedElements()
        {
            PageTest(MyPages.UserActionLogPage);
        }

        [TestMethod]
        public void PowerMaxPackagesPage_VerifyExpectedElements()
        {
            PageTest(MyPages.PowerMaxPackagesPage);
        }

        [TestMethod]
        public void PowerLinkPackagesPage_VerifyExpectedElements()
        {
            PageTest(MyPages.PowerLinkPackagesPage);
        }

        [TestMethod]
        public void ManageBaseConfigurationsPage_VerifyExpectedElements()
        {
            PageTest(MyPages.ManageBaseConfigurationsPage);
        }

        [TestMethod]
        public void CentralStationsPage_VerifyExpectedElements()
        {
            PageTest(MyPages.CentralStationsPage);
        }

        [TestMethod]
        public void RemoteInspectionValuesPage_VerifyExpectedElements()
        {
            PageTest(MyPages.RemoteInspectionValuesPage);
        }

        // ====================== ADD EDIT PAGES ============================================//

        [TestMethod]
        public void AddUnitPage_VerifyExpectedElements()
        {
            PageTest(MyPages.AddUnitPage);
        }

        [TestMethod]
        public void EditUnitPage_VerifyExpectedElements()
        {
            PageTest(MyPages.EditUnitPage);
        }

        [TestMethod]
        public void AddUserRolePage_VerifyExpectedElements()
        {
            PageTest(MyPages.AddUserRolePage);
        }

        [TestMethod]
        public void EditUserRolePage_VerifyExpectedElements()
        {
            PageTest(MyPages.EditUserRolePage);
        }

        [TestMethod]
        public void AddUserPage_VerifyExpectedElements()
        {
            PageTest(MyPages.AddUserPage);
        }

        [TestMethod]
        public void EditUserPage_VerifyExpectedElements()
        {
            PageTest(MyPages.EditUserPage);
        }

        [TestMethod]
        public void UserSettingsPage_VerifyExpectedElements()
        {
            PageTest(MyPages.UserSettingsPage);
        }
    }
}

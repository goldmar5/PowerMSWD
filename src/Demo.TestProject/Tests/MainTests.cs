using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Demo.TestModel;
using Swd.Core.Pages;
using Demo.TestModel.PageDeclarations;
using Swd.Core.WebDriver;

namespace Demo.TestProject.Tests
{
    [TestClass]
    public class MainTests
    {
        [TestMethod]
        public void GetLoginPageAfterLogout()
        {
            var loginPage = BasePage.GetLoginPage();
            var tycoPage = loginPage.Login();
            var logoutPage = tycoPage.Logout();
            logoutPage.FullLogout();
        }

        [TestMethod]
        public void GetToasterMessageTest()
        {
            var loginPage = BasePage.GetLoginPage();
            var tycoPage = loginPage.Login();
            var panelsPage = tycoPage.Panels();
            var generalPanelPage = panelsPage.PanelIDClick();
            generalPanelPage.RefreshPanelClick();
        }

        [TestMethod]
        public void OtherTest()
        {
            //Empty
        }
    }
}

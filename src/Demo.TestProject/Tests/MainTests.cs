using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

using Demo.TestModel;
using Swd.Core.Pages;
using Demo.TestModel.IPMPpages;
using Swd.Core.WebDriver;

namespace PowerManageGUI.Tests
{
    [TestClass]
    public class MainTests
    {
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
        public void OtherTest()
        {
            //Empty
        }
    }
}

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
        public void LogoutTest()
        {
            var LoginPage = new LoginPage();
            var loginPage = LoginPage.GetLoginPage();
            var tycoPage = loginPage.Login();
            var logoutPage = tycoPage.Logout();
            logoutPage.FullLogout();
        }

        [TestMethod]
        public void SomeTest()
        {
            //Empty
        }

        [TestMethod]
        public void OtherTest()
        {
            //Empty
        }
    }
}

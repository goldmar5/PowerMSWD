using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Swd.Core;
using Swd.Core.Pages;
using Swd.Core.Configuration;
using OpenQA.Selenium;
using Demo.TestModel.PageDeclarations;
using OpenQA.Selenium.Support.PageObjects;
using Swd.Core.WebDriver;

namespace Demo.TestModel
{
    public abstract class BasePage : SelfTestingCorePage, IDisposable
    {
        // Verifies the expected WebElement to be Visible
        public virtual void VerifyElementVisible(string elementName, IWebElement webElement)
        {
            if (!webElement.Displayed)
            {
                string message = "Error: WebElement with name <" + elementName + ">\n"
                                 + "was expected to be visible," 
                                 + "but the element was not found on the page.";

                throw new Exception();
            }
        }

        // Override and implement this method, 
        // in case you want the pages to clean up
        public virtual void Dispose()
        {
            // Does nothing at the moment
        }

        public static LoginPage GetLoginPage()
        {
            var loginPage = new LoginPage();
            SwdBrowser.Driver.Url = Config.applicationMainUrl;
            loginPage.WaitLoadPage();
            return loginPage;
        } 
    }
}

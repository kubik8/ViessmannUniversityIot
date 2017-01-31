using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.Events;
using University.Selenium.Framework.Browser;
using University.Selenium.Framework.Pages;
using University.Selenium.Framework.Utilities;

namespace University.Selenium.Tests
{
    [TestClass]
    public class MainPageTests
    {
        [TestInitialize]
        public void Initialize()
        {
            var screenshotDriver = new EventFiringWebDriver(DriverMethods.getDriverType());
            screenshotDriver.ExceptionThrown += DriverMethods.TakeScreenshotOnException;
            Driver.webDriver = screenshotDriver;

        }

        [TestMethod]
        public void LoginShouldSuccess()
        {
            Driver.goToMainPage();
            Driver.implicitWait();

            Page.MainPage.LogInWithExistingUser();

            bool loginSuccessed = Page.MainPage.LoginSuccessed();
            Assert.IsTrue(loginSuccessed);
        }

        [TestMethod]
        public void LoginShouldFail()
        {
            Driver.goToMainPage();
            Driver.implicitWait();

            Page.MainPage.LogInWithNewUser();

            bool loginFailed = Page.MainPage.LoginFailed();
            Assert.IsTrue(loginFailed);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.exit();
        }
    }
}

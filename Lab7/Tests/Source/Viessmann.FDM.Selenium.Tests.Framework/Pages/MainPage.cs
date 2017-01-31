using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using University.Selenium.Framework.Browser;
using University.Selenium.Framework.Utilities;

namespace University.Selenium.Framework.Pages
{
    public class MainPage
    {
        [FindsBy(How = How.Id, Using = "login")]
        private IWebElement loginInput;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement passwordInput;

        [FindsBy(How = How.ClassName, Using = "button")]
        private IWebElement logginButton;

        public void LogInWithExistingUser()
        {
            loginInput.SendKeys(Settings.ExistingUserLogin);
            passwordInput.SendKeys(Settings.ExistingUserPassword);
            logginButton.Click();
        }

        public void LogInWithNewUser()
        {
            loginInput.SendKeys(Settings.NewUserLogin);
            passwordInput.SendKeys(Settings.NewUserPassword);
            logginButton.Click();
        }

        public bool LoginSuccessed()
        {
            Thread.Sleep(500);
            return Driver.webDriver.Url == Settings.temperaturePageUrl;
        }

        public bool LoginFailed()
        {
            String alertText = (new WebDriverWait(Driver.webDriver, TimeSpan.FromSeconds(10))).Until(d => d.SwitchTo().Alert().Text);
            return alertText == "dupa";
        }

        public void goToMainPage()
        {
            Driver.goToMainPage();
        }
    }
}

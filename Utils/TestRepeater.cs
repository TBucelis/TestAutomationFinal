using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestAutomationFinal.Pages;

namespace TestAutomationFinal
{
    class TestRepeater
    {
        private IWebDriver Driver;
        [Test]
        public void LogoutTestCounter()
        {
            var numberOfTries = 5;
            var numberOfFails = 0;

            for (int i = 0; i < numberOfTries; i++)
            {
                try
                {
                    Driver = MyDriver.InitDriver(Browser.Chrome);
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                    Driver.Url = "https://www.pet24.lt/";
                    CommonElements commonElements = new CommonElements(Driver);
                    commonElements.CloseCookiesBar();
                    LoginPage loginPage = new LoginPage(Driver);
                    HomePage homePage = new HomePage(Driver);
                    AccountPage accountPage = new AccountPage(Driver);

                    homePage.goToUserLoginPage();
                    loginPage.LoginAsUser(User.TestUser);
                    accountPage.ClickLogoutButton();
                    loginPage.AssertUserIsLoggedOut();
                }
                catch (Exception e)
                {
                    numberOfFails++;
                }
                finally
                {
                    Driver.Quit();
                }
            }

            Console.WriteLine($"Out of {numberOfTries} times, test failed {numberOfFails} times");
        }
    }
}

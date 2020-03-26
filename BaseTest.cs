using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using TestAutomationFinal.Pages;

namespace TestAutomationFinal
{
    public class BaseTest
    {
        protected IWebDriver Driver;

        protected LoginPage loginPage;
        protected HomePage homePage;
        protected CommonElements commonElements;
        protected ProductPage productPage;
        protected SearchPage searchPage;
        protected WebDriverWait wait;
        protected ProductFilterPage productFilterPage;
        protected ShoppingCartPage shoppingCartPage;
        protected AccountPage accountPage;
        protected UserInfoPage userInfoPage;

        [SetUp]

        public void InitDriver()
        {
            Driver = MyDriver.InitDriver(Browser.Chrome);
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            Driver.Url = "https://www.pet24.lt/";
            InitPages();
            commonElements.CloseCookiesBar();
        }

        public void InitPages()
        {
            loginPage = new LoginPage(Driver);
            homePage = new HomePage(Driver);
            commonElements = new CommonElements(Driver);
            productPage = new ProductPage(Driver);
            searchPage = new SearchPage(Driver);
            productFilterPage = new ProductFilterPage(Driver);
            shoppingCartPage = new ShoppingCartPage(Driver);
            accountPage = new AccountPage(Driver);
            userInfoPage = new UserInfoPage(Driver);
        }

        public void WaitForPageToLoad()
        {
            try
            {
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".logout[title='Atsijungti']"))); // turetu uztekti .logout
            }
            catch (WebDriverTimeoutException e)
            {
            }
            finally
            {
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }

        }

        [TearDown]

        public void QuitDriver()
        {
            MakeScreenshotOnTestFailure();
            Driver.Quit();
        }

        protected void MakeScreenshotOnTestFailure()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
            {
                DoScreenshot();
            }
        }

        protected void DoScreenshot()
        {
            //get the screenshot from Selenium WebDriver and save it to a file
            Screenshot screenshot = Driver.TakeScreenshot();
            var screenshotPath = $"{TestContext.CurrentContext.WorkDirectory}/Screenshots";
            Directory.CreateDirectory(screenshotPath);
            string screenshotFile = Path.Combine(screenshotPath,
                $"{TestContext.CurrentContext.Test.Name}.png");
            screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);
            Console.WriteLine("screenshot: file://" + screenshotFile);

            //add file to NUnit results
            TestContext.AddTestAttachment(screenshotFile, "my screenshot");
        }
    }
}

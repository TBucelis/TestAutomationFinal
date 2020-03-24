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
        }

        [TearDown]

        public void QuitDriver()
        {
            //MakeScreenshotOnTestFailure();
            //Driver.Quit();
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
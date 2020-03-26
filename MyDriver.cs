using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace TestAutomationFinal
{
    public static class MyDriver
    {
        public static IWebDriver InitDriver(Browser browser)
        {
            IWebDriver driver = null;
            switch (browser)
            {
                case Browser.Chrome:
                    driver = new ChromeDriver(GetChromeOptions());
                    break;
                case Browser.Firefox:
                    driver = new FirefoxDriver(GetFirefoxOptions());
                    break;
                default:
                    Assert.Fail("unsupported browser");
                    break;
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            return driver;
        }

        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions optionsChrome = new ChromeOptions();
            //optionsChrome.AddArguments("incognito");
            return optionsChrome;
        }

        private static FirefoxOptions GetFirefoxOptions()
        {
            FirefoxOptions optionsFirefox = new FirefoxOptions();
            optionsFirefox.AddArguments("");
            return optionsFirefox;
        }
    }

    public enum Browser
    {
        Firefox,
        Chrome
    }
}
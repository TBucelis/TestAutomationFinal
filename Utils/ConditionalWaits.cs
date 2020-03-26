using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace TestAutomationFinal.Utils
{
    public class ConditionalWaits
    {
        
        public static void EnsureUserNavigatestoPage(IWebDriver Driver, By menuOptionLocator)
        {
            var numberOfTries = 10;
            var pollingIntervalInMilliSeconds = 500;

            var isDisplayed = true;
                while ( isDisplayed && numberOfTries > 0)
                {
                    try
                    {
                        Driver.FindElement(menuOptionLocator).Click();
                        numberOfTries--;
                        Thread.Sleep(pollingIntervalInMilliSeconds);
                        isDisplayed = Driver.FindElement(menuOptionLocator).Displayed;
                    }
                    catch (NoSuchElementException e)
                    {
                        isDisplayed = false;
                    }
                }
        }
    }
}

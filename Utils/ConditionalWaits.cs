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

            try
            {
                while (Driver.FindElement(menuOptionLocator).Displayed && numberOfTries > 0)
                {
                    Driver.FindElement(menuOptionLocator).Click();
                    numberOfTries--;
                    Thread.Sleep(pollingIntervalInMilliSeconds);
                }
            }
            catch (NoSuchElementException e)
            {
            }

        }
    }
}

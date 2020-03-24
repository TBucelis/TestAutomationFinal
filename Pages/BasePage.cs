using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TestAutomationFinal.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;


        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }


    }
}
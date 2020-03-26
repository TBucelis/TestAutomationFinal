using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationFinal.Pages
{
    public class HomePage : BasePage
    {
        private IWebElement loginFormButton => Driver.FindElement(By.CssSelector(".login[title='Prisijungti']")); // turetu uztekti .login
        private IWebElement searchBar => Driver.FindElement(By.Id("search_query_top"));
        private IWebElement searchButton => Driver.FindElement(By.CssSelector("#searchbox > button"));

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void inputSearchQuery(string searchItem)
        {
            searchBar.SendKeys(searchItem);
            searchButton.Click();
        }

        public void goToUserLoginPage()
        {
            loginFormButton.Click();
        }
    }
}
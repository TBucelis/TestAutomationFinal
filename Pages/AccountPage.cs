using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationFinal.Pages
{
    public class AccountPage : BasePage
    {
        public AccountPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement personalInfoButton => Driver.FindElement(By.CssSelector("#center_column > div > div:nth-child(2) > ul > li:nth-child(2) > a > i"));

        public void GoToUserInfoPage()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(personalInfoButton));
            personalInfoButton.Click();
        }
    }
}

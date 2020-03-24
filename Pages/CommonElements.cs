using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationFinal.Pages
{
    public  class CommonElements : BasePage
    {
        public CommonElements(IWebDriver driver) : base(driver)
        {
        }
        private IWebElement cookiesBarCloseButton => Driver.FindElement(By.Id("lgcookieslaw_close"));

        private IWebElement shoppingCartButton => Driver.FindElement(By.Id("shopping_cart_container"));

        public void CloseCookiesBar()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(cookiesBarCloseButton));
            cookiesBarCloseButton.Click();
        }

        public void GoToShoppingCart()
        {
            shoppingCartButton.Click();
        }
    }
}

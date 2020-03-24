using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationFinal.Pages
{
    public class ShoppingCartPage : BasePage
    {
        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement productName => Driver.FindElement(By.CssSelector(".product-name"));

        public string GetProductNameInCart()
        {
            return productName.Text;
        }

        public void WaitForCartToLoad()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            By shoppingCartSummary = By.Id("cart_title");
            wait.Until(ExpectedConditions.ElementIsVisible(shoppingCartSummary));
        }
    }
}

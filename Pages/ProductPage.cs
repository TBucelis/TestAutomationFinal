using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationFinal.Pages
{
    public class ProductPage : BasePage
    {
        private IWebElement addToCardButton => Driver.FindElement(By.CssSelector("button.exclusive.lg-rounded-ui"));
        private IWebElement productName => Driver.FindElement(By.Id("layer_cart_product_title"));
        private IWebElement closeShoppingCartButton => Driver.FindElement(By.CssSelector(".cross.circle-rounded-ui.close-btn-ui"));

        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickAddToCart()
        {
            addToCardButton.Click();
        }

        public void CloseShoppingCartModalMessage()
        {

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(closeShoppingCartButton));
            closeShoppingCartButton.Click();
        }

        public string GetProductName()
        {
            return productName.Text;
        }
    }
}

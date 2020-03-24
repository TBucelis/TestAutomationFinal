using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TestAutomationFinal.Pages
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement addToCardButton => Driver.FindElement(By.CssSelector("button.exclusive.lg-rounded-ui"));

        public void ClickAddToCart()
        {
            addToCardButton.Click();

        }
    }
}

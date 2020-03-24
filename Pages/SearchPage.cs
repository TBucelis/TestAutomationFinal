using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TestAutomationFinal.Pages
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement firstProductFound => Driver.FindElement(By.CssSelector(".product-name"));

        List<IWebElement> productsReturnedBySearch => new List<IWebElement>(Driver.FindElements(By.CssSelector(".priceRegular")));

        public void ChooseFirstProductFound()
        {
            firstProductFound.Click();
        }

        public int QuantityOfProductsFound()
        {
            return productsReturnedBySearch.Count;
        }

        public bool ProductContainsKeyword(string keyWord)
        {
            return firstProductFound.Text.Contains(keyWord);
        }


    }
}

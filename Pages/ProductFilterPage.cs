using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationFinal.Pages
{
    public class ProductFilterPage : BasePage
    {

        List<IWebElement> manufacturerList => new List<IWebElement>(Driver.FindElements(By.CssSelector("#ul_layered_manufacturer_0 > li")));
        List<IWebElement> actualProductQuantity => new List<IWebElement>( Driver.FindElements(By.CssSelector(".priceRegular")));

        public ProductFilterPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement pickRandomManufacturer()
        {
            Random random = new Random();

            var manufacturerIndex = random.Next(1, manufacturerList.Count - 1);

            var selectedManufacturer = manufacturerList.ElementAt(manufacturerIndex);

            return selectedManufacturer;
        }

        public int getQuantityOfProductsByManufacturer(IWebElement selectedManufacturer)
        {
            var expectedQuantityOfProducts = selectedManufacturer.FindElement(By.CssSelector("li > label span")).Text;

            var expectedQuantityFormatted = expectedQuantityOfProducts.Replace("(", "").Replace(")", "");

            var expectedQuantity = Convert.ToInt32(expectedQuantityFormatted);

            return expectedQuantity;
        }

        public void ClickRandomManufacturer(IWebElement selectedManufacturer)
        {
            selectedManufacturer.FindElement(By.CssSelector("div")).Click();
        }

        public void DropdownShowMaxItems()
        {
            var quantityShownProducts = Driver.FindElement(By.Id("nb_item"));
            var selectQuantity = quantityShownProducts.FindElements(By.CssSelector("option")).Count;

            var selectElement = new SelectElement(quantityShownProducts);

            selectElement.SelectByIndex(selectQuantity - 1);
        }

        public int actualQuantity()
        {
            return actualProductQuantity.Count;
        }
    }
}

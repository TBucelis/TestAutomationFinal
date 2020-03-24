using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationFinal
{
    class FilterTest : BaseTest
    {
        [Test]


        public void FilteredQuantityTest()
        {
            Driver.Url = "https://www.pet24.lt/sunims/drabuziai-ir-aksesuarai";

            var randomManufacturer = productFilterPage.pickRandomManufacturer();
            var expectedQuantity =
                Convert.ToInt32(productFilterPage.getQuantityOfProductsByManufacturer(randomManufacturer));

            productFilterPage.ClickRandomManufacturer(randomManufacturer);
            productFilterPage.DropdownShowMaxItems();

            By loadingIcon = By.CssSelector(".product_list.grid.row #products_loader_icon");
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(loadingIcon));

            Assert.AreEqual(expectedQuantity, productFilterPage.actualQuantity());




            //public void testFilteredResults()
            //{
            //    Driver.Url = "https://www.pet24.lt/sunims/drabuziai-ir-aksesuarai";

            //    var manufacturerList = Driver.FindElements(By.CssSelector("#ul_layered_manufacturer_0 > li"));
            //    Random random = new Random();

            //    var manufacturerIndex = random.Next(1, manufacturerList.Count - 1);

            //    var selectedManufacturer = manufacturerList.ElementAt(manufacturerIndex);

            //    var expectedQuantityOfProducts = selectedManufacturer.FindElement(By.CssSelector("li > label span")).Text;

            //    var expectedQuantityFormatted = expectedQuantityOfProducts.Replace("(", "").Replace(")", "");

            //    selectedManufacturer.FindElement(By.CssSelector("div")).Click();

            //    var quantityShownProducts = Driver.FindElement(By.Id("nb_item"));
            //    var selectQuantity = quantityShownProducts.FindElements(By.CssSelector("option")).Count;

            //    var selectElement = new SelectElement(quantityShownProducts);

            //    selectElement.SelectByIndex(selectQuantity - 1);

            //    By loadingIcon = By.CssSelector(".product_list.grid.row #products_loader_icon");
            //    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(loadingIcon));

            //    var actualProductQuantity = Driver.FindElements(By.CssSelector(".priceRegular")).Count;

            //    var expectedQuantity = Convert.ToInt32(expectedQuantityFormatted);

            //    Assert.AreEqual(expectedQuantity, actualProductQuantity);
            //}
        }
    }
}

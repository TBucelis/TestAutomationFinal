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


        public void ProductFilteringOperational()
        {
            Driver.Url = "https://www.pet24.lt/sunims/drabuziai-ir-aksesuarai";

            var randomManufacturer = productFilterPage.pickRandomManufacturer();
            var expectedQuantity = productFilterPage.getQuantityOfProductsByManufacturer(randomManufacturer); 

            productFilterPage.ClickRandomManufacturer(randomManufacturer);
            productFilterPage.DropdownShowMaxItems();

            commonElements.WaitForLoadingIconToDissappear();  // sitas irgi turetu pasislepti actualQuantity

            Assert.AreEqual(expectedQuantity, productFilterPage.actualQuantity());
        }
    }
}

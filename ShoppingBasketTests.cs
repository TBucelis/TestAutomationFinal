using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationFinal
{
    class ShoppingBasketTests : BaseTest
    {
        List<IWebElement> productsReturnedBySearch => new List<IWebElement>(Driver.FindElements(By.CssSelector(".priceRegular")));

        private IWebElement firstProductFound => Driver.FindElement(By.CssSelector(".product-name"));

        [Test]
        public void SearchTest()
        {
            homePage.inputSearchQuery("maistas");
            Assert.IsTrue(productsReturnedBySearch.Count > 0);
        }

        [Test]

        public void AddToCartTest()
        {
            homePage.inputSearchQuery("zaislai");
            firstProductFound.Click();
            productPage.ClickAddToCart();
            var expectedProductName = Driver.FindElement(By.Id("layer_cart_product_title")).Text;

            var closeShoppingCard = Driver.FindElement(By.CssSelector(".cross.circle-rounded-ui.close-btn-ui"));

            wait.Until(ExpectedConditions.ElementToBeClickable(closeShoppingCard));

            closeShoppingCard.Click();


            Driver.FindElement(By.Id("shopping_cart_container")).Click();
            By shoppingCartSummary = By.Id("cart_title");
            wait.Until(ExpectedConditions.ElementIsVisible(shoppingCartSummary));

            var actualProductName = Driver.FindElement(By.CssSelector(".product-name")).Text;

            Assert.AreEqual(actualProductName, expectedProductName);    
        }


        
        
    }
}

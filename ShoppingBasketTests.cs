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

        [Test]

        public void AddToCartTest()
        {
            homePage.inputSearchQuery("zaislai");
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[style='display: block;']")));
            searchPage.ChooseFirstProductFound();
            productPage.ClickAddToCart();

            var expectedProductName = productPage.GetProductName();

            productPage.CloseShoppingCartModalMessage();
            commonElements.GoToShoppingCart();
            shoppingCartPage.WaitForCartToLoad();

            var actualProductName = shoppingCartPage.GetProductNameInCart();

            Assert.AreEqual(actualProductName, expectedProductName);    
        }
    }
}

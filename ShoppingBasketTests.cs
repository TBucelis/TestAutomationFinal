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
        private string searchValue = "maistas";
        
        [Test]

        public void ProductCanBeAddedToCart()
        {
            homePage.inputSearchQuery(searchValue);
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[style='display: block;']")));
            searchPage.ChooseFirstProductFound();
            Driver.Navigate().Refresh(); //paslepiam buga, neturetu reiketi tokio workaroundo.
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

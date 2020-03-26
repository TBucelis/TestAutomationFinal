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
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[style='display: block;']")));  //irgi turetu buti idetas arba i inputsearcquery arba choose first product found
            searchPage.ChooseFirstProductFound();
            
            // paslepiam buga, workaroundas kad testas testusi
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#view_full_size > #bigpic"))); // :D
            Driver.Navigate().Refresh(); 
            // iiiiiir vaziuojam toliau

            productPage.ClickAddToCart();

            var expectedProductName = productPage.GetProductName();

            productPage.CloseShoppingCartModalMessage();
            commonElements.GoToShoppingCart();
            shoppingCartPage.WaitForCartToLoad(); //testai neturi rupeti kad kazkas kraunasi

            var actualProductName = shoppingCartPage.GetProductNameInCart();

            Assert.AreEqual(actualProductName, expectedProductName);    
        }
    }
}

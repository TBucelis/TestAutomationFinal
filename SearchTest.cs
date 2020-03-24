﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TestAutomationFinal
{
    class SearchTest : BaseTest
    {
        [Test]

        public void SearchKeyWordTest()
        {
            homePage.inputSearchQuery("maistas");
            Assert.IsTrue(searchPage.QuantityOfProductsFound() > 0);
            Assert.IsTrue(searchPage.ProductContainsKeyword("maistas"));
        }
    }
}
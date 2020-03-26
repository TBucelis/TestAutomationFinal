using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using TestAutomationFinal.Pages;

namespace TestAutomationFinal
{
    class LoginTest : BaseTest
    {

        [Test]

        public void UserCanLogIn()
        {
            homePage.goToUserLoginPage();
            loginPage.LoginAsUser(User.TestUser);
            accountPage.AssertLogoutButtonVisible();
        }
    }
}
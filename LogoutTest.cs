using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestAutomationFinal.Pages;

namespace TestAutomationFinal
{
    class LogoutTest : BaseTest
    {

        [SetUp]

        public void Login()
        {
            homePage.goToUserLoginPage();
            loginPage.LoginAsUser(User.TestUser);
        }

        [Test]

        public void UserCanLogOut()
        {
            WaitForPageToLoad();
            accountPage.ClickLogoutButton();
            loginPage.AssertUserIsLoggedOut();
        }
    }
}
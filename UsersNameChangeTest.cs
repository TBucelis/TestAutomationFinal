using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace TestAutomationFinal
{
    class UsersNameChangeTest : BaseTest
    {
        [SetUp]

        public void Login()
        {
            homePage.goToUserLoginPage();
            loginPage.LoginAsUser(User.TestUser);
        }

        [Test]

        public void ChangeUserName()
        {
            accountPage.GoToUserInfoPage();

            var firstNameField = Driver.FindElement(By.Id("firstname"));
            firstNameField.Clear();
            firstNameField.SendKeys("Tomuelis");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TestAutomationFinal.Utils;

namespace TestAutomationFinal
{
    class UsersNameChangeTest : BaseTest
    {
        string newUserName;

        [SetUp]

        public void Login()
        {
            homePage.goToUserLoginPage();
            loginPage.LoginAsUser(User.TestUser);
        }

        [Test]

        public void UsernameCanBeChanged()
        {
            accountPage.GoToUserInfoPage();

            newUserName = DataGenerator.NameCapitalize(DataGenerator.GenerateRandomString(8));
            userInfoPage.EnterNewName(newUserName)
                .SubmitButtonClick()
                .AssertSuccessMessageIsDisplayed()
                .GoToUserInfoPage();

            Assert.AreEqual(newUserName, Driver.FindElement(By.Id("firstname")).GetAttribute("value"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationFinal.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement userEmailField => Driver.FindElement(By.Id("email"));
        private IWebElement userPasswordField => Driver.FindElement(By.Id("passwd"));

        private IWebElement submitButtonElement => Driver.FindElement(By.Id("SubmitLogin"));

        private IWebElement logoutButton => Driver.FindElement(By.CssSelector(".logout[title='Atsijungti']"));



        public LoginPage LoginAsUser(User user)
        {
            WaitUntilFormIsLoaded();
            new Actions(Driver).SendKeys(userEmailField, user.UserEmail).Perform();
            userPasswordField.SendKeys(user.Password);
            submitButtonElement.Click();
            return this;
        }

        public LoginPage WaitUntilFormIsLoaded()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementToBeClickable(submitButtonElement));
            wait.Until(ExpectedConditions.ElementToBeClickable(userEmailField));
            return this;
        }

        public void AssertLogoutButtonVisible()
        {
            Assert.IsNotNull(logoutButton);
        }

        public LoginPage ClickLogoutButton()
        {
            logoutButton.Click();
            return this;
        }

        public void AssertUserIsLoggedOut()
        {
            Assert.IsTrue(submitButtonElement.Displayed);
        }

        public IWebElement GetUserEmailField()
        {
            return userEmailField;
        }

    }
}
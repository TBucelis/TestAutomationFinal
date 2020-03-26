using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestAutomationFinal.Utils;

namespace TestAutomationFinal.Pages
{
    public class UserInfoPage : BasePage
    {
        private IWebElement usernameField => Driver.FindElement(By.Id("firstname"));

        private IWebElement submitChangesButton => Driver.FindElement(By.CssSelector("button[name='submitIdentity']"));

        private IWebElement successMessage => Driver.FindElement(By.CssSelector(".alert.alert-success"));

        private IWebElement backToAccountPageButton =>
            Driver.FindElement(By.CssSelector("[title='Peržiureti mano paskyrą']"));

        public UserInfoPage(IWebDriver driver) : base(driver)
        {
        }

        public UserInfoPage EnterNewName(string newUserName)
        {
            usernameField.Clear();
            usernameField.SendKeys(newUserName);
            return this;
        }

        public UserInfoPage SubmitButtonClick()
        {
            submitChangesButton.Click();
            return this;
        }

        public UserInfoPage AssertSuccessMessageIsDisplayed()
        {
            Assert.IsTrue(successMessage.Displayed);
            return this;
        }

        public void GoBackToAccountPage()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            wait.Until(d => backToAccountPageButton.Enabled);
            backToAccountPageButton.Click();
        }

        public void GoToUserInfoPage()
        {
            Driver.Url = "https://www.pet24.lt/asmenine-informacija";
        }
    }
}

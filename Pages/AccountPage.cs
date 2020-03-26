using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestAutomationFinal.Utils;

namespace TestAutomationFinal.Pages
{
    public class AccountPage : BasePage
    {

        private IWebElement logoutButton => Driver.FindElement(By.CssSelector("[title='  Atsijungti']"));
        private By personalInfoButtonLocator => By.CssSelector("[title='Informacija']");
        private By logoutButtonLocator => By.CssSelector("[title='  Atsijungti']");

        public AccountPage(IWebDriver driver) : base(driver)
        {
        }

        public void AssertLogoutButtonVisible()
        {
            Assert.IsNotNull(logoutButton);
        }
        public void GoToUserInfoPage()
        {
            ConditionalWaits.EnsureUserNavigatestoPage(Driver, personalInfoButtonLocator);
        }
        public void ClickLogoutButton()
        {
            ConditionalWaits.EnsureUserNavigatestoPage(Driver, logoutButtonLocator);
        }
    }
}

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
        private IWebElement userEmailField => Driver.FindElement(By.Id("email"));
        private IWebElement userPasswordField => Driver.FindElement(By.Id("passwd"));
        private IWebElement submitButtonElement => Driver.FindElement(By.Id("SubmitLogin"));
        private IWebElement loginFormWrapper => Driver.FindElement(By.Id("login_form"));

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void LoginAsUser(User user)
        {
            WaitForAttributeNotToBe(loginFormWrapper, "style", "hidden");
            new Actions(Driver).SendKeys(userEmailField, user.UserEmail).Perform();
            userPasswordField.SendKeys(user.Password);
            submitButtonElement.Click();
        }
        public void AssertUserIsLoggedOut()
        {
            Assert.IsTrue(submitButtonElement.Displayed);
        }
        public void WaitForAttributeNotToBe(IWebElement element, String attribute, String value)
        {
            WebDriverWait wait = new WebDriverWait(Driver,TimeSpan.FromSeconds(10));
            wait.Until<Boolean>((d)=>
            {
                
                    String styleAttributeValue = element.GetAttribute(attribute);
                    if (!styleAttributeValue.Contains(value))
                        return true;
                    else
                        return false;
            });

        }
    }
}
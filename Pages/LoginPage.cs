using NUnit.Framework;
using OpenQA.Selenium;

namespace SauceDemoQA.Pages
{
    class LoginPage
    {
        private IWebDriver _driver;
        public LoginPage(IWebDriver driver) => _driver = driver;
        private IWebElement UserNameInput => _driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordInput => _driver.FindElement(By.CssSelector("[placeholder = Password]"));
        private IWebElement LoginBtn => _driver.FindElement(By.Name("login-button"));
        
        public InventoryPage Login(string userName, string password)
        {
            string loginURL = _driver.Url;
           
            UserNameInput.Clear();
            UserNameInput.SendKeys(userName);

            PasswordInput.Clear();
            PasswordInput.SendKeys(password);

            LoginBtn.Click();
            string actualURL = _driver.Url;

            if (actualURL.Equals(loginURL))
                return null;
            else
                return new InventoryPage(_driver);
        }

    }
}

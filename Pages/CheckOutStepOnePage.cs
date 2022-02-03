using OpenQA.Selenium;

namespace SauceDemoQA.Pages
{
    class CheckOutStepOnePage
    {
        protected IWebDriver _driver;
        public CheckOutStepOnePage(IWebDriver driver) => _driver = driver;
        private IWebElement shoppingCartLink=>_driver.FindElement(By.ClassName("shopping_cart_link"));
        private IWebElement firstNameInput => _driver.FindElement(By.Id("first-name"));
        private IWebElement lastNameInput => _driver.FindElement(By.Id("last-name"));
        private IWebElement postCodeInput => _driver.FindElement(By.Id("postal-code"));
        private IWebElement continueBtn => _driver.FindElement(By.Id("continue"));

        public CheckOutStepTwoPage FillInClientsData(string firstName, string lastName, string postalCode)
        {
            string currentURL = _driver.Url;
            firstNameInput.Clear();
            firstNameInput.SendKeys(firstName);

            lastNameInput.Clear();
            lastNameInput.SendKeys(lastName);

            postCodeInput.Clear();
            postCodeInput.SendKeys(postalCode);

            continueBtn.Click();
            if (currentURL.Equals(_driver.Url))
                return null;
            else
                return new CheckOutStepTwoPage(_driver);
        }

        public string GetErrorMessage()
        {
            IWebElement errorMessageDiv = _driver.FindElement(By.CssSelector("[data-test='error']"));
            return errorMessageDiv.Text;
        }
    }
}

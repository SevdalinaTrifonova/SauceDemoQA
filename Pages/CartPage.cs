using OpenQA.Selenium;


namespace SauceDemoQA.Pages
{
    class CartPage
    {
        protected IWebDriver _driver;
        public CartPage(IWebDriver driver) => _driver = driver;
        private IWebElement checkoutBtn=>_driver.FindElement(By.Id("checkout"));
                
        public CheckOutStepOnePage CheckOutProceed()
        {
            checkoutBtn.Click();
            return new CheckOutStepOnePage(_driver);
        }
    }
}

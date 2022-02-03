using System;
using OpenQA.Selenium;


namespace SauceDemoQA.Pages
{
    class CheckOutStepTwoPage
    {
        protected IWebDriver _driver;
        public CheckOutStepTwoPage(IWebDriver driver) => _driver = driver;
        private IWebElement finishBtn => _driver.FindElement(By.Id("finish"));

           
        public CheckOutCompletePage FinishCheckoutBtn()
        {
            string currentURL = _driver.Url;
            finishBtn.Click();
            if (currentURL.Equals(_driver.Url))
                return null;
            else
                return new CheckOutCompletePage(_driver);
        }
    }
}

using OpenQA.Selenium;

namespace SauceDemoQA.Pages
{
    class CheckOutCompletePage
    {
        protected IWebDriver _driver;
        public CheckOutCompletePage(IWebDriver driver) => _driver = driver;
    }
}

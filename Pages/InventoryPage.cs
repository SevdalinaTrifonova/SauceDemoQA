using System;

using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SauceDemoQA.Pages
{
    class InventoryPage
    {
        private const string ADD_TO_CARD_LOCATOR = "//button[@id='add-to-cart-{0}']";
        private const string REMOVE_FROM_CARD_LOCATOR = "//button[@id='remove-{0}']";
        protected IWebDriver _driver;

        public InventoryPage(IWebDriver driver) => _driver = driver;

        private IWebElement shoppingCartLink => _driver.FindElement(By.ClassName("shopping_cart_link"));
        private IWebElement resetAppLink=> _driver.FindElement(By.Id("reset_sidebar_link"));
        private IWebElement burgerMenuBtn => _driver.FindElement(By.Id("react-burger-menu-btn"));
        private IWebElement closeBurgerMenuBtn => _driver.FindElement(By.Id("react-burger-cross-btn"));
        private ReadOnlyCollection<IWebElement> inventoryItemImgList => _driver.FindElements(By.XPath("//img[@class='inventory_item_img']"));

        public void AddToCartByProductName(string productName)
        {
            string xPathOfProduct = string.Format(ADD_TO_CARD_LOCATOR, productName);
            IWebElement addToCartBtn = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(xPathOfProduct))));
            if (addToCartBtn.Displayed)
                addToCartBtn.Click();

        }

        public void RemoveFromCartByProductName(String productName)
        {   
            string xPathOfProduct = string.Format(REMOVE_FROM_CARD_LOCATOR, productName);
            IWebElement removeBtn = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(xPathOfProduct))));
            if (removeBtn.Displayed)
                removeBtn.Click();
        }

        public bool CheckRemovedFromCartByProductName(String productName)
        {
            string xPathOfProduct = string.Format(ADD_TO_CARD_LOCATOR, productName);
            IWebElement addToCartBtn = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(xPathOfProduct))));
            return addToCartBtn.Displayed;
        }

        public bool CheckAddedToCartByProductName(String productName)
        {
            string xPathOfProduct = string.Format(REMOVE_FROM_CARD_LOCATOR, productName);
            IWebElement removeBtn = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath(xPathOfProduct))));
            return removeBtn.Displayed;
        }


        public void ResetApp()
        {
            burgerMenuBtn.Click();
            resetAppLink.Click();
            _driver.Navigate().Refresh();
        }

        public CartPage GoToCart()
        {
            shoppingCartLink.Click();
            return new CartPage(_driver);
        }

        public void AddFirstFoundItemToCart()
        {
            ReadOnlyCollection<IWebElement> addToCartBtnList = _driver.FindElements(By.XPath("//*[contains(@id, 'add-to-cart-')]"));
            if (addToCartBtnList.Count()>0)
                addToCartBtnList.ElementAt(0).Click();
        }


        public ReadOnlyCollection<IWebElement> GetInventoryItemImgList()
        {
            return inventoryItemImgList;
        }
 
    }
}

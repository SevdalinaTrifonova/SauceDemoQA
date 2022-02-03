using NUnit.Framework;
using SauceDemoQA.Base;
using SauceDemoQA.Pages;
using System.Collections.Generic;
using SauceDemoQA.DataProviders;
using static SauceDemoQA.DataProviders.ItemsToCartData;

namespace SauceDemoQA.Tests
{

    /*
    *Add or Remove Items to Cart
    *reads test cases from itemToCart.json
    *The test are executed as standard user
    */
     

    [TestFixture]
    class ItemsToCartTest :TestUtil
    {
       private InventoryPage inventoryPage;
       
        [OneTimeSetUp]
        public void LoginAsStdUser()
        {
            LoginPage loginPage = new LoginPage(driver);
            inventoryPage = loginPage.Login(config.UserName, config.Password);
            Assert.IsFalse((inventoryPage == null), "Wrong credentials");
        }

       [SetUp]
       public void resetApp()
        {
            inventoryPage.ResetApp();
        }


        [Test, TestCaseSource(typeof(ItemsToCartData), nameof(ItemsToCartData.ItemToCartTestCases))]
        public void ItemToCart(string display_name, List<Product> items)
        {
            Assert.Multiple(() =>
            {
                foreach (Product pr in items)
                {
                    if (pr.action.Equals("remove"))
                    {
                        inventoryPage.RemoveFromCartByProductName(pr.itemName);
                        Assert.IsTrue(inventoryPage.CheckRemovedFromCartByProductName(pr.itemName), string.Format("{0} not removed", pr.itemName));
                    }
                    else
                    {
                        inventoryPage.AddToCartByProductName(pr.itemName);
                        Assert.IsTrue(inventoryPage.CheckAddedToCartByProductName(pr.itemName), string.Format("{0} not added", pr.itemName));
                    }

                };
            });

        }

    }
}

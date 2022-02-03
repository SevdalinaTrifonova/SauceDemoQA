using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoQA.Base;
using SauceDemoQA.DataProviders;
using SauceDemoQA.Pages;
using System;
using System.Collections.ObjectModel;

namespace SauceDemoQA.Tests
{
    [TestFixture]
    class ItemImageLoadTest : TestUtil
    {

        [Test, TestCaseSource(typeof(UsersData), nameof(UsersData.LoginSuccessTestCases))]
        public void ImageLoadTest(string userName, string password, bool expectedResult)
        {
            driver.Url= config.ApplicationUrl;
            LoginPage loginPage = new LoginPage(driver);
            InventoryPage inventoryPage = loginPage.Login(userName, password);
            Assert.Multiple(() =>
            {
                Assert.AreEqual((!(inventoryPage == null)), expectedResult, string.Format("Unexpected Login behaviour {0} {1}", userName, password));
                if (!(inventoryPage == null))
                {
                    ReadOnlyCollection<IWebElement> inventoryItemImgList = inventoryPage.GetInventoryItemImgList();
                    bool successLoad = true;
                    foreach (IWebElement el in inventoryItemImgList)
                    {
                        if (el.GetAttribute("src").Equals(config.ApplicationUrl + config.Picture404))
                        {
                            successLoad = false;
                            break;
                        }
                    }
                    Assert.IsTrue(successLoad, string.Format("Item images are not property loaded for {0} {1}", userName, password));
                }
            });

        }

       
    }
}

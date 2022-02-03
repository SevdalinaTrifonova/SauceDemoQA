using SauceDemoQA.Pages;
using System;
using SauceDemoQA.Base;
using NUnit.Framework;
using SauceDemoQA.DataProviders;

namespace SauceDemoQA.Tests
{
    class CheckOutTest : TestUtil
    {
        protected CheckOutStepOnePage checkOutStepOnePage;
        protected CheckOutStepTwoPage checkOutStepTwoPage;
        protected CheckOutCompletePage checkOutCompletePage;
        private string checkOutStepOnePageURL;

        [OneTimeSetUp]
        public void GoToCheckOut()
            {
                LoginPage loginPage = new LoginPage(driver);
                InventoryPage inventoryPage = loginPage.Login(config.UserName, config.Password);
                Assert.IsFalse((inventoryPage == null), "Wrong credentials");
                inventoryPage.ResetApp();
                inventoryPage.AddFirstFoundItemToCart();
                CartPage cartPage = inventoryPage.GoToCart();
                checkOutStepOnePage = cartPage.CheckOutProceed();
                checkOutStepOnePageURL = driver.Url;
            }


        [Test, TestCaseSource(typeof(ClientsData), nameof(ClientsData.ClientsDataTestCases))]
        public void ProceedCheckout(string firstName, string lastName, string postalCode, bool expectedResult, string expectedErrorMessage)
        {
            Assert.Multiple(() =>
            {
                checkOutStepTwoPage = checkOutStepOnePage.FillInClientsData(firstName, lastName, postalCode);
                Assert.AreEqual(!(checkOutStepTwoPage == null), expectedResult,
                        string.Format("Unexpected Client data fill in behaviour {0} {1} {2}", firstName, lastName, postalCode));
                if (checkOutStepTwoPage == null)
                {
                    String errorMessage = checkOutStepOnePage.GetErrorMessage();
                    Assert.AreEqual(errorMessage, "Error: "+expectedErrorMessage, string.Format("Unexpected error message: {0}", errorMessage));
                }
                else
                {
                    //Continue Checkout
                    checkOutCompletePage = checkOutStepTwoPage.FinishCheckoutBtn();
                    Assert.IsFalse(checkOutCompletePage == null, "Unsuccessful Finish of Check out");
                }
            });
        }

        [TearDown]
         //go back to checkOutStepOnePage
        public void ResetLoginPage()
            {
                driver.Url=checkOutStepOnePageURL;
            }
    }
}

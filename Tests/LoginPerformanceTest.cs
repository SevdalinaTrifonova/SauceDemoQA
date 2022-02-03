using NUnit.Framework;
using SauceDemoQA.Base;
using SauceDemoQA.DataProviders;
using SauceDemoQA.Pages;
using System;


namespace SauceDemoQA.Tests
{
    [TestFixture]
    class LoginPerformanceTest : TestUtil
    {
        protected InventoryPage inventoryPage;
        protected long stdResponseTime;
     
                [OneTimeSetUp]
                public void MeasureStandardUserPerformance()
                {
                    driver.Url = config.ApplicationUrl;
                    LoginPage loginPage = new LoginPage(driver);
                    long startTime = DateTime.Now.ToFileTime();
                    inventoryPage = loginPage.Login(config.UserName, config.Password);
                    long endTime = DateTime.Now.ToFileTime();
                    stdResponseTime = endTime - startTime;
                    Assert.IsFalse((inventoryPage == null), "Wrong credentials");
                    //set back to Login page
                    driver.Url= config.ApplicationUrl;

                }

              
        [Test, TestCaseSource(typeof(UsersData), nameof(UsersData.LoginSuccessTestCases))]
        public void LoginPerforTest(string userName, string password, bool expectedResult)
                {
                    //set to Login page
                    driver.Url = config.ApplicationUrl;
                    LoginPage loginPage = new LoginPage(driver);
                    long startTime = DateTime.Now.ToFileTime();
                    InventoryPage inventoryPage = loginPage.Login(userName, password);
                    long endTime = DateTime.Now.ToFileTime();
                    long responseTime = endTime - startTime;

                    Assert.Multiple(() =>
                    {
                        Assert.AreEqual((!(inventoryPage == null)), expectedResult, string.Format("Unexpected Login behaviour {0} {1}", userName, password));
                        Assert.IsFalse(responseTime > stdResponseTime + 1000, string.Format("Response for user {0} is too slow", userName));

                    });
                 }
            
     
    }

}

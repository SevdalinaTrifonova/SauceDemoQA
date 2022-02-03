using NUnit.Framework;
using SauceDemoQA.Base;
using SauceDemoQA.DataProviders;
using SauceDemoQA.Pages;

namespace SauceDemoQA.Tests
{
    [TestFixture]
    public class LoginTest : TestUtil
    {

        [Test, TestCaseSource(typeof(UsersData), nameof(UsersData.UsersDataTestCases))]
        public void LoginUser(string userName, string password, bool expectedResult)
        {
            driver.Url = config.ApplicationUrl;
            LoginPage loginPage = new LoginPage(driver);
            InventoryPage inventoryPage = loginPage.Login(userName, password);
            Assert.AreEqual(!(inventoryPage == null), expectedResult, string.Format("Unexpected Login behaviour %s %s", userName, password));

        }
    }
}
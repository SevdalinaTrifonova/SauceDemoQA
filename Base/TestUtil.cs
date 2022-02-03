using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using SauceDemoQA.Configurations;
using System;
using System.IO;
/*
 * Base Class
 * create and quit driver 
 * loads application configurations 
 *  
 */
namespace SauceDemoQA.Base
{
    [TestFixture]
    [Parallelizable]
    public class TestUtil 
    {
        public IWebDriver driver;
        public Configuration config;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            JsonSerializer serializer = new JsonSerializer();                 
            config = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(@"../../../Configurations/configurations.json"));
            switch (config.TargetBrowser)
            {
                case "chrome":
                    driver = new ChromeDriver(); 
                    break;
                case "edge":
                    driver = new EdgeDriver();
                    break;
            }

            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(config.ImplicitWaitSeconds);
            driver.Navigate().GoToUrl(config.ApplicationUrl);
        }

            
       
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

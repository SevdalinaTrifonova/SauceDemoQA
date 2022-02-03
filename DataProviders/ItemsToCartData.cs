using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoQA.DataProviders
{
    public class ItemsToCartData
    {
        public class Product
        {
            public string itemName { get; set; }
            public string action { get; set; }
        }

        private class TestCase
        {
            public string display_name { get; set; }
            public List<Product> items { get; set; }
        }

        private class ProductToCartTestCases
        {
            public List<TestCase> TestCases { get; set; }
        }

        public static IEnumerable<object[]> ItemToCartTestCases()
            {
                JsonSerializer serializer = new JsonSerializer();
                ProductToCartTestCases userTestCases = JsonConvert.DeserializeObject<ProductToCartTestCases>(File.ReadAllText(@"../../../JsonTestCases/itemsToCart.json"));
                TestCase[] testCaseList = userTestCases.TestCases.ToArray();
                foreach (TestCase tc in testCaseList)
                {
                    yield return new object[] { tc.display_name, tc.items };

                }
            }

      
    }

}


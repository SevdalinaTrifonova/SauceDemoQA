using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace SauceDemoQA.DataProviders
{
    class ClientsData
    {
        public class TestCase
        {
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string post_code { get; set; }
            public bool expected_result { get; set; }
            public string error_message { get; set; }
        }

        public class ClientsTestCases
        {
            public List<TestCase> TestCases { get; set; }
        }

        public static IEnumerable<object[]> ClientsDataTestCases()
        {
            JsonSerializer serializer = new JsonSerializer();
            ClientsTestCases clientsTestCases = JsonConvert.DeserializeObject<ClientsTestCases>(File.ReadAllText(@"../../../JsonTestCases/clients_testcases.json"));
            TestCase[] testCaseList = clientsTestCases.TestCases.ToArray();
            foreach (TestCase tc in testCaseList)
            {
                yield return new object[] { tc.first_name, tc.last_name, tc.post_code, tc.expected_result, tc.error_message };

            }
        }
    }
}

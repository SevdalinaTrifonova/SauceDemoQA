using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;


namespace SauceDemoQA.DataProviders
{
    public class UsersData
    {
        private class TestCase
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public bool ExpectedResult { get; set; }
        }

        private class UserLoginTestCases
        {
            public List<TestCase> TestCases { get; set; }
        }

       
        public static IEnumerable<object[]> UsersDataTestCases()
        {
            JsonSerializer serializer = new JsonSerializer();
            UserLoginTestCases userTestCases = JsonConvert.DeserializeObject<UserLoginTestCases>(File.ReadAllText(@"../../../JsonTestCases/users_testcases.json"));
            TestCase[] testCaseList = userTestCases.TestCases.ToArray();
            foreach (TestCase tc in testCaseList)
            { 
                yield return new object[] { tc.UserName, tc.Password, tc.ExpectedResult };
               
            }
         }

        public static IEnumerable<object[]> LoginSuccessTestCases()
        {
            JsonSerializer serializer = new JsonSerializer();
            UserLoginTestCases userTestCases = JsonConvert.DeserializeObject<UserLoginTestCases>(File.ReadAllText("C:/JSONDataDir/users_testcases.json"));
            TestCase[] testCaseList = userTestCases.TestCases.ToArray();
            foreach (TestCase tc in testCaseList)
            {
                if (tc.ExpectedResult)
                    yield return new object[] { tc.UserName, tc.Password, tc.ExpectedResult };

            }
        }
              
    }
}

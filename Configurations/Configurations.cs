using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoQA.Configurations
{
    // Configurations myDeserializedClass = JsonConvert.DeserializeObject<Configurations>(myJsonResponse);
    public class Configuration
    {
        public string ApplicationUrl { get; set; }
        public string TargetBrowser { get; set; }
        public int ImplicitWaitSeconds { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Picture404 { get; set; }
              
    }
}

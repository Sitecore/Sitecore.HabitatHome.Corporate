using System.Configuration;
using Sitecore.Demo.Foundation.Test;

namespace Sitecore.HabitatHomeCorporate.Website.Test
{
    public class HabitatHomeCorporateTests : SeleniumTest
    {
        public HabitatHomeCorporateTests()
        {
            var settings = ConfigurationManager.AppSettings;
            Host = settings["Host"];
            UserEmail = settings["UserEmail"];
            UserPassword = settings["UserPassword"];
        }

        public string Host { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
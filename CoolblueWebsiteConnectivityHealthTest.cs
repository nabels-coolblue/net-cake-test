using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Coolblue.Utilities.ApplicationHealth;

namespace WindowsServiceWithOwin
{
    public class CoolblueWebsiteConnectivityHealthTest : HealthTest
    {
        private static HttpClient _httpClient = new HttpClient();

        protected override TestResult DetermineHealth()
        {
            try
            {
                using(var response = _httpClient.GetAsync("https://www.coolblue.nl/").Result)
                {
                    response.EnsureSuccessStatusCode();
                    return TestResult.Pass;
                }
            }
            catch(Exception ex)
            {
                return TestResult.Fail;
            }
        }

        protected override string HealthTestName => "Coolblue website connectivity check";
    }
}

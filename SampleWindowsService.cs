using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using Coolblue.Utilities.ApplicationHealth;
using Coolblue.Utilities.ApplicationHealth.SelfHost;

namespace WindowsServiceWithOwin
{
    public class SampleWindowsService
    {
        private SelfHostedApplicationHealthApi _healthApi;
        private const int WebserverPort = 80;

        public void Start()
        {
            _healthApi = SelfHostedApplicationHealthApi
                .WithMetadataFromAssembly(
                    WebserverPort,
                    new [] { new CoolblueWebsiteConnectivityHealthTest() },
                    Assembly.GetAssembly(typeof(Program)),
                    DateTimeOffset.Now);
            
            _healthApi.Start();   
        }

        public void Stop()
        {
            _healthApi.Stop();
        }
    }
}
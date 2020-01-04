﻿using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestApi.IntegrationTest.Fixtures
{
    public class TestServerHttpClientFactory : IHttpClientFactory
    {
        private readonly TestServer _testServer;

        public TestServerHttpClientFactory(TestServer testServer)
        {
            _testServer = testServer;
        }

        public HttpClient CreateClient(string name)
        {
            return _testServer.CreateClient();
        }
    }
}
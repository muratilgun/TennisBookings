﻿using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace TennisBookings.Web.IntegrationTests.Controllers
{
    public class AdminHomeControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public AdminHomeControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            factory.ClientOptions.AllowAutoRedirect = false;            
            _factory = factory;
        }

        [Fact]
        public async Task Get_SecurePageIsForbiddenForAnUnauthenticatedUser()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/Admin");
            Assert.Equal(HttpStatusCode.Redirect,response.StatusCode);
            Assert.StartsWith("http://localhost/identity/account/login",response.Headers.Location.OriginalString,StringComparison.OrdinalIgnoreCase);
        }
    }
}

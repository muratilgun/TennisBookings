using System;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using TennisBookings.Web.IntegrationTests.Helpers;
using Xunit;

namespace TennisBookings.Web.IntegrationTests.Pages
{
    public class BookingsPageTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public BookingsPageTests(CustomWebApplicationFactory<Startup> factory)
        {
            factory.ClientOptions.BaseAddress = new Uri("http://localhost/bookings");
            _factory = factory;
        }

        [Fact]
        public async Task NoBookingTableOnPage_WhenUserHasNoBookings()
        {
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddAuthentication("Test")
                        .AddScheme<TestAuthenticationSchemeOptions, TestAuthenticationHandler>("Test", options => options.Role = "Member");

                });
            }).CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");
            var response = await client.GetAsync("");
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
            using var content = await HtmlHelpers.GetDocumentAsync(response);
            var table = content.QuerySelector("table");
            Assert.Null(table);
            var paragraphs = content.QuerySelectorAll("p").Where(e=> e.TextContent == "You have no upcoming court bookings.").ToArray();

            Assert.Single(paragraphs);

        }
    }
}


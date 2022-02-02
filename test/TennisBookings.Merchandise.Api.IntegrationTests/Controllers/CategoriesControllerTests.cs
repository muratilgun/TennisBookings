using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using TennisBookings.Merchandise.Api.IntegrationTests.Models;
using TennisBookings.Merchandise.Api.IntegrationTests.TestHelpers;
using Xunit;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TennisBookings.Merchandise.Api.IntegrationTests.Controllers
{
    public class CategoriesControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        public CategoriesControllerTests(WebApplicationFactory<Startup> factory)
        {
            //_client = factory.CreateDefaultClient();
            //_client = factory.CreateDefaultClient(new Uri("http://localhost/api/categories"));
            factory.ClientOptions.BaseAddress = new Uri("http://localhost/api/categories");
            _client = factory.CreateClient();
        }

        #region OLD TESTS
        //[Fact]
        //public async Task GetAll_ReturnsSuccessStatus()
        //{
        //    var response = await _client.GetAsync("");
        //    response.EnsureSuccessStatusCode();
        //}

        //[Fact]
        //public async Task GetAll_ReturnsExpectedMediaType()
        //{
        //    var response = await _client.GetAsync("");
        //    Assert.Equal("application/json",response.Content.Headers.ContentType.MediaType);
        //}

        //[Fact]
        //public async Task GetAll_ReturnsContent()
        //{
        //    var response = await _client.GetAsync("");
        //    Assert.NotNull(response.Content);
        //    Assert.True(response.Content.Headers.ContentLength > 0);
        //}

        //[Fact]
        //public async Task GetAll_ReturnsExpectedJson()
        //{
        //    //var response = await _client.GetStringAsync("api/Categories");
        //    //Assert.Equal("{\"allowedCategories\":[\"Accessories\",\"Bags\",\"Balls\",\"Clothing\",\"Rackets\"]}",response);
        //    var expected = new List<string> { "Bags", "Balls", "Accessories", "Clothing", "Rackets" };
        //    var responseStream = await _client.GetStreamAsync("");
        //    var model = await JsonSerializer.DeserializeAsync<ExpectedCategoriesModel>(responseStream,JsonSerializerHelper.DefaultDeserialisationOptions);
        //    Assert.NotNull(model?.AllowedCategories);
        //    Assert.Equal(expected.OrderBy(s=> s),model.AllowedCategories.OrderBy(s=> s));
        //} 
        #endregion

        [Fact]
        public async Task GetAll_ReturnsExpectedResponse()
        {
            var expected = new List<string> { "Bags", "Balls", "Accessories", "Clothing", "Rackets" };
            var model = await _client.GetFromJsonAsync<ExpectedCategoriesModel>("");
            Assert.NotNull(model?.AllowedCategories);
            Assert.Equal(expected.OrderBy(s => s), model.AllowedCategories.OrderBy(s => s));

        }

        [Fact]
        public async Task GetAll_SetsExpectedCacheControlHeader()
        {
            var response = await _client.GetAsync("");
            var header = response.Headers.CacheControl;
            Assert.True(header.MaxAge.HasValue);
            Assert.Equal(TimeSpan.FromMinutes(5),header.MaxAge);
            Assert.True(header.Public);
        }
    }
}

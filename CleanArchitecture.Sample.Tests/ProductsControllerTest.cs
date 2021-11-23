using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Sample.Tests
{
    public class ProductsControllerTest
    {
        private readonly HttpClient _client;
        public ProductsControllerTest()
        {
            // Está dando
            var server = new TestServer(new WebHostBuilder());
            _client = server.CreateClient();
        }

        [Fact]
        public async Task GET_all_products()
        {
            var response = await _client.GetAsync("/api/Products");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
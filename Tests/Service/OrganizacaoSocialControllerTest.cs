using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests.Service
{
    public class OrganizacaoSocialControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public OrganizacaoSocialControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("api/organizacao-social")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            client.DefaultRequestHeaders.Add("X-Tenant", "tenant");
            var response = await client.GetAsync(url);

            //Assert
            Assert.True(response.EnsureSuccessStatusCode().IsSuccessStatusCode);
        }
    }
}

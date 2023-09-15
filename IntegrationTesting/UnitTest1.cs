using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Net;

namespace IntegrationTesting
{
    public class UrlTesting : IClassFixture<WebApplicationFactory<WebAppPipeline.Startup>>
    {
        private readonly WebApplicationFactory<WebAppPipeline.Startup> _factory;

        public  UrlTesting(WebApplicationFactory<WebAppPipeline.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Home/Privacy")]
        [InlineData("/Individuo")]
        [InlineData("/Individuo/Index")]
        public async Task Testar_Endpoints_Header_ContentType(string url)
        {
            var cliente = _factory.CreateClient();

            var resposta = await cliente.GetAsync(url);

            resposta.EnsureSuccessStatusCode(); //200-299
            Assert.Equal("text/html; charset=utf-8", resposta.Content.Headers.ContentType.ToString());
        }
        [Theory]
        [InlineData("/")]
        [InlineData("/Home/Privacy")]
        [InlineData("/Individuo")]
        [InlineData("/Individuo/Index")]
        public async Task Testar_Endpoints_StatusCode(string url)
        {
            var cliente = _factory.CreateClient();

            var resposta = await cliente.GetAsync(url);

  
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
        }

        [Fact]
        public async Task Testar_HomePage()
        {
            var cliente = _factory.CreateClient();

            var resposta = await cliente.GetAsync("/");

            string resultado = await resposta.Content.ReadAsStringAsync();

            Assert.Contains(resultado, resultado);
        }
    }
}

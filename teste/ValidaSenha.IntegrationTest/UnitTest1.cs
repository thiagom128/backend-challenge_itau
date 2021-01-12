using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ValidaSenha.IntegrationTest
{
    public class ValidaSenhaControllerTests
    {
        public HttpClient httpClient;

        [OneTimeSetUp]
        public void Setup()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<IStartup>();

            var testServer = new TestServer(builder);
            httpClient = testServer.CreateClient();
        }

        [Test]
        public async Task PostDeveRetornarBadRequestCasoInputNaoExistaNoObjetoEnviado()
        {
            var objetoComParametroInvalido = JsonSerializer.Serialize(new { parametroErrado = "AbTp9!foo" });
            var post = new HttpRequestMessage(HttpMethod.Post, "api/Security/ValidPassword")
            {
                Content = new StringContent(objetoComParametroInvalido, Encoding.UTF8, "application/json")
            };

            var retorno = await httpClient.SendAsync(post);

            retorno.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task PostDeveRetornarBadRequestCasoInputSejaVazio()
        {
            var objetoComParametroInvalido = JsonSerializer.Serialize(new { input = "" });
            var post = new HttpRequestMessage(HttpMethod.Post, "api/Security/ValidPassword")
            {
                Content = new StringContent(objetoComParametroInvalido, Encoding.UTF8, "application/json")
            };

            var retorno = await httpClient.SendAsync(post);

            retorno.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestCase("aa", false)]
        [TestCase("ab", false)]
        [TestCase("AAAbbbCc", false)]
        [TestCase("AbTp91foo", false)]
        [TestCase("aaaaaaaa!", false)]
        [TestCase("AAAAAAAA!", false)]
        [TestCase("99999999!", false)]
        [TestCase("AbTp9!foo", true)]
        [TestCase("F3rn@ndo12", true)]
        public async Task PostDeveRetornarObjetoComParametroOutputBooleanoDeAcordoComEsperado(string senha, bool resultadoEsperado)
        {
            var senhaParaValidacao = JsonSerializer.Serialize(new { input = senha });
            var post = new HttpRequestMessage(HttpMethod.Post, "api/Security/ValidPassword")
            {
                Content = new StringContent(senhaParaValidacao, Encoding.UTF8, "application/json")
            };
            var retornoEsperado = JsonSerializer.Serialize(new { output = resultadoEsperado });

            var retorno = await httpClient.SendAsync(post);

            var valorRetornadoDaApi = await retorno.Content.ReadAsStringAsync();
            valorRetornadoDaApi.Should().BeEquivalentTo(retornoEsperado);
        }
    }
}
using FluentAssertions;
using Newtonsoft.Json;
using ProjetoAgendaAPI.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjetoAgenda.IntegrationTest.v1.UsuarioTeste
{
    public class UsuarioTesteIntegracao
    {
        string urlBase = "/api/v1/usuario";

        /// <summary>
        /// Recuperando usuário por id, sem ainda não ter nenhum cadastrado. O esperado é NotFound.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetUsuarioPorId()
        {
            using (HttpClient client = new ClientProvider().Client)
            {
                var response = await client.GetAsync(string.Concat(urlBase, "/-5"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Fazendo login sem nome. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task LoginSemNome()
        {
            using (HttpClient client = new ClientProvider().Client)
            {
                var response = await client.GetAsync(string.Concat(urlBase, "/", "senha"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Fazendo login sem senha. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task LoginSemSenha()
        {
            using (HttpClient client = new ClientProvider().Client)
            {
                var response = await client.GetAsync(string.Concat(urlBase, "/nome", ""));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando criar um usuário sem nome. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TentandoCriarUsuarioSemNome()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, false, true);
            using (HttpClient client = new ClientProvider().Client)
            {
                var response = await client.PostAsync(urlBase, new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando criar um usuário sem email. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TentandoCriarUsuarioSemEmail()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(false, true, true);
            using (HttpClient client = new ClientProvider().Client)
            {
                var response = await client.PostAsync(urlBase, new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando criar um usuário sem senha. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TentandoCriarUsuarioSemSenha()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, false);
            using (HttpClient client = new ClientProvider().Client)
            {
                var response = await client.PostAsync(urlBase, new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando criar um usuário nulo. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TentandoCriarUsuarioNulo()
        {
            using (HttpClient client = new ClientProvider().Client)
            {
                var response = await client.PostAsync(urlBase, new StringContent("", Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }
    }
}

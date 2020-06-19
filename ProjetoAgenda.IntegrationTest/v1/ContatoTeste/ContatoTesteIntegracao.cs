using FluentAssertions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ProjetoAgendaAPI.Models;
using Newtonsoft.Json;
using ProjetoAgenda.IntegrationTest.v1.UsuarioTeste;

namespace ProjetoAgenda.IntegrationTest.v1.ContatoTeste
{
    public class ContatoTesteIntegracao
    {
        string urlBase = "/api/v1/contato";

        [Fact]
        public async Task GetUsuarioPorId()
        {
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.GetAsync(string.Concat(urlBase, "/-5"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        [Fact]
        public async Task TentandoCriarContatoSemIdUsuario()
        {
            Contato contato = ContatoInformacaoTeste.CriandoInformacoesContato(true);
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(urlBase, new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        [Fact]
        public async Task TentandoCriarContatoSemNome()
        {
            using (HttpClient client = new ClientProvider().Client)
            {
                Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
                HttpResponseMessage response = await client.PostAsync(string.Concat("/api/v1/usuario"), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                usuario.Id = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result).Id;

                Contato contato = ContatoInformacaoTeste.CriandoInformacoesContato(false);
                contato.IdUsuario = usuario.Id;

                response = await client.PostAsync(urlBase, new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json"));

                HttpResponseMessage responseDelete = await client.DeleteAsync(string.Concat("/api/v1/usuario/", usuario.Id));
                responseDelete.StatusCode.Should().Be(HttpStatusCode.OK);

                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        [Fact]
        public async Task TentandoCriarContatoComIdUsuarioInvalido()
        {
            Contato contato = ContatoInformacaoTeste.CriandoInformacoesContato(true);
            contato.IdUsuario = -1;
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(urlBase, new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        [Fact]
        public async Task CriandoRecuperandoDeletandoContato()
        {
            using (HttpClient client = new ClientProvider().Client)
            {
                #region Criando Usuario
                Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
                HttpResponseMessage response = await client.PostAsync(string.Concat("/api/v1/usuario"), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                usuario.Id = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result).Id;
                #endregion

                #region Criando Contato
                Contato contato = ContatoInformacaoTeste.CriandoInformacoesContato(true);
                contato.IdUsuario = usuario.Id;

                response = await client.PostAsync(urlBase, new StringContent(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.Created);
                contato = JsonConvert.DeserializeObject<Contato>(response.Content.ReadAsStringAsync().Result);
                #endregion

                #region Buscando Contato
                response = await client.GetAsync(string.Concat(urlBase, "/", contato.Id, "/", contato.IdUsuario));
                contato = JsonConvert.DeserializeObject<Contato>(response.Content.ReadAsStringAsync().Result);
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                #endregion

                #region Buscando Todos Contatos Por Usuário
                response = await client.GetAsync(string.Concat(urlBase, "/", contato.IdUsuario));
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                #endregion

                #region Deletando Contato
                response = await client.DeleteAsync(string.Concat(urlBase, "/", contato.Id, "/", contato.IdUsuario));
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                #endregion

                #region Deletando Usuario
                HttpResponseMessage responseDelete = await client.DeleteAsync(string.Concat("/api/v1/usuario/", usuario.Id));
                responseDelete.StatusCode.Should().Be(HttpStatusCode.OK);
                #endregion
            }
        }
    }
}

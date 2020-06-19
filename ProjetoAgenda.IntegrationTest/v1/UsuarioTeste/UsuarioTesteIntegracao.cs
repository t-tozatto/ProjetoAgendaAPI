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
    [TestCaseOrderer("FullNameOfOrderStrategyHere", "OrderStrategyAssemblyName")]
    public class UsuarioTesteIntegracao
    {
        string urlBase = "/api/v1/usuario";

        /// <summary>
        /// Recuperando usuário por id inválida. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(1)]
        public async Task GetUsuarioPorId()
        {
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.GetAsync(string.Concat(urlBase, "/-5"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Fazendo login sem nome. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(2)]
        public async Task LoginSemNome()
        {
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.GetAsync(string.Concat(urlBase, "/", "senha"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Fazendo login sem senha. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(3)]
        public async Task LoginSemSenha()
        {
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.GetAsync(string.Concat(urlBase, "/nome", ""));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando criar um usuário sem nome. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(4)]
        public async Task TentandoCriarUsuarioSemNome()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, false, true);
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(urlBase, new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando criar um usuário sem email. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(5)]
        public async Task TentandoCriarUsuarioSemEmail()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(false, true, true);
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(urlBase, new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando criar um usuário sem senha. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(6)]
        public async Task TentandoCriarUsuarioSemSenha()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, false);
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(urlBase, new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando criar um usuário nulo. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(7)]
        public async Task TentandoCriarUsuarioNulo()
        {
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(urlBase, new StringContent("", Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando alterar um usuário passando uma id sendo que a classe do usuário irá ter outra id. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(8)]
        public async Task AlterandoUsuarioComIdErrada()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, false);
            usuario.Id = 15;
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PutAsync(string.Concat(urlBase, "/10"), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando alterar um usuário sem nome. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(9)]
        public async Task TentandoAlterarUsuarioSemNome()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, false, true);
            usuario.Id = 1;
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PutAsync(string.Concat(urlBase, "/1"), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando alterar um usuário sem email. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(10)]
        public async Task TentandoAlterarUsuarioSemEmail()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(false, true, true);
            usuario.Id = 1;
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PutAsync(string.Concat(urlBase, "/1"), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando alterar um usuário sem senha. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(11)]
        public async Task TentandoAlterarUsuarioSemSenha()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, false);
            usuario.Id = 1;
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PutAsync(string.Concat(urlBase, "/1"), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando alterar um usuário nulo. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(12)]
        public async Task TentandoAlterarUsuarioNulo()
        {
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PutAsync(string.Concat(urlBase, "/0"), new StringContent("", Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Deletando usuário com id inválida. O esperado é BadRequest.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(13)]
        public async Task ExcluindoPorIdInvalida()
        {
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.DeleteAsync(string.Concat(urlBase, "/0"));
                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Inserindo e excluindo usuário válido. O esperado é Created e OK
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(14)]
        public async Task InserindoExcluindoUsuario()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(string.Concat(urlBase), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                int id = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result).Id;
                response.StatusCode.Should().Be(HttpStatusCode.Created);

                response = await client.DeleteAsync(string.Concat(urlBase, "/", id));
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        /// <summary>
        /// Inserindo, alterando e excluindo usuário válido. O esperado é Created e OK
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(15)]
        public async Task InserindoAlterandoExcluindoUsuario()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(string.Concat(urlBase), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                usuario.Id = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result).Id;
                response.StatusCode.Should().Be(HttpStatusCode.Created);

                HttpResponseMessage responseAlteracao = await client.PutAsync(string.Concat(urlBase, "/", usuario.Id), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));

                HttpResponseMessage responseDelete = await client.DeleteAsync(string.Concat(urlBase, "/", usuario.Id));
                responseDelete.StatusCode.Should().Be(HttpStatusCode.OK);

                responseAlteracao.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        /// <summary>
        /// Tentando alterar usuário sem nome
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(16)]
        public async Task AlterandoUsuarioSemNome()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(string.Concat(urlBase), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                usuario.Id = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result).Id;
                response.StatusCode.Should().Be(HttpStatusCode.Created);

                usuario.Nome = string.Empty;
                HttpResponseMessage responseAlteracao = await client.PutAsync(string.Concat(urlBase, "/", usuario.Id), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));

                HttpResponseMessage responseDelete = await client.DeleteAsync(string.Concat(urlBase, "/", usuario.Id));
                responseDelete.StatusCode.Should().Be(HttpStatusCode.OK);

                responseAlteracao.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando alterar usuário sem senha
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(17)]
        public async Task AlterandoUsuarioSemSenha()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(string.Concat(urlBase), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                usuario.Id = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result).Id;
                response.StatusCode.Should().Be(HttpStatusCode.Created);

                usuario.Senha = string.Empty;
                HttpResponseMessage responseAlteracao = await client.PutAsync(string.Concat(urlBase, "/", usuario.Id), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));

                HttpResponseMessage responseDelete = await client.DeleteAsync(string.Concat(urlBase, "/", usuario.Id));
                responseDelete.StatusCode.Should().Be(HttpStatusCode.OK);

                responseAlteracao.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando alterar usuário sem id
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(18)]
        public async Task AlterandoUsuarioSemEmail()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(string.Concat(urlBase), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                int id = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result).Id;
                response.StatusCode.Should().Be(HttpStatusCode.Created);

                HttpResponseMessage responseAlteracao = await client.PutAsync(string.Concat(urlBase, "/", usuario.Id), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));

                HttpResponseMessage responseDelete = await client.DeleteAsync(string.Concat(urlBase, "/", id));
                responseDelete.StatusCode.Should().Be(HttpStatusCode.OK);

                responseAlteracao.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Tentando alterar usuário sem id
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(19)]
        public async Task AlterandoUsuarioNulo()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(string.Concat(urlBase), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                int id = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result).Id;
                response.StatusCode.Should().Be(HttpStatusCode.Created);

                HttpResponseMessage responseAlteracao = await client.PutAsync(string.Concat(urlBase, "/", 0), new StringContent(string.Empty, Encoding.UTF8, "application/json"));

                HttpResponseMessage responseDelete = await client.DeleteAsync(string.Concat(urlBase, "/", id));
                responseDelete.StatusCode.Should().Be(HttpStatusCode.OK);

                responseAlteracao.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando criar um usuário que ultrapassa o maxLength do campo senha.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(20)]
        public async Task TentandoCriarUsuarioMaxLengthSenha()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            usuario.Senha = "011654se6wergwergerge89r7g98er798g7g98er1";
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(urlBase, new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando criar um usuário que ultrapassa o maxLength do campo senha.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(21)]
        public async Task TentandoCriarUsuarioMinLengthSenha()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            usuario.Senha = "123";
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(urlBase, new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando criar um usuário que ultrapassa o maxLength do campo senha.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(22)]
        public async Task TentandoCriarUsuarioMaxLengthEmail()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            usuario.Email = "oefjhoejfwef87w7e1f987we987f98we7f897we8f4w6e54f65we4f654we68f79we7f98w7e9f87we987f98w7ef987we98f79w8e7f98w7e9f87w9e87f98we7f987we98f79w8e7f98w7ef98we65f4we64f96w8e74f98w7e9f87w98f7w89e4f6we4f98we4f984we9f84w9e8w8e94f98we4f984we98f49w8e4f98w4ef9889we4f9889e";
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(urlBase, new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando criar um usuário que ultrapassa o maxLength do campo senha.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(23)]
        public async Task TentandoCriarUsuarioMinLengthEmail()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            usuario.Email = "123";
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(urlBase, new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando criar um usuário que ultrapassa o maxLength do campo senha.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(24)]
        public async Task TentandoCriarUsuarioMaxLengthNome()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            usuario.Nome = "oefjhoejfwef87w7ef987w1e987f98we7f897we8f4w6e54f65we4f654we68f79we7f98w7e9f87we987f98w7ef987we98f79w8e7f98w7e9f87w9e87f98we7f987we98f79w8e7f98w7ef98we65f4we64f96w8e74f98w7e9f87w98f7w89e4f6we4f98we4f984we9f84w9e8w8e94f98we4f984we98f49w8e4f98w4ef9889we4f9889e";
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(urlBase, new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando criar um usuário que ultrapassa o maxLength do campo senha.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(25)]
        public async Task TentandoCriarUsuarioMinLengthNome()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            usuario.Nome = "123";
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(urlBase, new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando alterar um usuário que ultrapassa o maxLength do campo senha.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(26)]
        public async Task AlterandoUsuarioMaxLengthSenha()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(string.Concat(urlBase), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                usuario.Id = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result).Id;
                response.StatusCode.Should().Be(HttpStatusCode.Created);

                usuario.Senha = "123ewffwefweewfwe987f987we8f97w9e87fwe98f7";
                HttpResponseMessage responseAlteracao = await client.PutAsync(string.Concat(urlBase, "/", usuario.Id), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));

                HttpResponseMessage responseDelete = await client.DeleteAsync(string.Concat(urlBase, "/", usuario.Id));
                responseDelete.StatusCode.Should().Be(HttpStatusCode.OK);

                responseAlteracao.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        ///  Tentando alterar um usuário que ultrapassa sem o minLength do campo senha.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(27)]
        public async Task AlterandoUsuarioMinLengthSenha()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(string.Concat(urlBase), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                usuario.Id = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result).Id;
                response.StatusCode.Should().Be(HttpStatusCode.Created);

                usuario.Senha = "123";
                HttpResponseMessage responseAlteracao = await client.PutAsync(string.Concat(urlBase, "/", usuario.Id), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));

                HttpResponseMessage responseDelete = await client.DeleteAsync(string.Concat(urlBase, "/", usuario.Id));
                responseDelete.StatusCode.Should().Be(HttpStatusCode.OK);

                responseAlteracao.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando alterar um usuário que ultrapassa o maxLength do campo email.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(28)]
        public async Task AlterandoUsuarioMaxLengthEmail()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(string.Concat(urlBase), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                usuario.Id = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result).Id;
                response.StatusCode.Should().Be(HttpStatusCode.Created);

                usuario.Email = "ergiuherger7g987eg987er9gd49er4g5e4rg654er98g7e98g798e4rg98e4r9ger98g498er4g98er4g4r98g4e98r4g98er4g98e4r89g4e98r4g98er4g98e4r9g84er89g4e+r4g+r4g+r4g9er4g98r4g984er9g49e8r4g984erg984e9r4g98er4g984er9g84r9e84g98er4g984er98g4e98r4g98er4g98r8e4g9e8rg48r4g4reg8";
                HttpResponseMessage responseAlteracao = await client.PutAsync(string.Concat(urlBase, "/", usuario.Id), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));

                HttpResponseMessage responseDelete = await client.DeleteAsync(string.Concat(urlBase, "/", usuario.Id));
                responseDelete.StatusCode.Should().Be(HttpStatusCode.OK);

                responseAlteracao.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        ///  Tentando alterar um usuário que ultrapassa sem o minLength do campo email.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(29)]
        public async Task AlterandoUsuarioMinLengthEmail()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(string.Concat(urlBase), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                usuario.Id = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result).Id;
                response.StatusCode.Should().Be(HttpStatusCode.Created);

                usuario.Email = "123";
                HttpResponseMessage responseAlteracao = await client.PutAsync(string.Concat(urlBase, "/", usuario.Id), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));

                HttpResponseMessage responseDelete = await client.DeleteAsync(string.Concat(urlBase, "/", usuario.Id));
                responseDelete.StatusCode.Should().Be(HttpStatusCode.OK);

                responseAlteracao.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Tentando alterar um usuário que ultrapassa o maxLength do campo nome.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(30)]
        public async Task AlterandoUsuarioMaxLengthNome()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(string.Concat(urlBase), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                usuario.Id = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result).Id;
                response.StatusCode.Should().Be(HttpStatusCode.Created);

                usuario.Nome = "ergiuherger7g987eg987er9ag49er4g5e4rg654er98g7e98g798e4rg98e4r9ger98g498er4g98er4g4r98g4e98r4g98er4g98e4r89g4e98r4g98er4g98e4r9g84er89g4e+r4g+r4g+r4g9er4g98r4g984er9g49e8r4g984erg984e9r4g98er4g984er9g84r9e84g98er4g984er98g4e98r4g98er4g98r8e4g9e8rg48r4g4reg8";
                HttpResponseMessage responseAlteracao = await client.PutAsync(string.Concat(urlBase, "/", usuario.Id), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));

                HttpResponseMessage responseDelete = await client.DeleteAsync(string.Concat(urlBase, "/", usuario.Id));
                responseDelete.StatusCode.Should().Be(HttpStatusCode.OK);

                responseAlteracao.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        ///  Tentando alterar um usuário que ultrapassa sem o minLength do campo nome.
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(31)]
        public async Task AlterandoUsuarioMinLengthNome()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(string.Concat(urlBase), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                usuario.Id = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result).Id;
                response.StatusCode.Should().Be(HttpStatusCode.Created);

                usuario.Nome = "123";
                HttpResponseMessage responseAlteracao = await client.PutAsync(string.Concat(urlBase, "/", usuario.Id), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));

                HttpResponseMessage responseDelete = await client.DeleteAsync(string.Concat(urlBase, "/", usuario.Id));
                responseDelete.StatusCode.Should().Be(HttpStatusCode.OK);

                responseAlteracao.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Inserindo e excluindo usuário válido. O esperado é Created e OK
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(32)]
        public async Task InserindoUsuarioNomeRepetido()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(string.Concat(urlBase), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                int id = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result).Id;
                response.StatusCode.Should().Be(HttpStatusCode.Created);

                response = await client.PostAsync(string.Concat(urlBase), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.NotAcceptable);

                response = await client.DeleteAsync(string.Concat(urlBase, "/", id));
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        /// <summary>
        /// Inserindo e excluindo usuário válido. O esperado é Created e OK
        /// </summary>
        /// <returns></returns>
        [Fact, TestPriority(33)]
        public async Task InserindoUsuarioEmailRepetido()
        {
            Usuario usuario = UsuarioInformacoesTeste.CriandoInformacoesUsuario(true, true, true);
            using (HttpClient client = new ClientProvider().Client)
            {
                HttpResponseMessage response = await client.PostAsync(string.Concat(urlBase), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                int id = JsonConvert.DeserializeObject<Usuario>(response.Content.ReadAsStringAsync().Result).Id;
                response.StatusCode.Should().Be(HttpStatusCode.Created);

                usuario.Nome = "effwefwiwuehfiuwhefiue5fhweiufh89798751000";
                response = await client.PostAsync(string.Concat(urlBase), new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(HttpStatusCode.NotAcceptable);

                response = await client.DeleteAsync(string.Concat(urlBase, "/", id));
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
    }
}

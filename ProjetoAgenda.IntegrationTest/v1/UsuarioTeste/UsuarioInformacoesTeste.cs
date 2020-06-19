using ProjetoAgendaAPI.Models;

namespace ProjetoAgenda.IntegrationTest.v1.UsuarioTeste
{
    public static class UsuarioInformacoesTeste
    {
        public static Usuario CriandoInformacoesUsuario(bool email, bool nome, bool senha)
        {
            Usuario usuario = new Usuario();

            if (email)
                usuario.Email = "email@teste.com";

            if (nome)
                usuario.Nome = "Teste";

            if (senha)
                usuario.Senha = "teste123";

            return usuario;
        }
    }
}

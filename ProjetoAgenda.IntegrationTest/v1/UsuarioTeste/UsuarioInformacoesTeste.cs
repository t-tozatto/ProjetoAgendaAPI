using ProjetoAgendaAPI.Models;
using System;

namespace ProjetoAgenda.IntegrationTest.v1.UsuarioTeste
{
    public static class UsuarioInformacoesTeste
    {
        public static Usuario CriandoInformacoesUsuario(bool email, bool nome, bool senha)
        {
            Usuario usuario = new Usuario();

            if (email)
                usuario.Email = GerarStringRandomica(246);

            if (nome)
                usuario.Nome = GerarStringRandomica(256);

            if (senha)
                usuario.Senha = "teste123";

            return usuario;
        }

        private static string GerarStringRandomica(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return string.Concat(new String(stringChars), length == 246 ? "@teste.org" : string.Empty);
        }
    }
}

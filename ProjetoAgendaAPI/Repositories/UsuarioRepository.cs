using ProjetoAgendaAPI.Database;
using ProjetoAgendaAPI.Models;
using ProjetoAgendaAPI.Repositories.Contracts;
using System;

namespace ProjetoAgendaAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private AgendaContext _banco;
        public UsuarioRepository(AgendaContext banco)
        {
            _banco = banco;
        }

        public void Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string nome, string senha)
        {
            throw new NotImplementedException();
        }

        public Usuario ObterUsuario(string nome, string senha)
        {
            throw new NotImplementedException();
        }
    }
}

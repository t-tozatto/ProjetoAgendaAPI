using ProjetoAgendaAPI.Database;
using ProjetoAgendaAPI.Models;
using ProjetoAgendaAPI.Repositories.Contracts;
using System;
using System.Collections.Generic;

namespace ProjetoAgendaAPI.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private AgendaContext _banco;
        public ContatoRepository(AgendaContext banco)
        {
            _banco = banco;
        }

        public void Atualizar(Contato usuario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Contato usuario)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Contato ObterContato(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contato> ObterTodosContatos()
        {
            throw new NotImplementedException();
        }
    }
}

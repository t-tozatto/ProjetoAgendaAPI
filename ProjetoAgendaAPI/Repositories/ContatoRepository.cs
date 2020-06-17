using ProjetoAgendaAPI.Database;
using ProjetoAgendaAPI.Models;
using ProjetoAgendaAPI.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoAgendaAPI.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private AgendaContext _banco;
        public ContatoRepository(AgendaContext banco)
        {
            _banco = banco;
        }

        public void Atualizar(Contato contato)
        {
            _banco.Update(contato);
            _banco.SaveChanges();
        }

        public void Cadastrar(Contato contato)
        {
            _banco.Add(contato);
            _banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            _banco.Remove(ObterContato(id));
            _banco.SaveChanges();
        }

        public Contato ObterContato(int id)
        {
            return _banco.Contato.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<Contato> ObterTodosContatos()
        {
            return _banco.Contato;
        }
    }
}

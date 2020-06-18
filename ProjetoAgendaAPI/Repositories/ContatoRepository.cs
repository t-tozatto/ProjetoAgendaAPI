using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAgendaAPI.Database;
using ProjetoAgendaAPI.Models;
using ProjetoAgendaAPI.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAgendaAPI.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private AgendaContext _banco;
        public ContatoRepository(AgendaContext banco)
        {
            _banco = banco;
        }

        public void Cadastrar(Contato contato)
        {
            _banco.Contato.Add(contato);
            _banco.SaveChangesAsync();
        }

        public async Task<ActionResult<Contato>> ObterContato(int id)
        {
            return await _banco.Contato.FindAsync(id);
        }

        public async Task<ActionResult<IEnumerable<Contato>>> ObterTodosContatos()
        {
            return await _banco.Contato.ToListAsync();
        }

        public async Task<bool> Atualizar(Contato contato)
        {
            if (ContatoExiste(contato.Id))
            {
                _banco.Contato.Update(contato);
                await _banco.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            else
                return await Task.FromResult(false);
        }

        public bool Excluir(int id)
        {
            if (ContatoExiste(id))
            {
                _banco.Remove(ObterContato(id));
                _banco.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public bool ContatoExiste(int id)
        {
            return _banco.Contato.Any(e => e.Id.Equals(id));
        }
    }
}

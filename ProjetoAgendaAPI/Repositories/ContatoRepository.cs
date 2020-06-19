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
            _banco.SaveChanges();
        }

        public async Task<Contato> ObterContato(int id, int idUsuario)
        {
            return await _banco.Contato.FirstOrDefaultAsync(x => x.Id.Equals(id) && x.IdUsuario.Equals(idUsuario));
        }

        public async Task<IEnumerable<Contato>> ObterTodosContatos(int idUsuario)
        {
            return await _banco.Contato.Where(x => x.IdUsuario.Equals(idUsuario)).ToListAsync();
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

        public bool Excluir(int id, int idUsuario)
        {
            if (ContatoExiste(id))
            {
                _banco.Remove(_banco.Contato.FirstOrDefault(x => x.Id.Equals(id) && x.IdUsuario.Equals(idUsuario)));
                _banco.SaveChanges();
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

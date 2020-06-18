using Microsoft.AspNetCore.Mvc;
using ProjetoAgendaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoAgendaAPI.Repositories.Contracts
{
    public interface IContatoRepository
    {
        void Cadastrar(Contato contato);
        Task<ActionResult<Contato>> ObterContato(int id, int idUsuario);
        Task<ActionResult<IEnumerable<Contato>>> ObterTodosContatos(int idUsuario);
        Task<bool> Atualizar(Contato contato);
        bool Excluir(int id, int idUsuario);
        bool ContatoExiste(int id);
    }
}

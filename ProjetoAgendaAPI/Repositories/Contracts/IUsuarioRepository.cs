using Microsoft.AspNetCore.Mvc;
using ProjetoAgendaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoAgendaAPI.Repositories.Contracts
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        Task<ActionResult<Usuario>> ObterUsuario(int id);
        Task<ActionResult<IEnumerable<Usuario>>> ObterTodosUsuarios();
        Task<Usuario> Login(string nome, string senha);
        Task<bool> Atualizar(Usuario usuario);
        bool Excluir(int id);
        bool UsuarioExiste(int id);
    }
}

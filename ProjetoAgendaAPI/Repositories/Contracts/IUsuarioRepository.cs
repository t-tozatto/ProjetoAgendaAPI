using ProjetoAgendaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoAgendaAPI.Repositories.Contracts
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        Task<Usuario> ObterUsuario(int id);
        Task<IEnumerable<Usuario>> ObterTodosUsuarios();
        Task<Usuario> Login(string nome, string senha);
        Task<bool> Atualizar(Usuario usuario);
        bool Excluir(int id);
        bool UsuarioExiste(int id);
    }
}

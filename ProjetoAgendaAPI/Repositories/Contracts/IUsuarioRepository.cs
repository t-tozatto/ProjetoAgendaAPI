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
        /// <summary>
        /// 0 - Sem Erros
        /// 1 - Nome duplicado
        /// 2 - E-mail duplicado
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        int UsuarioComNomeSenhaOuEmailRepetido(Usuario usuario);
    }
}

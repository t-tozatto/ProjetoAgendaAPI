using ProjetoAgendaAPI.Models;

namespace ProjetoAgendaAPI.Repositories.Contracts
{
    interface IUsuarioRepository
    {
        Usuario Login(string nome, string senha);

        //CRUD
        void Cadastrar(Usuario usuario);
        Usuario ObterUsuario(string nome, string senha);
        void Atualizar(Usuario usuario);
        void Excluir(int id);
    }
}

using ProjetoAgendaAPI.Models;

namespace ProjetoAgendaAPI.Repositories.Contracts
{
    interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        Usuario Login(string nome, string senha);
        void Atualizar(Usuario usuario);
        void Excluir(int id);
    }
}

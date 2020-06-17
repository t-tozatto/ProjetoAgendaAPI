using ProjetoAgendaAPI.Database;
using ProjetoAgendaAPI.Models;
using ProjetoAgendaAPI.Repositories.Contracts;
using System.Linq;

namespace ProjetoAgendaAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private AgendaContext _banco;
        public UsuarioRepository(AgendaContext banco)
        {
            _banco = banco;
        }

        public void Atualizar(Usuario usuario)
        {
            _banco.Update(usuario);
            _banco.SaveChanges();
        }

        public void Cadastrar(Usuario usuario)
        {
            _banco.Add(usuario);
            _banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            _banco.Remove(ObterUsuario(id));
            _banco.SaveChanges();
        }

        public Usuario Login(string nome, string senha)
        {
            return _banco.Usuario.Where(x => x.Nome.Equals(nome) && x.Senha.Equals(senha)).FirstOrDefault();
        }

        public Usuario ObterUsuario(int id)
        {
            return _banco.Usuario.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }
    }
}

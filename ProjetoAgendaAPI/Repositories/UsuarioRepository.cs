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
    public class UsuarioRepository : IUsuarioRepository
    {
        private AgendaContext _banco;
        public UsuarioRepository(AgendaContext banco)
        {
            _banco = banco;
        }

        public void Cadastrar(Usuario usuario)
        {
            _banco.Add(usuario);
            _banco.SaveChanges();
        }

        public async Task<ActionResult<Usuario>> ObterUsuario(int id)
        {
            return await _banco.Usuario.FindAsync(id);
        }

        public async Task<ActionResult<IEnumerable<Usuario>>> ObterTodosUsuarios()
        {
            return await _banco.Usuario.ToListAsync();
        }

        public async Task<Usuario> Login(string nome, string senha)
        {
            return await _banco.Usuario.FirstOrDefaultAsync(x => x.Nome.Equals(nome) && x.Senha.Equals(senha));
        }

        public async Task<bool> Atualizar(Usuario usuario)
        {
            _banco.Update(usuario);
            _banco.SaveChanges();

            if (UsuarioExiste(usuario.Id))
            {
                _banco.Usuario.Update(usuario);
                await _banco.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            else
                return await Task.FromResult(false);
        }

        public bool Excluir(int id)
        {
            if (UsuarioExiste(id))
            {
                _banco.Remove(ObterUsuario(id));
                _banco.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public bool UsuarioExiste(int id)
        {
            return _banco.Usuario.Any(e => e.Id.Equals(id));
        }
    }
}

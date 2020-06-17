using ProjetoAgendaAPI.Models;
using System.Collections.Generic;

namespace ProjetoAgendaAPI.Repositories.Contracts
{
    interface IContatoRepository
    {
        //CRUD
        void Cadastrar(Contato usuario);

        Contato ObterContato(int id);
        IEnumerable<Contato> ObterTodosContatos();

        void Atualizar(Contato usuario);
        void Excluir(int id);
    }
}

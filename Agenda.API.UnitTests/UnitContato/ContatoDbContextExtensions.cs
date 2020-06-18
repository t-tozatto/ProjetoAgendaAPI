using Agenda.API.UnitTests.UsuarioContato;
using ProjetoAgendaAPI.Database;
using ProjetoAgendaAPI.Models;

namespace Agenda.API.UnitTests.UnitContato
{
    public static class ContatoDbContextExtensions
    {
        public static void CriarDadosContato(AgendaContext agendaContext)
        {
            UsuarioDbContextExtensions.CriarDadosUsuario(agendaContext);

            agendaContext.Contato.Add(new Contato()
            {
                Email = "lucascarloseduardobrenofernandes_@dizain.com.br",
                Id = 1,
                IdUsuario = 1,
                Nome = "Lucas",
                Sobrenome = "Fernandes",
                Telefone = "(92) 2649-9200",
            });

            agendaContext.Contato.Add(new Contato()
            {
                Email = "igorcastro@tortasecreta.com",
                Id = 2,
                IdUsuario = 1,
                Nome = "Igor",
                Sobrenome = "Castro",
                Telefone = "(24) 99735-3637",
            });

            agendaContext.Contato.Add(new Contato()
            {
                Email = "llouiseibrito@land.com.br",
                Id = 3,
                IdUsuario = 2,
                Nome = "Louise Isabelle",
                Sobrenome = "Brito",
                Telefone = "(66) 2562-8024",
            });

            agendaContext.Contato.Add(new Contato()
            {
                Email = "nicole.bernardes@construtorastaizabel.com.br",
                Id = 4,
                IdUsuario = 3,
                Nome = "Nicole",
                Sobrenome = "Bernardes",
                Telefone = string.Empty,
            });

            agendaContext.Contato.Add(new Contato()
            {
                Email = "valentina_alessandra@right.com.br",
                Id = 5,
                IdUsuario = 5,
                Nome = "Valentina",
                Sobrenome = "Sales",
                Telefone = "(91) 99116-1605",
            });

            agendaContext.Contato.Add(new Contato()
            {
                Email = string.Empty,
                Id = 6,
                IdUsuario = 5,
                Nome = "Luiza",
                Sobrenome = "Farias",
                Telefone = "(91) 2971-8054",
            });

            agendaContext.SaveChanges();
        }
    }
}

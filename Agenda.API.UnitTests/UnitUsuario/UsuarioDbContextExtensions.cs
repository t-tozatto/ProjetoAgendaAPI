using ProjetoAgendaAPI.Database;
using ProjetoAgendaAPI.Models;

namespace Agenda.API.UnitTests.UsuarioContato
{
    public static class UsuarioDbContextExtensions
    {
        public static void CriarDadosUsuario(AgendaContext agendaContext)
        {
            agendaContext.Usuario.Add(new Usuario
            {
                Email = "rodakab393@lerbhe.com",
                Id = 1,
                Nome = "t_tozatto",
                Senha = "123456",
            });

            agendaContext.Usuario.Add(new Usuario
            {
                Email = "xetamed214@royandk.com",
                Id = 2,
                Nome = "nick-silva",
                Senha = "password",
            });

            agendaContext.Usuario.Add(new Usuario
            {
                Email = "simox87619@qmrbe.com",
                Id = 3,
                Nome = "simon_costa",
                Senha = "a1b2c3d4",
            });

            agendaContext.Usuario.Add(new Usuario
            {
                Email = "favedar459@tastrg.com",
                Id = 4,
                Nome = "fabio",
                Senha = "",
            });

            agendaContext.Usuario.Add(new Usuario
            {
                Email = "kejej52832@rm2rf.com",
                Id = 5,
                Nome = "maria",
                Senha = "maria123",
            });

            agendaContext.SaveChanges();
        }
    }
}

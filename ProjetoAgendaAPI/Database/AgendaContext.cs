using Microsoft.EntityFrameworkCore;
using ProjetoAgendaAPI.Models;

namespace ProjetoAgendaAPI.Database
{
    public class AgendaContext : DbContext
    {
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }
    }
}

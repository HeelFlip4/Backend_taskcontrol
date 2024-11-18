using cadastro.Models;
using cadastro.Data.Map; 

using Microsoft.EntityFrameworkCore;

namespace cadastro.Data.Map
{
    public class CadastroDBcontex : DbContext
    {
        public CadastroDBcontex (DbContextOptions<CadastroDBcontex> options) 
            : base(options) 
        { 
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

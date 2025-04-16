using Microsoft.EntityFrameworkCore;
using TodoList.Modelos;

namespace TodoList.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) : base (options)
        {
            
        }

        public DbSet<Tareas> Tareas { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}

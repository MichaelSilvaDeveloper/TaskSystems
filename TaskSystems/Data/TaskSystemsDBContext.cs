using Microsoft.EntityFrameworkCore;
using TaskSystems.Data.Map;
using TaskSystems.Models;

namespace TaskSystems.Data
{
    public class TaskSystemsDBContext : DbContext
    {
        public TaskSystemsDBContext(DbContextOptions<TaskSystemsDBContext> options) : base(options)
        { 

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Tarefas> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TarefasMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
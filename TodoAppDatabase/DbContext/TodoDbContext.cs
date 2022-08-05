namespace TodoAppDatabase.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using TodoAppDatabase.Models;

    public class TodoDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=TodoApp;Integrated Security=true;");
            }
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }
    }

}

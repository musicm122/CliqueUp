using System.Data.Entity;
using CliqueUpModel.Model;

namespace Models.Model
{
    public class CliqueUpContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<CategoryEvent> CategoryEvents { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<EventMessage> EventMessages { get; set; }
        public DbSet<EventUser> EventUsers { get; set; }
        public DbSet<Category> EventCategories { get; set; }
    }
}

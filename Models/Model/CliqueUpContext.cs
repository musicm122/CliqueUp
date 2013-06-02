using System.Data.Entity;

namespace CliqueUpModel.Model
{
    public class CliqueUpContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<CategoryEvent> CategoryEvents { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<Category> EventCategories { get; set; }
    }
}

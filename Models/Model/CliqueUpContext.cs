using System.Data.Entity;

namespace CliqueUpModel.Model
{
    public class CliqueUpContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
    }
}

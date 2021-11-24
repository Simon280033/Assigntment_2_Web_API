using Microsoft.EntityFrameworkCore;
using Models;

namespace FileData
{
    public class AdultsAndUsersDbContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\\Users\\simon\\RiderProjects\\Assigntment_2_Web_API\\identifier.sqlite");
        }
    }
}
using Microsoft.EntityFrameworkCore;
using UserApi.Entities;

namespace UserApi.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Site> Sites { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<EmployeerModel> Employeers { get; set; }       
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmployeerModel>();
            modelBuilder.Entity<UserModel>();
            modelBuilder.Entity<PersonModel>();
        }
    }
}

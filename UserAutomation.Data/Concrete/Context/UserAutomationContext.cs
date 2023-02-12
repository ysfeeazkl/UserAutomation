using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAutomation.Data.Concrete.Mappings;
using UserAutomation.Entities.Concrete;

namespace UserAutomation.Data.Concrete.Context
{
    public class UserAutomationContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Company> Companies{ get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new LocationMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new WorkerMap());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ZULFIKAR;Database=UserAutomationDb;User Id=sa;Password=123456;Trusted_Connection=false"); 
            //optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=UserAutomationDb;Trusted_Connection=true;");
            base.OnConfiguring(optionsBuilder);
            
        }

    }
}

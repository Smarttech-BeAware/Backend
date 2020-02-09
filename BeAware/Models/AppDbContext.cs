using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeAware.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<FiledReport> Reports { get; set; }
        public DbSet<ValidationRequest> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FiledReport>().HasNoKey();
            modelBuilder.Entity<ValidationRequest>().HasNoKey();
            modelBuilder.Entity<Location>().HasNoKey();
            

            base.OnModelCreating(modelBuilder);
        }

        
    }
}

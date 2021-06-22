using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValueSql("NewID()");
            modelBuilder.Entity<PortfolioItem>().Property(x => x.Id).HasDefaultValueSql("NewID()");

            modelBuilder.Entity<Owner>().HasData(
                new Owner
                {
                     Id = Guid.NewGuid(),
                     Avatar= "Avater.jpg",
                     FullName = "Ahmed Hassan Abou Zeid",
                     Profil = "Junior Asp.net core Developer "

                }

                );

        }
        public DbSet<Owner>owner { get; set; }
        public DbSet<PortfolioItem> portfolioItems { get; set; }

    }
}

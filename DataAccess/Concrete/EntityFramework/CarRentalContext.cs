using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class CarRentalContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-QC7CL3A;Database=CarRental;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>()
                .HasOne(x => x.Color)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.ColorId);
            modelBuilder.Entity<Car>()
              .HasOne(x => x.Brand)
              .WithMany(x => x.Cars)
              .HasForeignKey(x => x.BrandId);
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
    }
}

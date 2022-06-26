using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RentACarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializar.Build();
            optionsBuilder.UseSqlServer(Initializar.Configuration.GetConnectionString("SqlCon"));
            base.OnConfiguring(optionsBuilder);
        }
        public override int SaveChanges()
        {
            ChangeTracker.Entries().ToList().ForEach(R =>
            {
                if (R.Entity is Rental rental)
                {
                    rental.RentDate = DateTime.Now;
                }
                if (R.Entity is CarImage carImage)
                {
                    carImage.Date= DateTime.Now;
                }
            });


            return base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>().HasOne(r => r.Customer).WithMany(c => c.Rentals).HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<Customer>()
                     .HasKey(c => c.UserId);

            modelBuilder.Entity<Customer>()
                     .Property(et => et.UserId)
                     .ValueGeneratedNever();



            base.OnModelCreating(modelBuilder);
        }
    }
}

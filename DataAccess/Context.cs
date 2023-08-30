using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=AUTOPILOT-YFXU8\\SQLEXPRESS;Initial Catalog=AndjelaSHOP1;Integrated Security=True;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new SeedHelper().Seeder(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<SizeProduct>().HasKey(x=> new {x.SizeId, x.ProductId});

            base.OnModelCreating(modelBuilder);
        }
       
        public DbSet<User> Users { get;set; }
        public DbSet<Category> Categories { get;set; }
        public DbSet<Order> Orders { get;set; }
        public DbSet<OrderLine> OrderLines { get;set; }
        public DbSet<Product> Products { get;set; }
        public DbSet<Size> Sizes { get;set; }
        public DbSet<SizeProduct> SizesProducts { get;set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
    }
}

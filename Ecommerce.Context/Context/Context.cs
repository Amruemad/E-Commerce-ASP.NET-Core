using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Ecommerce.Models.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;


namespace Ecommerce.Context.Context
{
    public class EcommerceContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options) { }

        // DbSets for classes
        public DbSet<AppUser>       appUsers      { get; set; }
        public DbSet<Category>      categories    { get; set; }
        public DbSet<Order>         orders        { get; set; }
        public DbSet<Product>       products      { get; set; }
        public DbSet<OrderProducts> orderProducts { get; set; }

        //Assigning Relations among the classes
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Relation between Product and Category
            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategricId)
                .OnDelete(DeleteBehavior.Cascade);

            //Relation between Product and Order
            builder.Entity<Product>()
                .HasMany(p => p.Orders)
                .WithOne(op => op.Product)
                .HasForeignKey(op => op.ProductId);

            builder.Entity<OrderProducts>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            builder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithOne(op => op.Order)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            //Relation between AppUser and Order
            builder.Entity<AppUser>()
                .HasMany(au => au.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            List<AppRole> roleList = new List<AppRole>()
            {
                new AppRole()
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new AppRole()
                {
                    Id = 2,
                    Name = "User",
                    NormalizedName = "USER"
                }
            };

            builder.Entity<AppRole>().HasData(roleList);

            builder.Entity<AppUser>()
            .Property(u => u.BirthDate)
            .HasColumnType("date");

            base.OnModelCreating(builder);

        }


    }
}

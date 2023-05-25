using Microsoft.EntityFrameworkCore;
using Online_Food_Ordering_System.UserMicroservice.Data_Access_Layer.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Xml.Linq;
using Online_Food_Ordering_System.FoodMicroservice.Data_Access_Layer.Models;
using Online_Food_Ordering_System.OrderandPayment.Data_Access_Layer.Models;
using System.Reflection;

namespace Online_Food_Ordering_System
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.ConfirmPassword)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.IsAdmin)
                .IsRequired();

            //Relationship 

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Food)
                .WithMany()
                .HasForeignKey(o => o.FoodId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
              .HasOne(p => p.Order)
              .WithOne()
              .HasForeignKey<Payment>(p => p.OrderId)
              .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
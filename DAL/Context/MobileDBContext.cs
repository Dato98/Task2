using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class MobileDBContext : DbContext
    {
        public MobileDBContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Mobile> Mobiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Mobile>()
                .Property(e => e.Name)
                .HasMaxLength(70)
                .IsRequired();

            modelBuilder.Entity<Mobile>()
                .Property(e => e.Manufacturer)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Mobile>()
                .Property(e => e.Processor)
                .HasMaxLength(70)
                .IsRequired();

            modelBuilder.Entity<Mobile>()
                .Property(e => e.OS)
                .HasMaxLength(70)
                .IsRequired();

            modelBuilder.Entity<Mobile>()
                .HasMany(e => e.MobilePictures)
                .WithOne(c => c.Mobile)
                .HasForeignKey(c => c.MobileId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}

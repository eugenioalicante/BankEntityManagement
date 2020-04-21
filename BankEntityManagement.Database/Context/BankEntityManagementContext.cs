using System;
using BankEntityManagement.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankEntityManagement.Database.Context
{
    public partial class BankEntityManagementContext : DbContext
    {
        public BankEntityManagementContext()
        {
        }

        public BankEntityManagementContext(DbContextOptions<BankEntityManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Entity> Entity { get; set; }
        public virtual DbSet<EntityGroup> EntityGroup { get; set; }
        public virtual DbSet<Province> Province { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("BBDD").ToString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Entity>(entity =>
            {
                entity.HasOne(d => d.IdEntityGroupNavigation)
                    .WithMany(p => p.Entity)
                    .HasForeignKey(d => d.IdEntityGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entity_EntityGroup");

                entity.HasOne(d => d.IdProvinceNavigation)
                    .WithMany(p => p.Entity)
                    .HasForeignKey(d => d.IdProvince)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entity_Province");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.Province)
                    .HasForeignKey(d => d.IdCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Provinces_Countries");
            });

            modelBuilder.Entity<Entity>().HasQueryFilter(e => e.Active);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BankEntityManagement.Database.Entities
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=bank-entity-management.database.windows.net;Initial Catalog=BankEntityManagement;User ID=bankEntityManagement;Password=abt32o1r$");
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
        }
    }
}

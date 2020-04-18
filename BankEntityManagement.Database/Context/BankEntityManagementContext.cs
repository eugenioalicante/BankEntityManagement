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
    }
}

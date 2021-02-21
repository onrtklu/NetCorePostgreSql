using CorePostgre.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorePostgre.Data
{
    public class OnrDbContext : DbContext
    {
        public virtual DbSet<OnrTable> OnrTable { get; set; }
        public virtual DbSet<Role> Role { get; set; }

        public OnrDbContext(DbContextOptions<OnrDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasMany(s => s.OnrTables)
                .WithOne(x => x.Role)
                .HasForeignKey(f=>f.RoleId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

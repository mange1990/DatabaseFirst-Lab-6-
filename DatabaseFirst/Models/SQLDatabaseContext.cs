using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatabaseFirst.models
{
    public partial class SQLDatabaseContext : DbContext
    {
        public SQLDatabaseContext()
        {
        }

        public SQLDatabaseContext(DbContextOptions<SQLDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DeviceProterties> DeviceProterties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeviceProterties>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(100);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Flash.Park.Data
{
    public partial class FlashParkContext : DbContext
    {
        public FlashParkContext()
        {
        }

        public FlashParkContext(DbContextOptions<FlashParkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Floor> Floor { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Slot> Slot { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=database-1.cze9ofg3zv7h.us-east-1.rds.amazonaws.com;Database=FlashPark;User ID=admin;Password=zTYH46olvsCfayKDWkDD;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Floor>(entity =>
            {
                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Floor)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("fk_LocationId_Floor");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                //entity.HasMany(d => d.Floor);
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.HasOne(d => d.Floor)
                    .WithMany(p => p.Slot)
                    .HasForeignKey(d => d.FloorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_FloorId_Slot");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

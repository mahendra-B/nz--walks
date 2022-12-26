using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DALayer.models
{
    public partial class NZWalksContext : DbContext
    {
        public NZWalksContext()
        {
        }

        public NZWalksContext(DbContextOptions<NZWalksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Walk> Walks { get; set; }
        public virtual DbSet<WalkDifficulty> WalkDifficulties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=HAKUNAMATTA;database=NZWalks;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Walk>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Walks)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("fk_Regionid");

                entity.HasOne(d => d.WalkDifficulty)
                    .WithMany(p => p.Walks)
                    .HasForeignKey(d => d.WalkDifficultyId)
                    .HasConstraintName("fk_WalkDifficultyId");
            });

            modelBuilder.Entity<WalkDifficulty>(entity =>
            {
                entity.ToTable("WalkDifficulty");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

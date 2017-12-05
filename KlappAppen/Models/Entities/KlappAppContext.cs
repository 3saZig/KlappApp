using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KlappAppen.Models.Entities
{
    public partial class KlappAppContext : DbContext
    {
        public virtual DbSet<Gifts> Gifts { get; set; }
        public virtual DbSet<P2g> P2g { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=KlappApp;Integrated Security=True;Pooling=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gifts>(entity =>
            {
                entity.Property(e => e.Gift)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<P2g>(entity =>
            {
                entity.HasKey(e => new { e.Pid, e.Gid });

                entity.ToTable("P2G");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.Gid).HasColumnName("GID");

                entity.HasOne(d => d.G)
                    .WithMany(p => p.P2g)
                    .HasForeignKey(d => d.Gid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__P2G__GID__1FCDBCEB");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.P2g)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__P2G__PID__1ED998B2");
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}

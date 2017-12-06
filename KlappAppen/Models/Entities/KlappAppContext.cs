using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KlappAppen.Models.Entities
{
    public partial class KlappAppContext : DbContext
    {
        public virtual DbSet<Budgets> Budgets { get; set; }
        public virtual DbSet<Gifts> Gifts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=klappappenserver.database.windows.net;Initial Catalog=KlappAppen;Integrated Security=False;User ID=klappappen;Password=polkagris3!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Budgets>(entity =>
            {
                entity.Property(e => e.Total).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Gifts>(entity =>
            {
                entity.Property(e => e.BudgetId).HasColumnName("BudgetID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasDefaultValueSql("((0))");

                entity.Property(e => e.Receiver)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Budget)
                    .WithMany(p => p.Gifts)
                    .HasForeignKey(d => d.BudgetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Gifts__BudgetID__5629CD9C");
            });
        }
    }
}

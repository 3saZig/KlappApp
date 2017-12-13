using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KlappAppen.Models.Entities
{
    public partial class KlappAppContext : DbContext
    {
        public virtual DbSet<Budget> Budgets { get; set; }
        public virtual DbSet<Gift> Gifts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Budget>(entity =>
            {
                entity.ToTable("Budget", "trh");

                entity.Property(e => e.AspNetUsersId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.BudgetName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Gift>(entity =>
            {
                entity.ToTable("Gift", "trh");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasDefaultValueSql("((0))");

                entity.Property(e => e.Receiver)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Budget)
                    .WithMany(p => p.Gift)
                    .HasForeignKey(d => d.BudgetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Gift__BudgetId__73BA3083");
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using YTG.Lookups.Repository.Models;

namespace YTG.Lookups.Repository.Context
{
    public class LookupsDBContext : DbContext
    {

        public LookupsDBContext()
        {
        }

        public LookupsDBContext(DbContextOptions<LookupsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LuCategories> LuCategories { get; set; }
        public virtual DbSet<LuItems> LuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LuCategories>(entity =>
            {
                entity.ToTable("LuCategories", "lookups");

                entity.HasIndex(e => e.ShortName)
                    .IsUnique();

                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateMod).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WhoAdd)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WhoMod)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LuItems>(entity =>
            {
                entity.ToTable("LuItems", "lookups");

                entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateMod).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.LuBoolean)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LuCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LuItemDesc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LuValue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LuValue2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WhoAdd)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WhoMod)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.LuCat)
                    .WithMany(p => p.LuItems)
                    .HasForeignKey(d => d.LuCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LuItems_LuCat_Id");
            });



        }



    }
    }

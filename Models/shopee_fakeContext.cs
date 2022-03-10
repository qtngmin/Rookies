using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CoreDBFirst.Models
{
    public partial class shopee_fakeContext : DbContext
    {
        public shopee_fakeContext()
        {
        }

        public shopee_fakeContext(DbContextOptions<shopee_fakeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=shopee_fake;user=root;pwd=nmqt122K", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin_");

                entity.HasIndex(e => e.Username, "USERNAME");

                entity.Property(e => e.Id)
                    .HasMaxLength(9)
                    .HasColumnName("ID")
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.NameAd)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NAME_AD")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("admin__ibfk_1");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.NameCategory)
                    .HasName("PRIMARY");

                entity.ToTable("category_");

                entity.Property(e => e.NameCategory)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_CATEGORY")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Discription)
                    .HasMaxLength(1000)
                    .HasColumnName("DISCRIPTION")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer)
                    .HasName("PRIMARY");

                entity.ToTable("customer_");

                entity.HasIndex(e => e.Username, "USERNAME");

                entity.Property(e => e.IdCustomer)
                    .HasMaxLength(9)
                    .HasColumnName("ID_CUSTOMER")
                    .IsFixedLength(true);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("DATE_OF_BIRTH");

                entity.Property(e => e.NameCus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NAME_CUS")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TypeCus)
                    .HasMaxLength(10)
                    .HasColumnName("TYPE_CUS");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer__ibfk_1");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PRIMARY");

                entity.ToTable("order_");

                entity.HasIndex(e => e.IdCus, "ID_CUS");

                entity.Property(e => e.IdOrder)
                    .HasMaxLength(9)
                    .HasColumnName("ID_ORDER")
                    .IsFixedLength(true);

                entity.Property(e => e.AddressOrder)
                    .HasMaxLength(1000)
                    .HasColumnName("ADDRESS_ORDER")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.IdCus)
                    .IsRequired()
                    .HasMaxLength(9)
                    .HasColumnName("ID_CUS")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdCusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdCus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order__ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PRIMARY");

                entity.ToTable("user_");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("USERNAME");

                entity.Property(e => e.ActiveDate)
                    .HasColumnType("date")
                    .HasColumnName("ACTIVE_DATE");

                entity.Property(e => e.Passw)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("PASSW");

                entity.Property(e => e.RecoveryEmail)
                    .HasMaxLength(50)
                    .HasColumnName("RECOVERY_EMAIL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

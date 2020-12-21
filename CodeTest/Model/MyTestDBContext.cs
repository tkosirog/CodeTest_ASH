using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CodeTest.Model
{
    public partial class MyTestDBContext : DbContext
    {
        public MyTestDBContext()
        {
        }

        public MyTestDBContext(DbContextOptions<MyTestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<LuEmployeeType> LuEmployeeTypes { get; set; }
        public virtual DbSet<LuPayType> LuPayTypes { get; set; }
        public virtual DbSet<ManagerPay> ManagerPays { get; set; }
        public virtual DbSet<PayScale> PayScales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-MCOH956;Initial Catalog=MyTestDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeMetadaId)
                    .HasName("PK__Employee__AC02E6BF363D6305");

                entity.Property(e => e.Address1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ManagerPay)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ManagerPayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ManagerPayId");

                entity.HasOne(d => d.PayScale)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PayScaleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PayScale");
            });

            modelBuilder.Entity<LuEmployeeType>(entity =>
            {
                entity.HasKey(e => e.EmployeeTypeId)
                    .HasName("PK__LU_Emplo__1F1B6A94DD05786D");

                entity.ToTable("LU_EmployeeType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LuPayType>(entity =>
            {
                entity.HasKey(e => e.PayTypeId)
                    .HasName("PK__LU_PayTy__4CA9639294EE3FD6");

                entity.ToTable("LU_PayType");

                entity.Property(e => e.PayName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ManagerPay>(entity =>
            {
                entity.ToTable("ManagerPay");

                entity.Property(e => e.AnnualSalary).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MaxExpenseAccount).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<PayScale>(entity =>
            {
                entity.ToTable("PayScale");

                entity.Property(e => e.PayValue).HasColumnType("decimal(5, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

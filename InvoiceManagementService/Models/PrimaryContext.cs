using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InvoiceManagementService.Models
{
    public partial class PrimaryContext : DbContext
    {
        public PrimaryContext()
        {
        }

        public PrimaryContext(DbContextOptions<PrimaryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<InvoiceState> InvoiceStates { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<MemberCheckin> MemberCheckins { get; set; } = null!;
        public virtual DbSet<Membership> Memberships { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=VINAY\\LOCALHOST;Database=Primary;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceNumber)
                    .HasName("PK__INVOICE__D776E980C35E10B1");

                entity.ToTable("INVOICE");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.InvoiceDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Membership)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.MembershipId)
                    .HasConstraintName("FK_MEMBERSHIP_INVOICE");
            });

            modelBuilder.Entity<InvoiceState>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("INVOICE_STATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("MEMBER");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateofBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MemberCheckin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MEMBER_CHECKIN");

                entity.Property(e => e.CheckinDate).HasColumnType("datetime");

                entity.Property(e => e.CheckoutDate).HasColumnType("datetime");

                entity.HasOne(d => d.Membership)
                    .WithMany()
                    .HasForeignKey(d => d.MembershipId)
                    .HasConstraintName("FK_MEMBERSHIP_MEMBER_CHECKIN");
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.ToTable("MEMBERSHIP");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Memberships)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_MEMBER_MEMBERSHIP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace myLibrary_api.Models
{
    public partial class myLibraryDBContext : DbContext
    {
        public myLibraryDBContext()
        {
        }

        public myLibraryDBContext(DbContextOptions<myLibraryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Reserve> Reserves { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=myLibraryDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BooId);

                entity.ToTable("BOOK");

                entity.Property(e => e.BooId).HasColumnName("BOO_ID");

                entity.Property(e => e.BooAuthor)
                    .IsRequired()
                    .HasColumnName("BOO_AUTHOR")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.BooAvailability)
                    .IsRequired()
                    .HasColumnName("BOO_AVAILABILITY")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BooCode)
                    .IsRequired()
                    .HasColumnName("BOO_CODE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BooEdition).HasColumnName("BOO_EDITION");

                entity.Property(e => e.BooGenre)
                    .HasColumnName("BOO_GENRE")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BooImage)
                    .HasColumnName("BOO_IMAGE")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.BooLanguage)
                    .IsRequired()
                    .HasColumnName("BOO_LANGUAGE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BooLoanSituation).HasColumnName("BOO_LOAN_SITUATION");

                entity.Property(e => e.BooPages).HasColumnName("BOO_PAGES");

                entity.Property(e => e.BooPublisher)
                    .HasColumnName("BOO_PUBLISHER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BooReserveSituation).HasColumnName("BOO_RESERVE_SITUATION");

                entity.Property(e => e.BooStatus)
                    .IsRequired()
                    .HasColumnName("BOO_STATUS")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BooTitle)
                    .IsRequired()
                    .HasColumnName("BOO_TITLE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BooYear)
                    .HasColumnName("BOO_YEAR")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(e => e.LoaId);

                entity.ToTable("LOAN");

                entity.Property(e => e.LoaId).HasColumnName("LOA_ID");

                entity.Property(e => e.BooId).HasColumnName("BOO_ID");

                entity.Property(e => e.LoaDateLoad)
                    .HasColumnName("LOA_DATE_LOAD")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoaDateReturn)
                    .HasColumnName("LOA_DATE_RETURN")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoaRenovation).HasColumnName("LOA_RENOVATION");

                entity.Property(e => e.LoaStatus)
                    .IsRequired()
                    .HasColumnName("LOA_STATUS")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UseId).HasColumnName("USE_ID");

                entity.HasOne(d => d.Boo)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.BooId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOAN_BOOK");

                entity.HasOne(d => d.Use)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.UseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOAN_USER");
            });

            modelBuilder.Entity<Reserve>(entity =>
            {
                entity.HasKey(e => e.ResId);

                entity.ToTable("RESERVE");

                entity.Property(e => e.ResId).HasColumnName("RES_ID");

                entity.Property(e => e.BooId).HasColumnName("BOO_ID");

                entity.Property(e => e.ResDateReservation)
                    .HasColumnName("RES_DATE_RESERVATION")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResDateWithdrawal)
                    .HasColumnName("RES_DATE_WITHDRAWAL")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResStatus)
                    .IsRequired()
                    .HasColumnName("RES_STATUS")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UseId).HasColumnName("USE_ID");

                entity.HasOne(d => d.Boo)
                    .WithMany(p => p.Reserves)
                    .HasForeignKey(d => d.BooId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESERVE_BOOK");

                entity.HasOne(d => d.Use)
                    .WithMany(p => p.Reserves)
                    .HasForeignKey(d => d.UseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESERVE_USER");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UseId);

                entity.ToTable("USER");

                entity.Property(e => e.UseId).HasColumnName("USE_ID");

                entity.Property(e => e.UseEmail)
                    .IsRequired()
                    .HasColumnName("USE_EMAIL")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UseName)
                    .IsRequired()
                    .HasColumnName("USE_NAME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UsePassword)
                    .IsRequired()
                    .HasColumnName("USE_PASSWORD")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.UseStatus)
                    .IsRequired()
                    .HasColumnName("USE_STATUS")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UseType)
                    .IsRequired()
                    .HasColumnName("USE_TYPE")
                    .HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

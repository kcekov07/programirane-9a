using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace oppbd2.Models
{
    public partial class SchoolDBContext : DbContext
    {
        public SchoolDBContext()
        {
        }

        public SchoolDBContext(DbContextOptions<SchoolDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Specialite> Specialites { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
              //  optionsBuilder.UseSqlServer("Server=DESKTOP-5F3HQ86\\SQLEXPRESS01;Database=SchoolDB;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("Server=DESKTOP-M71SG0B\\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.GradeLetter).HasMaxLength(1);

                entity.HasOne(d => d.Speciality)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.SpecialityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Classes_Specialites");
            });

            modelBuilder.Entity<Specialite>(entity =>
            {
                entity.HasIndex(e => e.GraduatesTitle, "UQ__Speciali__A349308405CF743A")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(1024);

                entity.Property(e => e.GraduatesTitle).HasMaxLength(32);

                entity.Property(e => e.Name).HasMaxLength(64);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Students__A9D10534950ACC73")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(64);

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Email).HasMaxLength(32);

                entity.Property(e => e.FirstName).HasMaxLength(16);

                entity.Property(e => e.Gsm)
                    .HasMaxLength(16)
                    .HasColumnName("GSM");

                entity.Property(e => e.LastName).HasMaxLength(16);

                entity.Property(e => e.SurName).HasMaxLength(16);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_Classes");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Teachers__A9D105349CE5E858")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(32);

                entity.Property(e => e.FirstName).HasMaxLength(16);

                entity.Property(e => e.LastName).HasMaxLength(16);

                entity.Property(e => e.ManagedClassId).HasColumnName("ManagedClassID");

                entity.Property(e => e.Subjects).HasMaxLength(64);

                entity.HasOne(d => d.ManagedClass)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.ManagedClassId)
                    .HasConstraintName("FK_Teachers_Classes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

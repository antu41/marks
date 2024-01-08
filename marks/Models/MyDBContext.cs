﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace marks.Models
{
    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
        {
        }

        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Std> Stds { get; set; } = null!;
        public virtual DbSet<Stdmrk> Stdmrks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Std>(entity =>
            {
                entity.ToTable("Std");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Department)
                    .HasMaxLength(10)
                    .HasColumnName("department")
                    .IsFixedLength();

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("gender")
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Stdmrk>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("stdmrks");

                entity.Property(e => e.Attendance)
                    .HasMaxLength(10)
                    .HasColumnName("attendance")
                    .IsFixedLength();

                entity.Property(e => e.Classtest)
                    .HasMaxLength(10)
                    .HasColumnName("classtest")
                    .IsFixedLength();

                entity.Property(e => e.Finalterm)
                    .HasMaxLength(10)
                    .HasColumnName("finalterm")
                    .IsFixedLength();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Midterm)
                    .HasMaxLength(10)
                    .HasColumnName("midterm")
                    .IsFixedLength();

                entity.Property(e => e.Studentname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("studentname");

                entity.Property(e => e.Totalmarks)
                    .HasMaxLength(10)
                    .HasColumnName("totalmarks")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

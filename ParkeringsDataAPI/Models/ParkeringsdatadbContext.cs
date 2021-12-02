﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ParkeringsDataAPI.Models
{
    public partial class ParkeringsdatadbContext : DbContext
    {
        public ParkeringsdatadbContext()
        {
        }

        public ParkeringsdatadbContext(DbContextOptions<ParkeringsdatadbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Parkeringsområde> Parkeringsområdes { get; set; }
        public virtual DbSet<SpecielleParkeringsPladser> SpecielleParkeringsPladsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=emilzealanddb.database.windows.net;Initial Catalog=ParkeringsDataDb;User ID=emiladmin;Password=Sql12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => new { e.OmrådeId, e.Tidspunkt })
                    .HasName("Clustered1_Key");

                entity.HasOne(d => d.Område)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.OmrådeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Location1_Limit");
            });

            modelBuilder.Entity<SpecielleParkeringsPladser>(entity =>
            {
                entity.HasKey(e => new { e.OmrådeId, e.ParkeringsType })
                    .HasName("Clustered_Key");

                entity.HasOne(d => d.Område)
                    .WithMany(p => p.SpecielleParkeringsPladsers)
                    .HasForeignKey(d => d.OmrådeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Location_Limit");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
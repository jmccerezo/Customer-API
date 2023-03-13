using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EvaluationAssignment.Models;

public partial class EvaluationAssignmentContext : DbContext
{
    public EvaluationAssignmentContext()
    {
    }

    public EvaluationAssignmentContext(DbContextOptions<EvaluationAssignmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("TrustServerCertificate=True;Server=CEREZO-DESKTOP\\SQLEXPRESS;Database=EvaluationAssignment;Trusted_Connection=True");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8DE4A8C58");

            entity.ToTable("Customer");

            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustomerType).HasColumnType("numeric(1, 0)");
            entity.Property(e => e.Mobile)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("mobile");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

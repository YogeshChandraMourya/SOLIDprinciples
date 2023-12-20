using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SOLIDDb_15_12_23_.Models;

public partial class SolidContext : DbContext
{
    public SolidContext()
    {
    }

    public SolidContext(DbContextOptions<SolidContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmailMessage> EmailMessages { get; set; }

    public virtual DbSet<User> Users { get; set; }

   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=YBANALA-L-5498\\SQLEXPRESS;Initial Catalog=SOLID;User ID=sa;Password=Welcome2evoke@1234; Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmailMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EmailMes__3214EC07255164EF");

            entity.Property(e => e.Subject).HasMaxLength(255);
            entity.Property(e => e.ToAddress).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07D235B126");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

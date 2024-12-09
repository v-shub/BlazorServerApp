using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Models;

public partial class FamilyLifeContext : DbContext
{
    public FamilyLifeContext()
    {
    }

    public FamilyLifeContext(DbContextOptions<FamilyLifeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("workstation id=FamilyLife.mssql.somee.com;packet size=4096;user id=v_shub_SQLLogin_1;pwd=Shubina1147;data source=FamilyLife.mssql.somee.com;persist security info=False;initial catalog=FamilyLife;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.CreatorId).HasColumnName("Creator_ID");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_at");
            entity.Property(e => e.DeletedById).HasColumnName("Deleted_by_ID");
            entity.Property(e => e.Header).HasMaxLength(200);
            entity.Property(e => e.PostContent)
                .HasMaxLength(4000)
                .HasColumnName("Post_content");

            entity.HasOne(d => d.Creator).WithMany(p => p.Posts)
                .HasForeignKey(d => d.CreatorId)
                .HasConstraintName("FK_Posts_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BirthdayDate)
                .HasColumnType("date")
                .HasColumnName("Birthday_date");
            entity.Property(e => e.ChildrenCount).HasColumnName("Children_count");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_at");
            entity.Property(e => e.DeletedById).HasColumnName("Deleted_by_ID");
            entity.Property(e => e.ExtraInfo)
                .HasMaxLength(4000)
                .HasColumnName("Extra_info");
            entity.Property(e => e.Password).HasMaxLength(30);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

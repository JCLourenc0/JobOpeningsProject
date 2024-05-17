using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JobsOpeningsProject.Models;

public partial class JobsOpeningsDbContext : DbContext
{
    public JobsOpeningsDbContext()
    {
    }

    public JobsOpeningsDbContext(DbContextOptions<JobsOpeningsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-1QGKMT7D\\SQLEXPRESS;database=JobsOpeningsDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Departmentid).HasName("PK__DEPARTME__EC3B6F4FB5BE78EA");

            entity.ToTable("DEPARTMENTS");

            entity.Property(e => e.Departmentid).HasColumnName("DEPARTMENTID");
            entity.Property(e => e.Departmenttitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENTTITLE");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Jobid).HasName("PK__JOBS__CD01726ECBF00C4C");

            entity.ToTable("JOBS");

            entity.Property(e => e.Jobid).HasColumnName("JOBID");
            entity.Property(e => e.Closingdate)
                .HasColumnType("datetime")
                .HasColumnName("CLOSINGDATE");
            entity.Property(e => e.Departmentid).HasColumnName("DEPARTMENTID");
            entity.Property(e => e.Jobcode)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasComputedColumnSql("('JOB-'+right('0'+CONVERT([varchar](8),[JOBID]),(3)))", true)
                .HasColumnName("JOBCODE");
            entity.Property(e => e.Jobdescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("JOBDESCRIPTION");
            entity.Property(e => e.Jobtitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("JOBTITLE");
            entity.Property(e => e.Locationid).HasColumnName("LOCATIONID");
            entity.Property(e => e.Posteddate)
                .HasColumnType("datetime")
                .HasColumnName("POSTEDDATE");

            entity.HasOne(d => d.Department).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.Departmentid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__JOBS__DEPARTMENT__3B75D760");

            entity.HasOne(d => d.Location).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.Locationid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__JOBS__LOCATIONID__3A81B327");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Locationid).HasName("PK__LOCATION__4D3C31AEB778963F");

            entity.ToTable("LOCATIONS");

            entity.Property(e => e.Locationid).HasColumnName("LOCATIONID");
            entity.Property(e => e.Locationcity)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOCATIONCITY");
            entity.Property(e => e.Locationcountry)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOCATIONCOUNTRY");
            entity.Property(e => e.Locationstate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOCATIONSTATE");
            entity.Property(e => e.Locationtitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOCATIONTITLE");
            entity.Property(e => e.Locationzip).HasColumnName("LOCATIONZIP");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LAB5ZhatkoEvseev.Models;

public partial class CinimaEvseevZhatkoContext : DbContext
{
    public CinimaEvseevZhatkoContext()
    {
    }

    public CinimaEvseevZhatkoContext(DbContextOptions<CinimaEvseevZhatkoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employe> Employes { get; set; }

    public virtual DbSet<FkTypeplatform> FkTypeplatforms { get; set; }

    public virtual DbSet<GenreProject> GenreProjects { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Platform> Platforms { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<SemachnaaGroup> SemachnaaGroups { get; set; }

    public virtual DbSet<ShootingShedule> ShootingShedules { get; set; }

    public virtual DbSet<StatusProject> StatusProjects { get; set; }

    public virtual DbSet<TypeProject> TypeProjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CinimaEvseevZhatko;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employe>(entity =>
        {
            entity.HasKey(e => e.PkEmploye).HasName("employe_pkey");

            entity.ToTable("employe");

            entity.Property(e => e.PkEmploye).HasColumnName("pk_employe");
            entity.Property(e => e.Bid).HasColumnName("bid");
            entity.Property(e => e.FkJob).HasColumnName("fk_job");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Surname).HasColumnName("surname");

            entity.HasOne(d => d.FkJobNavigation).WithMany(p => p.Employes)
                .HasForeignKey(d => d.FkJob)
                .HasConstraintName("employe_fk_job_fkey");
        });

        modelBuilder.Entity<FkTypeplatform>(entity =>
        {
            entity.HasKey(e => e.PkTypeplatform).HasName("fk_typeplatform_pkey");

            entity.ToTable("fk_typeplatform");

            entity.Property(e => e.PkTypeplatform).HasColumnName("pk_typeplatform");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<GenreProject>(entity =>
        {
            entity.HasKey(e => e.PkGenreProject).HasName("genre_project_pkey");

            entity.ToTable("genre_project");

            entity.Property(e => e.PkGenreProject).HasColumnName("pk_genre_project");
            entity.Property(e => e.NameGenre).HasColumnName("name_genre");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.PkJob).HasName("job_pkey");

            entity.ToTable("job");

            entity.Property(e => e.PkJob).HasColumnName("pk_job");
            entity.Property(e => e.NameJob).HasColumnName("name_job");
        });

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.HasKey(e => e.PkPlatform).HasName("platform_pkey");

            entity.ToTable("platform");

            entity.Property(e => e.PkPlatform).HasColumnName("pk_platform");
            entity.Property(e => e.Adres)
                .HasMaxLength(100)
                .HasColumnName("adres");
            entity.Property(e => e.FkTypeplatform).HasColumnName("fk_typeplatform");
            entity.Property(e => e.Sumarendi).HasColumnName("sumarendi");
            entity.Property(e => e.Vmestimost).HasColumnName("vmestimost");

            entity.HasOne(d => d.FkTypeplatformNavigation).WithMany(p => p.Platforms)
                .HasForeignKey(d => d.FkTypeplatform)
                .HasConstraintName("platform_fk_typeplatform_fkey");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.PkProject).HasName("project_pkey");

            entity.ToTable("project");

            entity.Property(e => e.PkProject).HasColumnName("pk_project");
            entity.Property(e => e.AgeRating).HasColumnName("age_rating");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.FkGenreProject).HasColumnName("fk_genre_project");
            entity.Property(e => e.FkStatusProject).HasColumnName("fk_status_project");
            entity.Property(e => e.FkTypeProject).HasColumnName("fk_type_project");
            entity.Property(e => e.NameProject).HasColumnName("name_project");

            entity.HasOne(d => d.FkGenreProjectNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.FkGenreProject)
                .HasConstraintName("project_fk_genre_project_fkey");

            entity.HasOne(d => d.FkStatusProjectNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.FkStatusProject)
                .HasConstraintName("project_fk_status_project_fkey");

            entity.HasOne(d => d.FkTypeProjectNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.FkTypeProject)
                .HasConstraintName("project_fk_type_project_fkey");
        });

        modelBuilder.Entity<SemachnaaGroup>(entity =>
        {
            entity.HasKey(e => e.PkSemachnaaGroup).HasName("semachnaa_group_pkey");

            entity.ToTable("semachnaa_group");

            entity.Property(e => e.PkSemachnaaGroup).HasColumnName("pk_semachnaa_group");
            entity.Property(e => e.FkProject).HasColumnName("fk_project");
            entity.Property(e => e.FkTabnomer).HasColumnName("fk_tabnomer");

            entity.HasOne(d => d.FkProjectNavigation).WithMany(p => p.SemachnaaGroups)
                .HasForeignKey(d => d.FkProject)
                .HasConstraintName("semachnaa_group_fk_project_fkey");

            entity.HasOne(d => d.FkTabnomerNavigation).WithMany(p => p.SemachnaaGroups)
                .HasForeignKey(d => d.FkTabnomer)
                .HasConstraintName("semachnaa_group_fk_tabnomer_fkey");
        });

        modelBuilder.Entity<ShootingShedule>(entity =>
        {
            entity.HasKey(e => e.PkShootingShedule).HasName("shooting_shedule_pkey");

            entity.ToTable("shooting_shedule");

            entity.Property(e => e.PkShootingShedule).HasColumnName("pk_shooting_shedule");
            entity.Property(e => e.FkProject).HasColumnName("fk_project");
            entity.Property(e => e.FkTabnomer).HasColumnName("fk_tabnomer");

            entity.HasOne(d => d.FkProjectNavigation).WithMany(p => p.ShootingShedules)
                .HasForeignKey(d => d.FkProject)
                .HasConstraintName("shooting_shedule_fk_project_fkey");

            entity.HasOne(d => d.FkTabnomerNavigation).WithMany(p => p.ShootingShedules)
                .HasForeignKey(d => d.FkTabnomer)
                .HasConstraintName("shooting_shedule_fk_tabnomer_fkey");
        });

        modelBuilder.Entity<StatusProject>(entity =>
        {
            entity.HasKey(e => e.PkStatusProject).HasName("status_project_pkey");

            entity.ToTable("status_project");

            entity.Property(e => e.PkStatusProject).HasColumnName("pk_status_project");
            entity.Property(e => e.NameProject).HasColumnName("name_project");
        });

        modelBuilder.Entity<TypeProject>(entity =>
        {
            entity.HasKey(e => e.PkTypeProject).HasName("type_project_pkey");

            entity.ToTable("type_project");

            entity.Property(e => e.PkTypeProject).HasColumnName("pk_type_project");
            entity.Property(e => e.NameType).HasColumnName("name_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

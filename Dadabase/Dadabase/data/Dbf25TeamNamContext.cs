using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dadabase.data;

public partial class Dbf25TeamNamContext : DbContext
{
    public Dbf25TeamNamContext()
    {
    }

    public Dbf25TeamNamContext(DbContextOptions<Dbf25TeamNamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Audience> Audiences { get; set; }

    public virtual DbSet<Audiencecategory> Audiencecategories { get; set; }

    public virtual DbSet<Categorizedaudience> Categorizedaudiences { get; set; }

    public virtual DbSet<Categorizedjoke> Categorizedjokes { get; set; }

    public virtual DbSet<Deliveredjoke> Deliveredjokes { get; set; }

    public virtual DbSet<Joke> Jokes { get; set; }

    public virtual DbSet<Jokecategory> Jokecategories { get; set; }

    public virtual DbSet<Jokereactioncategory> Jokereactioncategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Audience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("audience_pkey");

            entity.ToTable("audience", "dadabase");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Audiencename)
                .HasColumnType("character varying")
                .HasColumnName("audiencename");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
        });

        modelBuilder.Entity<Audiencecategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("audiencecategory_pkey");

            entity.ToTable("audiencecategory", "dadabase");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Categoryname)
                .HasColumnType("character varying")
                .HasColumnName("categoryname");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
        });

        modelBuilder.Entity<Categorizedaudience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categorizedaudience_pkey");

            entity.ToTable("categorizedaudience", "dadabase");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Audiencecategoryid).HasColumnName("audiencecategoryid");
            entity.Property(e => e.Audienceid).HasColumnName("audienceid");

            entity.HasOne(d => d.Audiencecategory).WithMany(p => p.Categorizedaudiences)
                .HasForeignKey(d => d.Audiencecategoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categorizedaudience_audiencecategoryid_fkey");

            entity.HasOne(d => d.Audience).WithMany(p => p.Categorizedaudiences)
                .HasForeignKey(d => d.Audienceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categorizedaudience_audienceid_fkey");
        });

        modelBuilder.Entity<Categorizedjoke>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categorizedjoke_pkey");

            entity.ToTable("categorizedjoke", "dadabase");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Jokecategoryid).HasColumnName("jokecategoryid");
            entity.Property(e => e.Jokeid).HasColumnName("jokeid");

            entity.HasOne(d => d.Jokecategory).WithMany(p => p.Categorizedjokes)
                .HasForeignKey(d => d.Jokecategoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categorizedjoke_jokecategoryid_fkey");

            entity.HasOne(d => d.Joke).WithMany(p => p.Categorizedjokes)
                .HasForeignKey(d => d.Jokeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categorizedjoke_jokeid_fkey");
        });

        modelBuilder.Entity<Deliveredjoke>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("deliveredjokeid_pkey");

            entity.ToTable("deliveredjoke", "dadabase");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Audienceid).HasColumnName("audienceid");
            entity.Property(e => e.Delivereddate).HasColumnName("delivereddate");
            entity.Property(e => e.Jokeid).HasColumnName("jokeid");
            entity.Property(e => e.Jokereactionid).HasColumnName("jokereactionid");
            entity.Property(e => e.Notes)
                .HasColumnType("character varying")
                .HasColumnName("notes");

            entity.HasOne(d => d.Audience).WithMany(p => p.Deliveredjokes)
                .HasForeignKey(d => d.Audienceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("deliveredjokeid_audienceid_fkey");

            entity.HasOne(d => d.Joke).WithMany(p => p.Deliveredjokes)
                .HasForeignKey(d => d.Jokeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("deliveredjokeid_jokeid_fkey");

            entity.HasOne(d => d.Jokereaction).WithMany(p => p.Deliveredjokes)
                .HasForeignKey(d => d.Jokereactionid)
                .HasConstraintName("deliveredjokeid_jokereactionid_fkey");
        });

        modelBuilder.Entity<Joke>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("joke_pkey");

            entity.ToTable("joke", "dadabase");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Jokename)
                .HasColumnType("character varying")
                .HasColumnName("jokename");
            entity.Property(e => e.Joketext)
                .HasColumnType("character varying")
                .HasColumnName("joketext");
        });

        modelBuilder.Entity<Jokecategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jokecategory_pkey");

            entity.ToTable("jokecategory", "dadabase");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripion)
                .HasColumnType("character varying")
                .HasColumnName("descripion");
            entity.Property(e => e.Jokecategoryname)
                .HasColumnType("character varying")
                .HasColumnName("jokecategoryname");
        });

        modelBuilder.Entity<Jokereactioncategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jokereactioncategory_pkey");

            entity.ToTable("jokereactioncategory", "dadabase");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Recationlevel)
                .HasColumnType("character varying")
                .HasColumnName("recationlevel");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MovieMayhem.DataAccess;

public partial class MovieMayhemContext : DbContext
{
    public MovieMayhemContext()
    {
    }

    public MovieMayhemContext(DbContextOptions<MovieMayhemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.Property(e => e.Name).HasColumnName("Name");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasOne(d => d.Genre).WithMany(p => p.Movies)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

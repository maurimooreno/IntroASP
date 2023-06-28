using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IntroASPMVC.Models;

public partial class IntroAspContext : DbContext
{
    public IntroAspContext()
    {
    }

    public IntroAspContext(DbContextOptions<IntroAspContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1C5453E775C");

            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK__Estado__FEF86B609C45D919");

            entity.ToTable("Estado");

            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.TareaId).HasName("PK__Tareas__5CD83671961482CD");

            entity.Property(e => e.TareaId).HasColumnName("TareaID");
            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__Tareas__Categori__440B1D61");

            entity.HasOne(d => d.Estado).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Tareas__EstadoID__4316F928");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Tareas__UsuarioI__44FF419A");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE79817271F47");

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

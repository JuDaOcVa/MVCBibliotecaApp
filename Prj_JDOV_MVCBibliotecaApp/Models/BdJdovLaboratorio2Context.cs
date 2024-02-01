using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Prj_JDOV_MVCBibliotecaApp.Controllers;

namespace Prj_JDOV_MVCBibliotecaApp.Models;

public partial class BdJdovLaboratorio2Context : DbContext
{
    public BdJdovLaboratorio2Context()
    {
    }

    public BdJdovLaboratorio2Context(DbContextOptions<BdJdovLaboratorio2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<ObtenerPrestamosxUsuario> PrestamosxUsuarios { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BD_JDOV_Laboratorio2;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ObtenerPrestamosxUsuario>();

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Isbn).HasName("PK__Libros__447D36EB07D539AB");

            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.Autor)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Editorial)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.Idprestamo).HasName("PK__Prestamo__11A8682676598A52");

            entity.Property(e => e.Idprestamo).HasColumnName("IDPrestamo");
            entity.Property(e => e.FechaDevolucion).HasColumnType("date");
            entity.Property(e => e.FechaPrestamo).HasColumnType("date");
            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ISBN");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("FK__Prestamos__IDUsu__29572725");

            entity.HasOne(d => d.IsbnNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.Isbn)
                .HasConstraintName("FK__Prestamos__ISBN__286302EC");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__Usuarios__52311169D6F11181");

            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

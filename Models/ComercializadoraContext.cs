using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Comercializadora.Models;

public partial class ComercializadoraContext : DbContext
{
    public ComercializadoraContext()
    {
    }

    public ComercializadoraContext(DbContextOptions<ComercializadoraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Tercero> Terceros { get; set; }

    public virtual DbSet<TipoMovimiento> TipoMovimientos { get; set; }

    public virtual DbSet<TipoTercero> TipoTerceros { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {         
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //        =>
                //optionsBuilder.UseSqlServer("server=DESKTOP-Q7ICOAP\\SQLEXPRESS; database=comercializadora; integrated security=true;  TrustServerCertificate=True;");

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MovimientosID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");
            entity.Property(e => e.IdTercero).HasColumnName("Id_Tercero");
            entity.Property(e => e.IdTipoMovimiento).HasColumnName("Id_Tipo_Movimiento");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Movimiento_Producto_ID");

            entity.HasOne(d => d.IdTerceroNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdTercero)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Movimiento_Tercero_ID");

            entity.HasOne(d => d.IdTipoMovimientoNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdTipoMovimiento)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Movimiento_TipoMovimiento_ID");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Movimiento_Usuario_ID");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC0762DB40B3");

            entity.ToTable("Producto");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tercero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TercerosID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Documento)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.IdTipoTercero).HasColumnName("Id_Tipo_Tercero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoTerceroNavigation).WithMany(p => p.Terceros)
                .HasForeignKey(d => d.IdTipoTercero)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Terceros_Tipo_ID");
        });

        modelBuilder.Entity<TipoMovimiento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tipo_Mov__3214EC07DD81B28A");

            entity.ToTable("Tipo_Movimiento");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoTercero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tipo_Ter__3214EC0760650C06");

            entity.ToTable("Tipo_Terceros");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tipo_Usu__3214EC07F55C9908");

            entity.ToTable("Tipo_Usuarios");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UsuariosID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Documento)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.IdTipoUsuario).HasColumnName("Id_Tipo_Usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Usuarios_Tipo_ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

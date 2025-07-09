using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Structure.Context;

public partial class EcoRutaContext : DbContext
{
    public EcoRutaContext()
    {
    }

    public EcoRutaContext(DbContextOptions<EcoRutaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsignacionesRutum> AsignacionesRuta { get; set; }

    public virtual DbSet<Camione> Camiones { get; set; }

    public virtual DbSet<Chofere> Choferes { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<LogsActividad> LogsActividads { get; set; }

    public virtual DbSet<Reporte> Reportes { get; set; }

    public virtual DbSet<Ruta> Rutas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-C8EBDC3\\SQLEXPRESS;Database=EcoRuta;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsignacionesRutum>(entity =>
        {
            entity.HasKey(e => e.AsignacionId).HasName("PK__Asignaci__D82B5BB73183954C");

            entity.Property(e => e.AsignacionId).HasColumnName("AsignacionID");
            entity.Property(e => e.CamionId).HasColumnName("CamionID");
            entity.Property(e => e.ChoferId).HasColumnName("ChoferID");
            entity.Property(e => e.HorarioId).HasColumnName("HorarioID");
            entity.Property(e => e.RutaId).HasColumnName("RutaID");

            entity.HasOne(d => d.Camion).WithMany(p => p.AsignacionesRuta)
                .HasForeignKey(d => d.CamionId)
                .HasConstraintName("FK__Asignacio__Camio__72C60C4A");

            entity.HasOne(d => d.Chofer).WithMany(p => p.AsignacionesRuta)
                .HasForeignKey(d => d.ChoferId)
                .HasConstraintName("FK__Asignacio__Chofe__71D1E811");

            entity.HasOne(d => d.Horario).WithMany(p => p.AsignacionesRuta)
                .HasForeignKey(d => d.HorarioId)
                .HasConstraintName("FK__Asignacio__Horar__70DDC3D8");

            entity.HasOne(d => d.Ruta).WithMany(p => p.AsignacionesRuta)
                .HasForeignKey(d => d.RutaId)
                .HasConstraintName("FK__Asignacio__RutaI__6FE99F9F");
        });

        modelBuilder.Entity<Camione>(entity =>
        {
            entity.HasKey(e => e.CamionId).HasName("PK__Camiones__80E86F48C593860A");

            entity.HasIndex(e => e.Placa, "UQ__Camiones__8310F99D32D16B5F").IsUnique();

            entity.Property(e => e.CamionId).HasColumnName("CamionID");
            entity.Property(e => e.Modelo).HasMaxLength(100);
            entity.Property(e => e.Placa).HasMaxLength(20);
        });

        modelBuilder.Entity<Chofere>(entity =>
        {
            entity.HasKey(e => e.ChoferId).HasName("PK__Choferes__3969BEED721C13A9");

            entity.HasIndex(e => e.Cedula, "UQ__Choferes__B4ADFE385935BA72").IsUnique();

            entity.Property(e => e.ChoferId).HasColumnName("ChoferID");
            entity.Property(e => e.Cedula).HasMaxLength(20);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.HorarioId).HasName("PK__Horarios__BB881A9E8F21866F");

            entity.Property(e => e.HorarioId).HasColumnName("HorarioID");
            entity.Property(e => e.DiaFin).HasMaxLength(150);
            entity.Property(e => e.DiaInicio).HasMaxLength(150);
        });

        modelBuilder.Entity<LogsActividad>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__LogsActi__5E5499A8A018F034");

            entity.ToTable("LogsActividad");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.Accion).HasMaxLength(255);
            entity.Property(e => e.FechaHora)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.LogsActividads)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__LogsActiv__Usuar__76969D2E");
        });

        modelBuilder.Entity<Reporte>(entity =>
        {
            entity.HasKey(e => e.ReporteId).HasName("PK__Reportes__0B29EA4E176EA4EB");

            entity.Property(e => e.ReporteId).HasColumnName("ReporteID");
            entity.Property(e => e.Comentario).HasMaxLength(150);
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Pendiente");
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.Titulo).HasMaxLength(100);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Reportes__Usuari__5070F446");
        });

        modelBuilder.Entity<Ruta>(entity =>
        {
            entity.HasKey(e => e.RutaId).HasName("PK__Rutas__7B6199EED35AD4C1");

            entity.Property(e => e.RutaId).HasColumnName("RutaID");
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.NombreRuta).HasMaxLength(100);
            entity.Property(e => e.PuntoFinal).HasMaxLength(150);
            entity.Property(e => e.PuntoInicio).HasMaxLength(150);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7980953A9C9");

            entity.HasIndex(e => e.Correo, "UQ__Usuarios__60695A190B8CFD6E").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Contraseña).HasMaxLength(255);
            entity.Property(e => e.Correo).HasMaxLength(150);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.TipoUsuario).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using DPA.ACM.DOMAIN.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DPA.ACM.DOMAIN.Infrastructure.Data;

public partial class AutoCareManagerContext : DbContext
{
    public AutoCareManagerContext()
    {
    }

    public AutoCareManagerContext(DbContextOptions<AutoCareManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CargaTrabajo> CargaTrabajo { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<DetalleInventario> DetalleInventario { get; set; }

    public virtual DbSet<DetalleServicio> DetalleServicio { get; set; }

    public virtual DbSet<DetallesFactura> DetallesFactura { get; set; }

    public virtual DbSet<Factura> Factura { get; set; }

    public virtual DbSet<Inventario> Inventario { get; set; }

    public virtual DbSet<Mecanico> Mecanico { get; set; }

    public virtual DbSet<Programacion> Programacion { get; set; }

    public virtual DbSet<Propetario> Propetario { get; set; }

    public virtual DbSet<RecordatorioMantenimiento> RecordatorioMantenimiento { get; set; }

    public virtual DbSet<ReparacionMantenimiento> ReparacionMantenimiento { get; set; }

    public virtual DbSet<Servicio> Servicio { get; set; }

    public virtual DbSet<Taller> Taller { get; set; }

    public virtual DbSet<Vehiculo> Vehiculo { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.248.2;Database=AutoCareManager;User=sa;Pwd=Tecsup00;TrustServerCertificate=True");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CargaTrabajo>(entity =>
        {
            entity.HasKey(e => e.CargaId);

            entity.Property(e => e.CargaId).HasColumnName("CargaID");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.HoraFin).HasColumnType("text");
            entity.Property(e => e.MecanicoId).HasColumnName("MecanicoID");

            entity.HasOne(d => d.Mecanico).WithMany(p => p.CargaTrabajo)
                .HasForeignKey(d => d.MecanicoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CargaTrabajo_Mecanico");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Cliente__71ABD0A74B3A0D35");

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Dni).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Ruc).HasMaxLength(50);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetalleInventario>(entity =>
        {
            entity.HasKey(e => e.DetalleInventarioId).HasName("PK__DetalleF__493FAAB279B9BDD8");

            entity.Property(e => e.DetalleInventarioId).HasColumnName("DetalleInventarioID");
            entity.Property(e => e.InventarioId).HasColumnName("InventarioID");
            entity.Property(e => e.ReparacionMantenimientoId).HasColumnName("ReparacionMantenimientoID");

            entity.HasOne(d => d.Inventario).WithMany(p => p.DetalleInventario)
                .HasForeignKey(d => d.InventarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleInventario_Inventario");

            entity.HasOne(d => d.ReparacionMantenimiento).WithMany(p => p.DetalleInventario)
                .HasForeignKey(d => d.ReparacionMantenimientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleInventario_ReparacionMantenimiento");
        });

        modelBuilder.Entity<DetalleServicio>(entity =>
        {
            entity.HasKey(e => e.RepServicioId).HasName("PK_RepServicio");

            entity.Property(e => e.RepServicioId).HasColumnName("RepServicioID");
            entity.Property(e => e.ReparacionMantenimientoId).HasColumnName("ReparacionMantenimientoID");
            entity.Property(e => e.ServicioId).HasColumnName("ServicioID");

            entity.HasOne(d => d.ReparacionMantenimiento).WithMany(p => p.DetalleServicio)
                .HasForeignKey(d => d.ReparacionMantenimientoId)
                .HasConstraintName("FK_RepServicio_ReparacionMantenimiento");

            entity.HasOne(d => d.Servicio).WithMany(p => p.DetalleServicio)
                .HasForeignKey(d => d.ServicioId)
                .HasConstraintName("FK_RepServicio_Servicio");
        });

        modelBuilder.Entity<DetallesFactura>(entity =>
        {
            entity.HasKey(e => e.DetalleFacturaId).HasName("PK__Detalles__2318A415DA8E4247");

            entity.Property(e => e.DetalleFacturaId).HasColumnName("DetalleFacturaID");
            entity.Property(e => e.DescripcionServicio).HasColumnType("text");
            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.PrecioServicio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ReparacionMantenimientoId).HasColumnName("ReparacionMantenimientoID");

            entity.HasOne(d => d.Factura).WithMany(p => p.DetallesFactura)
                .HasForeignKey(d => d.FacturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallesF__Factu__4316F928");

            entity.HasOne(d => d.ReparacionMantenimiento).WithMany(p => p.DetallesFactura)
                .HasForeignKey(d => d.ReparacionMantenimientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesFactura_ReparacionMantenimiento");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__Factura__5C024805828ACF19");

            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.FechaFacturacion).HasColumnType("date");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Factura)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Factura__Cliente__44FF419A");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.InventarioId).HasName("PK__Inventar__FB8A24B7DDC291C1");

            entity.Property(e => e.InventarioId).HasColumnName("InventarioID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.VehiculoCompatible)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mecanico>(entity =>
        {
            entity.HasKey(e => e.MecanicoId).HasName("PK__Mecanico__D68834C18CEF399A");

            entity.Property(e => e.MecanicoId).HasColumnName("MecanicoID");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Especialidad).HasMaxLength(50);
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.TallerId).HasColumnName("TallerID");
            entity.Property(e => e.Telefono).HasMaxLength(50);

            entity.HasOne(d => d.Taller).WithMany(p => p.Mecanico)
                .HasForeignKey(d => d.TallerId)
                .HasConstraintName("FK_Mecanico_Taller");
        });

        modelBuilder.Entity<Programacion>(entity =>
        {
            entity.Property(e => e.ProgramacionId).HasColumnName("ProgramacionID");
            entity.Property(e => e.FechaProgramacion).HasColumnType("date");
            entity.Property(e => e.MecanicoId).HasColumnName("MecanicoID");
            entity.Property(e => e.VehiculoId).HasColumnName("VehiculoID");

            entity.HasOne(d => d.Mecanico).WithMany(p => p.Programacion)
                .HasForeignKey(d => d.MecanicoId)
                .HasConstraintName("FK_Programacion_Mecanico");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.Programacion)
                .HasForeignKey(d => d.VehiculoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Programacion_Vehiculo");
        });

        modelBuilder.Entity<Propetario>(entity =>
        {
            entity.HasKey(e => e.PropietarioId);

            entity.Property(e => e.PropietarioId).HasColumnName("PropietarioID");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(50);
            entity.Property(e => e.Direccion).HasMaxLength(50);
            entity.Property(e => e.Dni).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.TallerId).HasColumnName("TallerID");
            entity.Property(e => e.Telefono).HasMaxLength(50);

            entity.HasOne(d => d.Taller).WithMany(p => p.Propetario)
                .HasForeignKey(d => d.TallerId)
                .HasConstraintName("FK_Propetario_Taller");
        });

        modelBuilder.Entity<RecordatorioMantenimiento>(entity =>
        {
            entity.HasKey(e => e.RecordatorioId).HasName("PK__Recordat__9E9946082287FEB8");

            entity.Property(e => e.RecordatorioId).HasColumnName("RecordatorioID");
            entity.Property(e => e.FechaRecordatorio).HasColumnType("datetime");
            entity.Property(e => e.ProgramacionId).HasColumnName("ProgramacionID");

            entity.HasOne(d => d.Programacion).WithMany(p => p.RecordatorioMantenimiento)
                .HasForeignKey(d => d.ProgramacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecordatorioMantenimiento_Programacion");
        });

        modelBuilder.Entity<ReparacionMantenimiento>(entity =>
        {
            entity.HasKey(e => e.ReparacionMantenimientoId).HasName("PK__Reparaci__37F2AF838BA8050D");

            entity.Property(e => e.ReparacionMantenimientoId).HasColumnName("ReparacionMantenimientoID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.ProgramacionId).HasColumnName("ProgramacionID");

            entity.HasOne(d => d.Programacion).WithMany(p => p.ReparacionMantenimiento)
                .HasForeignKey(d => d.ProgramacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReparacionMantenimiento_Programacion");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.ServicioId).HasName("PK__Servicio__D5AEEC221070DCE0");

            entity.Property(e => e.ServicioId).HasColumnName("ServicioID");
            entity.Property(e => e.Costo).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DescripcionServicio).HasColumnType("text");
        });

        modelBuilder.Entity<Taller>(entity =>
        {
            entity.HasKey(e => e.TallerId).HasName("PK__Taller__2DABE2451090A081");

            entity.Property(e => e.TallerId).HasColumnName("TallerID");
            entity.Property(e => e.Contacto)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreTaller)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Sede)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.VehiculoId).HasName("PK__Vehiculo__AA08862019DAF57A");

            entity.Property(e => e.VehiculoId).HasColumnName("VehiculoID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Marca)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NumeroPlaca)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Vehiculo)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Vehiculo__Client__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

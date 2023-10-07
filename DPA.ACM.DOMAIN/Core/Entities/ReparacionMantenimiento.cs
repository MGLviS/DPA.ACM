using System;
using System.Collections.Generic;

namespace DPA.ACM.DOMAIN.Core.Entities;

public partial class ReparacionMantenimiento
{
    public int ReparacionMantenimientoId { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? Fecha { get; set; }

    public int ProgramacionId { get; set; }

    public virtual ICollection<DetalleInventario> DetalleInventario { get; set; } = new List<DetalleInventario>();

    public virtual ICollection<DetalleServicio> DetalleServicio { get; set; } = new List<DetalleServicio>();

    public virtual ICollection<DetallesFactura> DetallesFactura { get; set; } = new List<DetallesFactura>();

    public virtual Programacion Programacion { get; set; } = null!;
}

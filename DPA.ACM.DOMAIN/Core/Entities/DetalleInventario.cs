using System;
using System.Collections.Generic;

namespace DPA.ACM.DOMAIN.Core.Entities;

public partial class DetalleInventario
{
    public int DetalleInventarioId { get; set; }

    public int? CantidadUtilizada { get; set; }

    public int ReparacionMantenimientoId { get; set; }

    public int InventarioId { get; set; }

    public float PrecioTotal { get; set; }

    public virtual Inventario Inventario { get; set; } = null!;

    public virtual ReparacionMantenimiento ReparacionMantenimiento { get; set; } = null!;
}

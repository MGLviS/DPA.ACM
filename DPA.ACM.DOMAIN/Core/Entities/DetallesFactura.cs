using System;
using System.Collections.Generic;

namespace DPA.ACM.DOMAIN.Core.Entities;

public partial class DetallesFactura
{
    public int DetalleFacturaId { get; set; }

    public string? DescripcionServicio { get; set; }

    public decimal? PrecioServicio { get; set; }

    public int FacturaId { get; set; }

    public int ReparacionMantenimientoId { get; set; }

    public virtual Factura Factura { get; set; } = null!;

    public virtual ReparacionMantenimiento ReparacionMantenimiento { get; set; } = null!;
}

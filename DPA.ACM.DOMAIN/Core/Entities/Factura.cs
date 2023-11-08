using System;
using System.Collections.Generic;

namespace DPA.ACM.DOMAIN.Core.Entities;

public partial class Factura
{
    public int FacturaId { get; set; }

    public DateTime? FechaFacturacion { get; set; }

    public decimal? Total { get; set; }

    public int? ClienteId { get; set; }

    public bool? Cancelado { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<DetallesFactura> DetallesFactura { get; set; } = new List<DetallesFactura>();
}

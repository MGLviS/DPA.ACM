using System;
using System.Collections.Generic;

namespace DPA.ACM.DOMAIN.Core.Entities;

public partial class Inventario
{
    public int InventarioId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? VehiculoCompatible { get; set; }

    public int? CantidadStock { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public virtual ICollection<DetalleInventario> DetalleInventario { get; set; } = new List<DetalleInventario>();
}

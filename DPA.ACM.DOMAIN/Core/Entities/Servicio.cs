using System;
using System.Collections.Generic;

namespace DPA.ACM.DOMAIN.Core.Entities;

public partial class Servicio
{
    public int ServicioId { get; set; }

    public string? DescripcionServicio { get; set; }

    public decimal? Costo { get; set; }

    public virtual ICollection<DetalleServicio> DetalleServicio { get; set; } = new List<DetalleServicio>();
}

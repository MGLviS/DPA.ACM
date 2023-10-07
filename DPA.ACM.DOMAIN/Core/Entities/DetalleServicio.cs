using System;
using System.Collections.Generic;

namespace DPA.ACM.DOMAIN.Core.Entities;

public partial class DetalleServicio
{
    public int RepServicioId { get; set; }

    public int? ReparacionMantenimientoId { get; set; }

    public int? ServicioId { get; set; }

    public virtual ReparacionMantenimiento? ReparacionMantenimiento { get; set; }

    public virtual Servicio? Servicio { get; set; }
}

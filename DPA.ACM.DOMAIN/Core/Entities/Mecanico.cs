using System;
using System.Collections.Generic;

namespace DPA.ACM.DOMAIN.Core.Entities;

public partial class Mecanico
{
    public int MecanicoId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public string? Especialidad { get; set; }

    public int? TallerId { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<CargaTrabajo> CargaTrabajo { get; set; } = new List<CargaTrabajo>();

    public virtual ICollection<Programacion> Programacion { get; set; } = new List<Programacion>();

    public virtual Taller? Taller { get; set; }
}

using System;
using System.Collections.Generic;

namespace DPA.ACM.DOMAIN.Core.Entities;

public partial class Taller
{
    public int TallerId { get; set; }

    public string? NombreTaller { get; set; }

    public string? Sede { get; set; }

    public string? Direccion { get; set; }

    public string? Contacto { get; set; }

    public int? Estado { get; set; }

    public virtual ICollection<Mecanico> Mecanico { get; set; } = new List<Mecanico>();

    public virtual ICollection<Propetario> Propetario { get; set; } = new List<Propetario>();
}

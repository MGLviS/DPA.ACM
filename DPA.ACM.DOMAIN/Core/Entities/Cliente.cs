using System;
using System.Collections.Generic;

namespace DPA.ACM.DOMAIN.Core.Entities;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? Dni { get; set; }

    public string? Ruc { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();

    public virtual ICollection<Vehiculo> Vehiculo { get; set; } = new List<Vehiculo>();
}

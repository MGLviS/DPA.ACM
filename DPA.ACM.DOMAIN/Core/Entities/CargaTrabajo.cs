using System;
using System.Collections.Generic;

namespace DPA.ACM.DOMAIN.Core.Entities;

public partial class CargaTrabajo
{
    public int CargaId { get; set; }

    public int MecanicoId { get; set; }

    public DateTime? Fecha { get; set; }

    public TimeSpan? HoraInicio { get; set; }

    public string? HoraFin { get; set; }

    public virtual Mecanico Mecanico { get; set; } = null!;
}

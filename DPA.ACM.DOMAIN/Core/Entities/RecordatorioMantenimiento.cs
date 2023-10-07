using System;
using System.Collections.Generic;

namespace DPA.ACM.DOMAIN.Core.Entities;

public partial class RecordatorioMantenimiento
{
    public int RecordatorioId { get; set; }

    public int? Anticipacion { get; set; }

    public DateTime? FechaRecordatorio { get; set; }

    public int Hora { get; set; }

    public int? Estado { get; set; }

    public int ProgramacionId { get; set; }

    public virtual Programacion Programacion { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace DPA.ACM.DOMAIN.Core.Entities;

public partial class Programacion
{
    public int ProgramacionId { get; set; }

    public DateTime FechaProgramacion { get; set; }

    public TimeSpan? Hora { get; set; }

    public int VehiculoId { get; set; }

    public int? MecanicoId { get; set; }

    public int? Estado { get; set; }

    public virtual Mecanico? Mecanico { get; set; }

    public virtual ICollection<RecordatorioMantenimiento> RecordatorioMantenimiento { get; set; } = new List<RecordatorioMantenimiento>();

    public virtual ICollection<ReparacionMantenimiento> ReparacionMantenimiento { get; set; } = new List<ReparacionMantenimiento>();

    public virtual Vehiculo Vehiculo { get; set; } = null!;
}

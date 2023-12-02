using DPA.ACM.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.DTO
{
    public class ProgramacionDTO
    {
        public int ProgramacionId { get; set; }

        public DateTime FechaProgramacion { get; set; }

        public TimeSpan? Hora { get; set; }

        public int VehiculoId { get; set; }

        public int? MecanicoId { get; set; }

        public int? Estado { get; set; }

        public virtual Mecanico? Mecanico { get; set; }

        public virtual Vehiculo Vehiculo { get; set; } = null!;
    }

    public class PrograRegisterDTO
    {

        public DateTime FechaProgramacion { get; set; }

        public TimeSpan? Hora { get; set; }

        public int VehiculoId { get; set; }

        public int? MecanicoId { get; set; }

        public int? Estado { get; set; }

    }
    public class PrograResponseDTO
    {
        public int ProgramacionId { get; set; }

        public DateTime FechaProgramacion { get; set; }

        public TimeSpan? Hora { get; set; }

        public int VehiculoId { get; set; }

        public int? MecanicoId { get; set; }

        public int? Estado { get; set; }

    }

    public class PrograUpdateDTO
    {
        public int ProgramacionId { get; set; }

        public DateTime FechaProgramacion { get; set; }

        public TimeSpan? Hora { get; set; }

        public int VehiculoId { get; set; }

        public int? MecanicoId { get; set; }

        public int? Estado { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.DTO
{
    public class RepMantDTO
    {
        //public int ReparacionMantenimientoId { get; set; }

        public string? Descripcion { get; set; }

        public DateTime? Fecha { get; set; }

        public int ProgramacionId { get; set; }
    }

    public class ListRepMantDTO
    {
        public int ReparacionMantenimientoId { get; set; }

        public string? Descripcion { get; set; }

        public DateTime? Fecha { get; set; }

        public int ProgramacionId { get; set; }
    }

    public class UpdateRepMantDTO
    {
        //public int ReparacionMantenimientoId { get; set; }

        public string? Descripcion { get; set; }

        public DateTime? Fecha { get; set; }

        public int ProgramacionId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.DTO
{
    public class CrearDetFacturaDTO
    {
        public string? DescripcionServicio { get; set; }

        public decimal? PrecioServicio { get; set; }

        public int FacturaId { get; set; }

        public int ReparacionMantenimientoId { get; set; }
    }

    public class ListarDetFacturaDTO
    {
        public int DetalleFacturaId { get; set; }

        public string? DescripcionServicio { get; set; }

        public decimal? PrecioServicio { get; set; }

        public int FacturaId { get; set; }

        public RepMLista RepMantenimiento { get; set; }
    }
}

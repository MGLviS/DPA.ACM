using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.DTO
{
    public class InventarioTablaDTO
    {
        public int InventarioId { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public string? VehiculoCompatible { get; set; }

        public int? CantidadStock { get; set; }

        public decimal? PrecioUnitario { get; set; }
    }

    public class CrearInventarioDTO
    {
        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public string? VehiculoCompatible { get; set; }

        public int? CantidadStock { get; set; }

        public decimal? PrecioUnitario { get; set; }
    }

    public class ActualizarInventarioDTO
    {
        //public int InventarioId { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public string? VehiculoCompatible { get; set; }

        public int? CantidadStock { get; set; }

        public decimal? PrecioUnitario { get; set; }
    }
}

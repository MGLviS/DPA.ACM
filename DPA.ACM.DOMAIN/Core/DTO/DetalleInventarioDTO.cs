using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.DTO
{
    public class DIListarDTO
    {
        public int DetalleInventarioId { get; set; }
        public int? CantidadUtilizada { get; set; }
        public float PrecioTotal { get; set; }

        public DetInvDTO Inventario { get; set; }
    }

    public class DICrearDTO
    {
        //public int DetalleInventarioId { get; set; }

        public int? CantidadUtilizada { get; set; }

        public int ReparacionMantenimientoId { get; set; }

        public int InventarioId { get; set; }

        public float PrecioTotal { get; set; }
    }

    public class DIActualizarDTO
    {
        //public int DetalleInventarioId { get; set; }

        public int? CantidadUtilizada { get; set; }

        public int ReparacionMantenimientoId { get; set; }

        //public int InventarioId { get; set; }

        public float PrecioTotal { get; set; }
    }
}

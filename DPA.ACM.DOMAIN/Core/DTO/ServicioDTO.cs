using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.DTO
{
    public class CatalogoServicioDTO
    {
        public string? DescripcionServicio { get; set; }

        public decimal? Costo { get; set; }
    }

    public class ListaServicioDTO
    {
        public int ServicioId { get; set; }

        public string? DescripcionServicio { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.DTO
{
    public class CrearVehiculoDTO
    {
        public string? Marca { get; set; }

        public string? Modelo { get; set; }

        public int? Anio { get; set; }

        public string? NumeroPlaca { get; set; }

        public int? ClienteId { get; set; }
    }

    public class ListarVehiculoDTO
    {
        public int VehiculoId { get; set; }
        public string? Marca { get; set; }

        public string? Modelo { get; set; }

        public int? Anio { get; set; }

        public string? NumeroPlaca { get; set; }

        public int? ClienteId { get; set; }

        public ClienteListaDTO Cliente { get; set; }
    }

    public class ActualizarVehiculoDTO
    {
        public string? Marca { get; set; }

        public string? Modelo { get; set; }

        public int? Anio { get; set; }

        public string? NumeroPlaca { get; set; }

        public int? ClienteId { get; set; }
    }
}

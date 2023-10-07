using DPA.ACM.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.DTO
{
    public class PropietarioDTO
    {
        public int PropietarioId { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? CorreoElectronico { get; set; }

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        public string? Dni { get; set; }

        public string? Password { get; set; }

        public int? TallerId { get; set; }

        public virtual Taller? Taller { get; set; }

    }
    
    public class PropRegisterDTO
    {
        public int PropietarioId { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? CorreoElectronico { get; set; }

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        public string? Dni { get; set; }

        public string? Password { get; set; }

        public int? TallerId { get; set; }

        public virtual Taller? Taller { get; set; }
    }
}

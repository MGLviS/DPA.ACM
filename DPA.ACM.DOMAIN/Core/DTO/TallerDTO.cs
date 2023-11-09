using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.DTO
{
    public class TallerDTO
    {
        public int TallerId { get; set; }

        public string? NombreTaller { get; set; }

        public string? Sede { get; set; }

        public string? Direccion { get; set; }

        public string? Contacto { get; set; }

        public int? Estado { get; set; }
    }

    public class TallerRegisterDTO
    {

        public string? NombreTaller { get; set; }

        public string? Sede { get; set; }

        public string? Direccion { get; set; }

        public string? Contacto { get; set; }

        public int? Estado { get; set; }
    }

    public class TallerResponseDTO
    {
        public int TallerId { get; set; }

        public string? NombreTaller { get; set; }

        public string? Sede { get; set; }

        public string? Direccion { get; set; }

        public string? Contacto { get; set; }

        public int? Estado { get; set; }
    }

    public class TallerUpdateDTO
    {

        public string? NombreTaller { get; set; }

        public string? Sede { get; set; }

        public string? Direccion { get; set; }

        public string? Contacto { get; set; }

        public int? Estado { get; set; }
    }


}

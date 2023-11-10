using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA.ACM.DOMAIN.Core.Entities;

namespace DPA.ACM.DOMAIN.Core.DTO
{
    public class ClienteDTO
    {
        public int ClienteId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Dni { get; set; }
        public string? Ruc { get; set; }
        //public string Password { get; set; } = null!;
    }

    public class ClienteRegisterDTO
    {


        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Dni { get; set; }
        public string? Ruc { get; set; }
        public string Password { get; set; } = null!;
    }

    public class ClienteReponseDTO
    {
        public int ClienteId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Dni { get; set; }
        public string? Ruc { get; set; }

    }

    public class ClienteAuthDTO
    {
        public string? CorreoElectronico { get; set; }
        public string? Password { get; set; }
    }

    public class ClienteUpdateDTO
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Password  { get; set; }
    }

    public class ClienteListaDTO
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
    }

    public class ClienteGetName
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
    }

    public class ClienteFactDTO
    {
        public int ClienteId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Dni { get; set; }
        public string? Ruc { get; set; }
        public IEnumerable<FacturasxClientDTO> Factura { get; set; }
    }

}

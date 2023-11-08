using DPA.ACM.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.DTO
{
    public class MecanicoDTO
    {
        public int MecanicoId { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Telefono { get; set; }

        public string? Especialidad { get; set; }

        public int? TallerId { get; set; }

        public string? Estado { get; set; }

        //public virtual ICollection<CargaTrabajo> CargaTrabajo { get; set; } = new List<CargaTrabajo>();

        //public virtual ICollection<Programacion> Programacion { get; set; } = new List<Programacion>();

        public virtual Taller? Taller { get; set; }
    }

    public class MecanicoRegisterDTO
    {
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Telefono { get; set; }

        public string? Especialidad { get; set; }

        public int? TallerId { get; set; }

        public string? Estado { get; set; }

        //public virtual ICollection<CargaTrabajo> CargaTrabajo { get; set; } = new List<CargaTrabajo>();

        //public virtual ICollection<Programacion> Programacion { get; set; } = new List<Programacion>();

        public virtual Taller? Taller { get; set; }
    }

    public class MecanicoUpdateDTO
    {
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Telefono { get; set; }

        public string? Especialidad { get; set; }

        public int? TallerId { get; set; }

        public string? Estado { get; set; }

        //public virtual ICollection<CargaTrabajo> CargaTrabajo { get; set; } = new List<CargaTrabajo>();

        //public virtual ICollection<Programacion> Programacion { get; set; } = new List<Programacion>();

        public virtual Taller? Taller { get; set; }
    }

    public class MecanicoListaDTO
    {
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }
    }
}

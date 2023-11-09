using System;
namespace DPA.ACM.DOMAIN.Core.DTO
{
	public class FacturaDTO
    {
        public int FacturaId { get; set; }

        public DateTime? FechaFacturacion { get; set; }

        public decimal? Total { get; set; }

        public int? ClienteId { get; set; }

        public bool? Cancelado { get; set; }

    }

    public class FacturasStateDTO
    {
        public int FacturaId { get; set; }

        public DateTime? FechaFacturacion { get; set; }

        public decimal? Total { get; set; }

        public int? ClienteId { get; set; }
    }

    public class FactHistorialDTO
    {
        public int FacturaId { get; set; }

        public DateTime? FechaFacturacion { get; set; }

        public decimal? Total { get; set; }

    }

    public class FactCancelDTO
    {
        public bool? Cancelado { get; set; }
    }

    public class FactRegisterDTO
    {

        //public DateTime? FechaFacturacion { get; set; }

        public decimal? Total { get; set; }

        public int? ClienteId { get; set; }

        //public bool? Cancelado { get; set; }

    }


}


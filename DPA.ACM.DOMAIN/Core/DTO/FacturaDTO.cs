using System;
namespace DPA.ACM.DOMAIN.Core.DTO
{
	public class FacturaDTO
    {
        public int FacturaId { get; set; }

        public DateTime? FechaFacturacion { get; set; }

        public decimal? Total { get; set; }

        public int? ClienteId { get; set; }

    }
}


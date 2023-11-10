using System;
using AutoMapper;
using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Entities;

namespace DPA.ACM.DOMAIN.Infrastructure.Mapping
{
	public class AutomapperProfile : Profile
	{
		public AutomapperProfile()
		{
			CreateMap<Cliente, ClienteFactDTO>();
            CreateMap<ClienteFactDTO, Cliente>();
			CreateMap<Factura, FacturasxClientDTO>();
            CreateMap<FacturasxClientDTO, Factura>();

        }
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;

namespace DPA.ACM.DOMAIN.Core.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _servicioRepository;

        public ServicioService(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        public async Task<IEnumerable<ListaServicioDTO>> ListaServicio()
        {
            var servicios = await _servicioRepository.GetAll();

            var listaDTO = servicios.Select(item => new ListaServicioDTO
            {
                ServicioId = item.ServicioId,
                DescripcionServicio = item.DescripcionServicio,
            }).ToList();

            return listaDTO;
        }

        public async Task<IEnumerable<CatalogoServicioDTO>> CatalogoServicio(int id)
        {
            var busqueda = await _servicioRepository.GetById(id);

            if (busqueda == null)
                return null;

            var listaDTO = busqueda.Select(item => new CatalogoServicioDTO
            {
                DescripcionServicio = item.DescripcionServicio,
                Costo = item.Costo
            }).ToList();

            return listaDTO;
        }
    }


}

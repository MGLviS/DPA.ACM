using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA.ACM.DOMAIN.Infrastructure.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace DPA.ACM.DOMAIN.Core.Services
{
    public class MecanicoService : IMecanicoService

    {
        private readonly IMecanicoRepository _mecanicoRepository;

        public MecanicoService(IMecanicoRepository mecanicoRepository)
        {
            _mecanicoRepository = mecanicoRepository;

        }

        public async Task<IEnumerable<MecanicoDTO>> ShowMecanico()
        {
            var mecanico = await _mecanicoRepository.GetAll();
            //Convertir mecanico a mecanicoDTO
            var mecanicoList = new List<MecanicoDTO>();
            foreach (var item in mecanico)
            {
                mecanicoList.Add(new MecanicoDTO()
                {
                    MecanicoId = item.MecanicoId,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    Telefono = item.Telefono,
                    Especialidad = item.Especialidad,
                    Taller = item.Taller,
                    Estado = item.Estado
                });
            }

            return mecanicoList;
        }

        public async Task<bool> CreateMecanico(MecanicoRegisterDTO mecanicoDTO)
        {
            var existMecanico = await _mecanicoRepository.IsTelefonoRegistered(mecanicoDTO.Telefono);
            if (existMecanico) return false;

            var mecanico = new Mecanico()
            {
                Nombre = mecanicoDTO.Nombre,
                Apellido = mecanicoDTO.Apellido,
                Telefono = mecanicoDTO.Telefono,
                Especialidad = mecanicoDTO.Especialidad,
                TallerId = mecanicoDTO.TallerId,
                Estado = mecanicoDTO.Estado
                                

            };
            var result = await _mecanicoRepository.Insert(mecanico);
            return result;
        }
        
    }
}

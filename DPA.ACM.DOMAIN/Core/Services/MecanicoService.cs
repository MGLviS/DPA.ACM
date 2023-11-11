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

        public async Task<IEnumerable<MecanicoListDTO>> ShowMecanico()
        {
            var mecanico = await _mecanicoRepository.GetAll();
            //Convertir mecanico a mecanicoDTO
            var mecanicoList = new List<MecanicoListDTO>();
            foreach (var item in mecanico)
            {
                mecanicoList.Add(new MecanicoListDTO()
                {
                    MecanicoId = item.MecanicoId,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    Telefono = item.Telefono,
                    Especialidad = item.Especialidad,
                    TallerId = item.TallerId,
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

        public async Task<bool> Delete(int id)
        {
            var mecanico = await _mecanicoRepository.Delete(id);
            if (mecanico == false)
                return false;
            return mecanico;
        }

        public async Task<bool> UpdateMecanico(int id, MecanicoUpdateDTO mecanicoDTO)
        {
            var mecanico = new Mecanico()
            {
                Nombre = mecanicoDTO.Nombre,
                Apellido=mecanicoDTO.Apellido,
                Telefono=mecanicoDTO.Telefono,
                Especialidad=mecanicoDTO.Especialidad,
                TallerId=mecanicoDTO.TallerId,
                Estado=mecanicoDTO.Estado

            };

            var isMecanico = await _mecanicoRepository.Update(id, mecanico);
            if (isMecanico == null)
                return false;
            return isMecanico;
        }
        
    }
}

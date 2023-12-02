using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.Services
{
    public class ProgramacionService : IProgramacionService
    {
        private readonly IProgramacionRepository _prograRepository;

        public ProgramacionService(IProgramacionRepository prograRepository)
        {
            _prograRepository = prograRepository;
        }

        public async Task<bool> RegProgramacion(PrograRegisterDTO proDTO)
        {
            var prop = new Programacion()
            {
                FechaProgramacion = proDTO.FechaProgramacion,
                Hora = proDTO.Hora,
                VehiculoId = proDTO.VehiculoId,
                MecanicoId = proDTO.MecanicoId,
                Estado = proDTO.Estado
            };

            var result = await _prograRepository.RegProgramacion(prop);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var programacion = await _prograRepository.Delete(id);
            if (programacion == false)
                return false;
            return programacion;
        }

        public async Task<bool> Update(int id, PrograUpdateDTO progUpdateDTO)
        {
            var programacion = new Programacion()
            {
                FechaProgramacion = progUpdateDTO.FechaProgramacion,
                Hora = progUpdateDTO.Hora,
                VehiculoId = progUpdateDTO.VehiculoId,
                MecanicoId = progUpdateDTO.MecanicoId,
                Estado = progUpdateDTO.Estado
            };

            var isProgramacion = await _prograRepository.Update(id, programacion);
            if (isProgramacion == null)
                return false;
            return isProgramacion;
        }

        public async Task<IEnumerable<PrograResponseDTO>> ShowProgramacion()
        {
            var programacion = await _prograRepository.GetAll();
            var programacionList = new List<PrograResponseDTO>();
            foreach (var item in programacion)
            {
                programacionList.Add(new PrograResponseDTO()
                {
                    ProgramacionId = item.ProgramacionId,
                    FechaProgramacion = item.FechaProgramacion,
                    Hora = item.Hora,
                    VehiculoId = item.VehiculoId,
                    MecanicoId = item.MecanicoId,
                    Estado = item.Estado
                });
                
            }
            return programacionList;
        }
    }
}

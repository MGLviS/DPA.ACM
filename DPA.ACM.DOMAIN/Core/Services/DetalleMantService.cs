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


    public class DetalleMantService : IDetalleMantService
    {

        private readonly IDetalleMantRepository _detalleMantRepository;

        public DetalleMantService(IDetalleMantRepository detalleMantRepository)
        {
            _detalleMantRepository = detalleMantRepository;
        }

        public async Task<bool> Insert(RepMantDTO repMantDTO)
        {
            var repman = new ReparacionMantenimiento()
            {
                Descripcion = repMantDTO.Descripcion,
                Fecha = repMantDTO.Fecha,
                ProgramacionId = repMantDTO.ProgramacionId
            };

            var result = await _detalleMantRepository.Insert(repman);
            return result;
        }


        public async Task<IEnumerable<ListRepMantDTO>> GetAll()
        {
            var repman = await _detalleMantRepository.GetAll();
            var repmanDTO = repman.Select(item => new ListRepMantDTO()
            {
                ReparacionMantenimientoId = item.ReparacionMantenimientoId,
                Descripcion = item.Descripcion,
                Fecha = item.Fecha,
                ProgramacionId = item.ProgramacionId

            }).ToList();

            return repmanDTO;
        }

        public async Task<IEnumerable<ListRepMantDTO>> GetById(int id)
        {
            var repman = await _detalleMantRepository.GetById(id);

            if (repman == null) return null;

            var repmanDTO = repman.Select(item => new ListRepMantDTO()
            {
                ReparacionMantenimientoId = item.ReparacionMantenimientoId,
                Descripcion = item.Descripcion,
                Fecha = item.Fecha,
                ProgramacionId = item.ProgramacionId

            }).ToList();

            return repmanDTO;
        }

        public async Task<bool> Update(int id, UpdateRepMantDTO repMantDTO)
        {
            var repman = new ReparacionMantenimiento()
            {
                //ReparacionMantenimientoId = id,
                Descripcion = repMantDTO.Descripcion,
                Fecha = repMantDTO.Fecha,
                ProgramacionId = repMantDTO.ProgramacionId,
            };

            var isRepMan = await _detalleMantRepository.Update(id, repman);

            if (isRepMan == null) return false;
            return isRepMan;
        }

        public async Task<bool> Delete(int id)
        {
            var repman = await _detalleMantRepository.Delete(id);
            if (repman == false) return false;
            return repman;
        }
    }
}

using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.Services
{
    public class TallerService : ITallerService
    {

        private readonly ITallerRepository _tallerRepository;
        public TallerService(ITallerRepository tallerRepository)
        {
            _tallerRepository = tallerRepository;
        }
         

        public async Task<IEnumerable<TallerDTO>> ShowTalleres()
        {
            var taller = await _tallerRepository.GetAll();
            var tallerList = new List<TallerDTO>();
            foreach (var item in taller)
            {
                tallerList.Add(new TallerDTO()
                {
                    TallerId = item.TallerId,
                    NombreTaller = item.NombreTaller,
                    Sede = item.Sede,
                    Direccion = item.Direccion,
                    Contacto = item.Contacto,
                    Estado = item.Estado
                });
            }
            return tallerList;
        }

        public async Task<bool> RegistrarTaller(TallerRegisterDTO tallerRegisterDTO)
        {
            var taller = new Taller()
            {
                NombreTaller = tallerRegisterDTO.NombreTaller,
                Sede = tallerRegisterDTO.Sede,
                Direccion = tallerRegisterDTO.Direccion,
                Contacto = tallerRegisterDTO.Contacto,
                Estado = tallerRegisterDTO.Estado
            };
            var result = await _tallerRepository.RegisterTaller(taller);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var taller = await _tallerRepository.Delete(id);
            if (taller == false)
                return false;
            return taller;
        }

        public async Task<bool> UpdateTaller(int id, TallerUpdateDTO tallerUpdateDTO)
        {
            var taller = new Taller()
            {
                NombreTaller = tallerUpdateDTO.NombreTaller,
                Sede = tallerUpdateDTO.Sede,
                Direccion = tallerUpdateDTO.Direccion,
                Contacto = tallerUpdateDTO.Contacto,
                Estado = tallerUpdateDTO.Estado
            };
            var isTaller = await _tallerRepository.Update(id, taller);
            if (isTaller == null)
                return false;
            return isTaller;
        }
    }
}

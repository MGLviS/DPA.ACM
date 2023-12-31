﻿using DPA.ACM.DOMAIN.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IMecanicoService
    {
        Task<IEnumerable<MecanicoListDTO>> ShowMecanico();

        Task<bool> CreateMecanico(MecanicoRegisterDTO mecanicoDTO);

        Task<bool> Delete(int id);
        Task<bool> UpdateMecanico(int id, MecanicoUpdateDTO mecanicoDTO);
    }
}

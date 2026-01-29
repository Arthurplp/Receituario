using System;
using Domínio.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domínio.Interfaces
{
    public interface IVinculoService
    {
        Task<List<VinculoReceitaMaterial>> GetVinculos();
        Task<VinculoReceitaMaterial>? GetById(Guid Id);
        Task Delete(Guid Id);
        Task<VinculoReceitaMaterial> Create(VinculoReceitaMaterial vinculo);
        Task<VinculoReceitaMaterial> Edit(VinculoReceitaMaterial vinculo);
    }
}
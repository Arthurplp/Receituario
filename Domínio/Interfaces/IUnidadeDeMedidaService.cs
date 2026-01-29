using System;
using Domínio.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domínio.Interfaces
{
    public interface IUnidadeDeMedidaService
    {
        Task<List<UnidadeDeMedida>> GetUnidadeDeMedidas();
        Task<UnidadeDeMedida>? GetById(Guid Id);
        Task Delete(Guid Id);
        Task<UnidadeDeMedida> Create(UnidadeDeMedida unidadeDeMedida);
        Task<UnidadeDeMedida> Edit(UnidadeDeMedida unidadeDeMedida);

    }
}
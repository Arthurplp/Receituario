using Domínio.Model;

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
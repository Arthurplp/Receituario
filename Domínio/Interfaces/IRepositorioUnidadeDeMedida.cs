using Domínio.Model;

namespace Domínio.Interfaces
{
    public interface IRepositorioUnidadeDeMedida
    {
        Task Adicionar(UnidadeDeMedida mateunidadeDeMedidarial);
        Task<UnidadeDeMedida?> ObterPorId(Guid id);
        Task<List<UnidadeDeMedida>> ObterTodos();
        Task Atualizar(UnidadeDeMedida unidadeDeMedida);
        Task Remover(Guid id);
    }
}
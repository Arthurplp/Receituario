using Domínio.Model;

namespace Domínio.Interfaces
{
    public interface IRepositorioVinculo
    {
        Task Adicionar(VinculoReceitaMaterial vinculo);
        Task<VinculoReceitaMaterial?> ObterPorId(Guid id);
        Task<List<VinculoReceitaMaterial>> ObterTodos();
        Task Atualizar(VinculoReceitaMaterial vinculo);
        Task Remover(Guid id);
    }
}
using Domínio.Model;

namespace Domínio.Interfaces
{
    //aqui a gente cria os métodos que eu vou utilizar na service 

    public interface IVinculoService
    {
        Task<List<VinculoReceitaMaterial>> GetReceitas();
        Task<VinculoReceitaMaterial>? GetById(Guid Id);
        Task Delete(Guid Id);
        Task<VinculoReceitaMaterial> Create(VinculoReceitaMaterial vinculo);
        Task<VinculoReceitaMaterial> Edit(VinculoReceitaMaterial vinculo);
    }
}
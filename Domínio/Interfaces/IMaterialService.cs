using Domínio.Model;

namespace Domínio.Interfaces
{
    public interface IMaterialService
    {
        Task<List<Material>> GetMateriais();
        Task<Material>? GetById(Guid Id);
        Task Delete(Guid Id);
        Task<Material> Create(Material material);
        Task<Material> Edit(Material material);
    }
}

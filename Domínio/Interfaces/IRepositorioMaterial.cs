using System;
using Domínio.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domínio.Interfaces
{
    public interface IRepositorioMaterial
    {
        Task Adicionar(Material material);
        Task<Material?> ObterPorId(Guid id);
        Task<List<Material>> ObterTodos();
        Task Atualizar(Material material);
        Task Remover(Guid id);
    }
}

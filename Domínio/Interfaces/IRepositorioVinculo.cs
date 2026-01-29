using System;
using Domínio.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

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
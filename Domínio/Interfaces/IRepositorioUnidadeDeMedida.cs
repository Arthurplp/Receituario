using System;
using Domínio.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

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
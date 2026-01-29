using System;
using Domínio.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domínio.Interfaces
{

    public interface IReceitaService
    {
        Task<List<Receita>> GetReceitas();
        Task<Receita>? GetById(Guid Id);
        Task Delete(Guid Id);
        Task<Receita> Create(Receita receita);
        Task<Receita> Edit(Receita receita);
    }
}
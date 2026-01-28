using Domínio.Interfaces;
using Domínio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorios
{
    internal class RepositorioVinculo : IRepositorioVinculo
    {

        private readonly VinculoReceitaMaterial _vinculos = new VinculoReceitaMaterial;
        public Task Adicionar(VinculoReceitaMaterial vinculo)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(VinculoReceitaMaterial vinculo)
        {
            throw new NotImplementedException();
        }

        public Task<VinculoReceitaMaterial?> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<VinculoReceitaMaterial>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

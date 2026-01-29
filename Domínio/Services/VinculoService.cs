using System;
using Domínio.Model;
using Domínio.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domínio.Services
{
    internal class VinculoService : IVinculoService
    {
        private readonly IRepositorioVinculo _repositorioVinculo;
        private readonly IRepositorioReceita _repositorioReceita;
        private readonly IRepositorioMaterial _repositorioMaterial;

        public VinculoService(IRepositorioVinculo repositorioVinculo, IRepositorioReceita repositorioReceita, IRepositorioMaterial repositorioMaterial)
        {
            _repositorioVinculo = repositorioVinculo;
            _repositorioReceita = repositorioReceita;
            _repositorioMaterial = repositorioMaterial;
        }

        public async Task<VinculoReceitaMaterial> Create(VinculoReceitaMaterial vinculo)
        {
            if (vinculo == null)
            {
                Console.WriteLine("Os dados do Vínculo são nulos!");
                return null;
            }

            try
            {
                var receita = await _repositorioReceita.ObterPorId(vinculo.IdReceita);

                if (receita == null)
                {
                    Console.WriteLine("Receita não encontrada!");
                    return null;
                }

                var material = await _repositorioMaterial.ObterPorId(vinculo.IdMaterial);

                if (material == null)
                {
                    Console.WriteLine("Material não encontrado!");
                    return null;
                }

                await _repositorioVinculo.Adicionar(vinculo);
                return vinculo;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar o vínculo: {ex.Message}");
                return null;
            }
        }

        public Task Delete(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                Console.WriteLine("O Id fornecido é inválido!");
                return Task.CompletedTask;
            }

            try
            {
                return _repositorioVinculo.Remover(Id);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir o vínculo: {ex.Message}");
                throw;
            }
        }

        public async Task<VinculoReceitaMaterial> Edit(VinculoReceitaMaterial vinculo)
        {
            if (vinculo == null)
            {
                Console.WriteLine("Os dados do Vínculo são nulos!");
                return null;
            }

            try
            {
                await _repositorioVinculo.Atualizar(vinculo);
                return vinculo;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao editar o vínculo: {ex.Message}");
                return null;
            }
        }

        public Task<VinculoReceitaMaterial>? GetById(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                Console.WriteLine("O Id fornecido é inválido!");
                return null;
            }

            try
            {
                return _repositorioVinculo.ObterPorId(Id);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter o vínculo por Id: {ex.Message}");
                return null;
            }
        }

        public Task<List<VinculoReceitaMaterial>> GetVinculos()
        {
            try 
            {
                return _repositorioVinculo.ObterTodos();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter os vínculos: {ex.Message}");
                return Task.FromResult(new List<VinculoReceitaMaterial>());
            }
        }
    }
}

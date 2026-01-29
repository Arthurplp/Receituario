using System;
using Domínio.Model;
using Domínio.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domínio.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IRepositorioMaterial _repositorioMaterial;

        public MaterialService(IRepositorioMaterial repositorioMaterial)
        {
            _repositorioMaterial = repositorioMaterial;
        }


        public async Task<Material> Create(Material model)
        {
            if (model == null)
            {
                Console.WriteLine("Os dados da Material são nulos!");
                return null;
            }

            try
            {
                var material = new Material
                {
                    Id = Guid.NewGuid(),
                    Vinculos = model.Vinculos,
                    Nome = model.Nome,
                    UnidadeMedida = model.UnidadeMedida,
                    Codigo = model.Codigo,

                };

                await _repositorioMaterial.Adicionar(material);

                return material;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar a Material:{ex.Message}");
                throw;
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                await _repositorioMaterial.Remover(id);

                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir a Material: {ex.Message}");
                throw;
            }
        }

        public async Task<Material> Edit(Material model)
        {
            if (model == null)
            {
                Console.WriteLine("Os dados da Material são nulos!");
                return null;
            }

            try
            {
                var material = await _repositorioMaterial.ObterPorId(model.Id);

                if (material == null)
                {
                    Console.WriteLine("Material não encontrada!");
                    return null;
                }
                if (model.Vinculos != null)
                {
                    material.Vinculos = model.Vinculos;
                }
                if (model.Nome != null)
                {
                    material.Nome = model.Nome;
                }

                await _repositorioMaterial.Atualizar(material);

                return material;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Não foi possível editar a Receita: {ex.Message}");
                throw;
            }
        }

        public async Task<Material>? GetById(Guid Id)
        {
            try
            {
                var material = await _repositorioMaterial.ObterPorId(Id);

                if (material == null)
                {
                    Console.WriteLine("Material não encontrada!");
                    return null;
                }

                return material;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter a Material por Id: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Material>> GetMateriais()
        {
            try
            {
                var material = await _repositorioMaterial.ObterTodos();

                return material;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter as Material: {ex.Message}");
                throw;
            }
        }
    }
}
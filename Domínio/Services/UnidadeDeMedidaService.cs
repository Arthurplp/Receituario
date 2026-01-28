using Domínio.Interfaces;
using Domínio.Model;

namespace Domínio.Services
{
    internal class UnidadeDeMedidaService : IUnidadeDeMedidaService
    {
        private readonly IRepositorioUnidadeDeMedida _repositorioUnidadeDeMedida;

        public UnidadeDeMedidaService(IRepositorioUnidadeDeMedida repositorioUnidadeDeMedida)
        {
            _repositorioUnidadeDeMedida = repositorioUnidadeDeMedida;
        }

        public async Task<UnidadeDeMedida> Create(UnidadeDeMedida model)
        {
            if (model == null)
            {
                Console.WriteLine("Os dados da Receita são nulos!");
                return null;
            }

            try
            {
                var unidadeDeMedida = new UnidadeDeMedida
                {
                    Id = Guid.NewGuid(),
                    Identificador = model.Identificador,
                    Descricao = model.Descricao

                };

                await _repositorioUnidadeDeMedida.Adicionar(unidadeDeMedida);

                return unidadeDeMedida;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar a Receita:{ex.Message}");
                throw;
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                await _repositorioUnidadeDeMedida.Remover(id);

                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir a Receita: {ex.Message}");
                throw;
            }
        }

        public async Task<UnidadeDeMedida> Edit(UnidadeDeMedida model)
        {
            if (model == null)
            {
                Console.WriteLine("Os dados da Receita são nulos!");
                return null;
            }

            try
            {
                var unidadeDeMedida = await _repositorioUnidadeDeMedida.ObterPorId(model.Id);

                if (unidadeDeMedida == null)
                {
                    Console.WriteLine("Receita não encontrada!");
                    return null;
                }

                unidadeDeMedida.Descricao = model.Descricao;

                await _repositorioUnidadeDeMedida.Atualizar(unidadeDeMedida);

                return unidadeDeMedida;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Não foi possível editar a Receita: {ex.Message}");
                throw;
            }
        }

        public async Task<UnidadeDeMedida>? GetById(Guid Id)
        {
            try
            {
                var unidadeDeMedida = await _repositorioUnidadeDeMedida.ObterPorId(Id);

                if (unidadeDeMedida == null)
                {
                    Console.WriteLine("Receita não encontrada!");
                    return null;
                }

                return unidadeDeMedida;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter a Receita por Id: {ex.Message}");
                throw;
            }
        }

        public async Task<List<UnidadeDeMedida>> GetUnidadeDeMedidas()
        {
            try
            {
                var unidadeDeMedida = await _repositorioUnidadeDeMedida.ObterTodos();

                return unidadeDeMedida;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter as Receitas: {ex.Message}");
                throw;
            }
        }
    }
}

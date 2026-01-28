using Domínio.Interfaces;
using Domínio.Model;

namespace Domínio.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly IRepositorioReceita _repositorioReceita;

        public ReceitaService(IRepositorioReceita repositorioReceita)
        {
            _repositorioReceita = repositorioReceita;
        }

        public async Task<Receita> Create(Receita model)
        {
            if (model == null)
            {
                Console.WriteLine("Os dados da Receita são nulos!");
                return null;
            }

            try
            {
                var receita = new Receita
                {
                    Id = Guid.NewGuid(),
                    Descricao = model.Descricao,
                    Nome = model.Nome,
                    PesoTotal = model.PesoTotal,
                    ReceitaPai = model.ReceitaPai,
                    UnidadeMedida = model.UnidadeMedida,
                    SubReceitas = model.SubReceitas,
                    Vinculos = model.Vinculos
                };

                await _repositorioReceita.Adicionar(receita);

                return receita;
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
                await _repositorioReceita.Remover(id);

                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir a Receita: {ex.Message}");
                throw;
            }
        }

        public async Task<Receita> Edit(Receita model)
        {
            if (model == null)
            {
                Console.WriteLine("Os dados da Receita são nulos!");
                return null;
            }

            try
            {
                var receita = await _repositorioReceita.ObterPorId(model.Id);

                if (receita == null)
                {
                    Console.WriteLine("Receita não encontrada!");
                    return null;
                }

                receita.Descricao = model.Descricao;
                receita.Nome = model.Nome;
                receita.PesoTotal = model.PesoTotal;
                receita.ReceitaPai = model.ReceitaPai;
                receita.UnidadeMedida = model.UnidadeMedida;
                receita.SubReceitas = model.SubReceitas;
                receita.Vinculos = model.Vinculos;

                await _repositorioReceita.Atualizar(receita);

                return receita;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Não foi possível editar a Receita: {ex.Message}");
                throw;
            }
        }

        public async Task<Receita>? GetById(Guid Id)
        {
            try
            {
                var receita = await _repositorioReceita.ObterPorId(Id);

                if (receita == null)
                {
                    Console.WriteLine("Receita não encontrada!");
                    return null;
                }

                return receita;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter a Receita por Id: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Receita>> GetReceitas()
        {
            try
            {
                var receitas = await _repositorioReceita.ObterTodos();

                return receitas;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter as Receitas: {ex.Message}");
                throw;
            }
        }
    }
}
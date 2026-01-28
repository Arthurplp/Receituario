namespace Domínio.Model
{
    public class Material
    {
        public Guid Id { get; set; }
        public Guid? IdUnidadeMedida { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public UnidadeDeMedida UnidadeMedida { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public List<VinculoReceitaMaterial>? Vinculos { get; set; }

        public Material() { }

        public Material(string codigo, UnidadeDeMedida unidadeDeMedida, string nome)
        {
            this.Id = Guid.NewGuid();
            this.Codigo = codigo;
            this.UnidadeMedida = unidadeDeMedida;
            this.Nome = nome;
            this.IdUnidadeMedida = unidadeDeMedida.Id;
        }
    }
}
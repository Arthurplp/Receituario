namespace Domínio.Model
{
    public class VinculoReceitaMaterial
    {
        public Guid Id { get; set; }
        public Guid IdReceita { get; set; }
        public Guid IdMaterial { get; set; }
        public decimal? QuantidadeMaterial { get; set; }

        public VinculoReceitaMaterial() { }

        public VinculoReceitaMaterial(Guid receitaId, Guid materialId, decimal quantidadeMaterial)
        {
            IdReceita = receitaId;
            IdMaterial = materialId;
            QuantidadeMaterial = quantidadeMaterial;
        }
    }
}
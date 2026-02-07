using Domain.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyCom.Domains
{
    public sealed class CalculoDados : BaseEntity
    {
        public int Iduc { get; set; }
        [ForeignKey(nameof(Iduc))]
        public Uc? Uc { get; set; }
        public DateTime Competencia { get; set; }
        public double LeituraAtual { get; set; }
        public double LeituraAnterior { get; set; }
        public double ConsumoTotalKwh { get; set; }
        public double ConsumoPontaKwh { get; set; }
        public double ConsumoForaKwh { get; set; }
        public double TarifaKwh { get; set; }
        public double AliquotaIcms { get; set; }
        public double AliquotaPis { get; set; }
        public double AliquotaCofins { get; set; }
        public double ValorIcms { get; set; }
        public double ValorPis { get; set; }
        public double ValorCofins { get; set; }
        public double ValorSemImpostos { get; set; }
        public ICollection<Fatura> Faturas { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyCom.Domains
{
    public class CalculoDados
    {
        public int Id { get; set; }
        public int Iduc { get; set; }
        [ForeignKey(nameof(Iduc))]
        public Uc? Uc { get; set; }
        public DateTime Competencia { get; set; }
        public double LeituraAtual { get; set; }
        public double LeituraAnterior { get; set; }
        public double ConsumoTotalKwh { get; set; }
        public double ConsumoPontaKwh { get; set; }
        public double ConsumoForaKwh { get; set; }
        public ICollection<Fatura> Faturas { get; set; }
    }
}

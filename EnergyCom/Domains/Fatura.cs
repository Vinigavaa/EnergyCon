using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyCom.Domains
{
    public class Fatura
    {
        public int Id { get; set; }

        public double Valor { get; set; }

        public int Iduc {  get; set; }
        [ForeignKey(nameof(Iduc))]
        public Uc Uc { get; set; }

        public int IdCalculo { get; set; }
        [ForeignKey(nameof(IdCalculo))]
        public CalculoDados CalculoDados { get; set; }

        public EnumMotivoBaixa MotivoBaixa { get; set; }

        public enum EnumMotivoBaixa
        {
            [Description("Manual")]
            Manual = 1,

            [Description("Pix")]
            Pix = 2,

            [Description("Arrecadação")]
            Arrecadacao = 3,

            [Description("Debito em Conta")]
            DebitoConta = 4
        }

        public DateTime Competencia { get; set; }

        public DateTime DataPagamento { get; set; }

    }
}

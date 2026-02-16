using static EnergyCom.Domains.Fatura;

namespace Application.DTOs
{
    public class FaturaResponseDTO
    {
        public int Id { get; set; }
        public int Iduc { get; set; }
        public int IdCalculo { get; set; }
        public EnumMotivoBaixa MotivoBaixa { get; set; }
        public DateTime Competencia { get; set; }
        public double Valor { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}

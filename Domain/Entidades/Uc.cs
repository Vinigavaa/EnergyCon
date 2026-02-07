using Domain.Entidades;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyCom.Domains
{
    public sealed class Uc : BaseEntity
    {

        public int IdConsumidor { get; set; }

        [ForeignKey(nameof(IdConsumidor))]
        public Consumidor Consumidor { get; set; }

        public EnumGrupo Grupo { get; set; }
        public EnumClasse Classe { get; set; }
        public EnumSubClasse SubClasse { get; set; }

        public enum EnumGrupo
        {
            [Description("Baixa Tensão")]
            BaixaTensao = 0,

            [Description("Média Tensão")]
            MediaTensao = 1,

            [Description("Alta Tensão")]
            AltaTensao = 2
        }

        public enum EnumClasse
        {
            [Description("Residencial")]
            Residencial = 1,

            [Description("Industrial")]
            Industrial = 2,

            [Description("Comercial")]
            Comercial = 3
        }

        public enum EnumSubClasse
        {
            [Description("Rural")]
            Rural = 1,

            [Description("Urbano")]
            Urbano = 2
         }

        public ICollection<Fatura> Faturas { get; set; }
        public ICollection<CalculoDados> CalculoDados { get; set; }

    }
}

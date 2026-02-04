using static EnergyCom.Domains.Uc;

namespace EnergyCom.Dto
{
    public class UcDTO
    {
        public int IdConsumidor { get; set; }
        public EnumGrupo Grupo { get; set; }
        public EnumClasse Classe { get; set; }
        public EnumSubClasse SubClasse { get; set; }
    }
}

using static EnergyCom.Domains.Uc;

namespace Application.DTOs
{
    public class UcDTO
    {
        public int IdConsumidor { get; set; }
        public EnumGrupo Grupo { get; set; }
        public EnumClasse Classe { get; set; }
        public EnumSubClasse SubClasse { get; set; }
    }
}

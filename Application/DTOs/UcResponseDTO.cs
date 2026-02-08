using static EnergyCom.Domains.Uc;

namespace Application.DTOs
{
    public class UcResponseDTO
    {
        public int Id { get; set; }
        public int IdConsumidor { get; set; }
        public EnumGrupo Grupo { get; set; }
        public EnumClasse Classe { get; set; }
        public EnumSubClasse SubClasse { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}

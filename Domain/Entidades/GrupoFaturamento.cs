namespace Domain.Entidades
{
    public sealed class GrupoFaturamento : BaseEntity
    {
        public string Nome { get; set; }
        public DateTime Competencia { get; set; }

    }
}

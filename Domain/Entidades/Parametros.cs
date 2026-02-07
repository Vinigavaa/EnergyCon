namespace Domain.Entidades
{
    public sealed class Parametros : BaseEntity
    {
        public double TarifaKwh { get; set; }
        public double AliquotaIcms { get; set; }
        public double AliquotaPis { get; set; }
        public double AliquotaCofins { get; set; }
        public double ValorIcms { get; set; }
        public double ValorPis { get; set; }
        public double ValorCofins { get; set; }
        public double ValorSemImpostos { get; set; }


    }
}

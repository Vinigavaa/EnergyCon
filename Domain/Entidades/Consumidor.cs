using Domain.Entidades;

namespace EnergyCom.Domains
{
    public sealed class Consumidor : BaseEntity
    {

        public string Name { get; set; }

        public string Inscricao { get; set; }

        public string DebitoConta { get; set; }

        public ICollection<Uc> Ucs { get; set; }
    }
}

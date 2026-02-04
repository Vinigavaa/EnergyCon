namespace EnergyCom.Domains
{
    public class Consumidor
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string Inscricao { get; set; }

        public string DebitoConta { get; set; }

        public ICollection<Uc> Ucs { get; set; }
    }
}

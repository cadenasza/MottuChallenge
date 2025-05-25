namespace MottuChallenge.Model
{
    public class Vaga
    {
        public int Id { get; set; }
        public string Localizacao { get; set; }
        public bool Ocupada { get; set; }

        public ICollection<Ocupacao> Ocupacoes { get; set; }
    }
}

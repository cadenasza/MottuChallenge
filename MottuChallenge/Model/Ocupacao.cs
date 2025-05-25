namespace MottuChallenge.Model
{
    public class Ocupacao
    {
        public int Id { get; set; }

        public int MotoId { get; set; }
        public Motos Moto { get; set; }

        public int VagaId { get; set; }
        public Vaga Vaga { get; set; }

        public DateTime DataOcupacao { get; set; } = DateTime.Now;
    }
}

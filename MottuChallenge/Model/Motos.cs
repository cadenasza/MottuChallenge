
using System.ComponentModel.DataAnnotations.Schema;

namespace MottuChallenge.Model
{
    public class Motos
    {
        public int Id { get; set; }
        public string Chassi { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public int? VagaId { get; set; }
        public Vaga Vaga { get; set; }

    }
}

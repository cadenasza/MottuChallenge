using Microsoft.AspNetCore.Mvc;
using MottuChallenge.Data;
using MottuChallenge.Model;

namespace MottuChallenge.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class OcupacaoController : Controller
    {
        private readonly AppDbContext _context;

        public OcupacaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Ocupacao>> CriarOcupacao(Ocupacao ocupacao)
        {
            var moto = await _context.Motos.FindAsync(ocupacao.MotoId);
            var vaga = await _context.Set<Vaga>().FindAsync(ocupacao.VagaId);

            if (moto == null || vaga == null)
            {
                return BadRequest("Moto ou Vaga não encontrada.");
            }

            _context.Ocupacoes.Add(ocupacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CriarOcupacao), new { id = ocupacao.Id }, ocupacao);
        }
    }
}

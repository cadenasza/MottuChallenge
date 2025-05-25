using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MottuChallenge.Data;
using MottuChallenge.Model;

namespace MottuChallenge.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class MotoController : Controller
    {
        private readonly AppDbContext _context;
        public MotoController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motos>>> getMotos()
        {
            return await _context.Motos.ToListAsync();
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<Motos>> getMoto(int id)
        {
            var moto = await _context.Motos.FindAsync(id);

            if (moto == null)
            {
                return NotFound();
            }

            return moto;
        }
        [HttpGet("placa/{placa}")]
        public async Task<ActionResult<Motos>> getMotoByPlaca(string placa)
        {
            var placaMoto = await _context.Motos.FirstOrDefaultAsync(m => m.Placa == placa);

            if (placaMoto == null)
            {
                return NotFound();
            }

            return placaMoto;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMoto(int id, Motos moto)
        {
            if (id != moto.Id) 
            {
                return BadRequest();
            }
            _context.Entry(moto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotosExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Motos>> AddMoto(Motos moto)
        {
            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("getMoto", new { id = moto.Id}, moto);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMoto(int id)
        {
            var moto = await _context.Motos.FindAsync(id);

            if (moto == null)
            {
                return NotFound();
            }

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotosExist(int id)
        {
            return _context.Motos.Any(i => i.Id == id);
        }
        [HttpPut("{id}/vaga")]
        public async Task<IActionResult> AtualizarVagaDaMoto(int id, [FromBody] int novaVagaId)
        {
            var moto = await _context.Motos.FindAsync(id);
            var vaga = await _context.Set<Vaga>().FindAsync(novaVagaId);

            if (moto == null || vaga == null)
            {
                return NotFound("Moto ou Vaga não encontrada.");
            }

            moto.VagaId = novaVagaId;

            _context.Entry(moto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

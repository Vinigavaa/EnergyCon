using EnergyCom.Context;
using EnergyCom.Domains;
using EnergyCom.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EnergyCom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumidorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConsumidorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Consumidor>> Get()
        {
            var consumidor = _context.Consumidor.ToList();
            if (consumidor is null)
            {
                return NotFound();
            }
            return consumidor;
        }

        [HttpGet("{id}", Name = "ObterConsumidor")]
        public ActionResult<Consumidor> Get(int id)
        {
            var consumidor = _context.Consumidor.FirstOrDefault(x => x.Id == id);
            if(consumidor is null)
            {
                NotFound("Não existe um consumidor com esse id...");
            }
            return consumidor;
        }

        [HttpPost]
        public ActionResult Post(ConsumidorDTO consumidorDto)
        {
            if(consumidorDto is null)
            {
                return BadRequest();
            }

            var consumidor = new Consumidor
            {
                Name = consumidorDto.Name,
                Inscricao = consumidorDto.Inscricao,
                DebitoConta = consumidorDto.DebitoConta
            };

            _context.Consumidor.Add(consumidor);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterConsumidor",
                new { id = consumidor.Id }, consumidor);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, ConsumidorDTO consumidorDto)
        {
            if (consumidorDto is null)
            {
                return BadRequest();
            }

            var consumidor = _context.Consumidor.FirstOrDefault(x => x.Id == id);
            if (consumidor is null)
            {
                return NotFound("Não existe um consumidor com esse id...");
            }

            consumidor.Name = consumidorDto.Name;
            consumidor.Inscricao = consumidorDto.Inscricao;
            consumidor.DebitoConta = consumidorDto.DebitoConta;

            _context.SaveChanges();
            return Ok(consumidor);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var consumidor = _context.Consumidor.FirstOrDefault(c => c.Id == id);
            if(consumidor is null)
            {
                return NotFound();
            }

            var possuiUcs = _context.Uc.Any(u => u.IdConsumidor == id);

            if (possuiUcs)
            {
                return Conflict("Não é possível excluir o consumidor pois existem Ucs associadas a ele.");
            }
            _context.Consumidor.Remove(consumidor);
            _context.SaveChanges();

            return Ok(consumidor);
        }
    }
}
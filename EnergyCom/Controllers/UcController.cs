using EnergyCom.Context;
using EnergyCom.Domains;
using EnergyCom.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EnergyCom.Controllers
{
    [ApiController]
    [Route("api/uc")]
    public class UcController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UcController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Uc>> Get()
        {
            var ucs = _context.Uc.ToList();
            if(ucs is null) 
            {
                return NotFound("Não existe nenhuma uc cadastrada.");
            }
            return Ok(ucs);
        }

        [HttpGet("{id}", Name = "ObterUcPorId")]
        public ActionResult<Uc> GetById(int id)
        {
            var uc = _context.Uc.FirstOrDefault(u => u.Id == id);
            if(uc is null)
            {
                return NotFound("Não existe uma Uc com esse Id");
            }
            return Ok(uc);
        }

        [HttpPost]
        public ActionResult<Uc> Post(UcDTO ucDTO)
        {
            if (ucDTO is null)
            {
                return BadRequest();
            }

            var uc = new Uc
            {
                IdConsumidor = ucDTO.IdConsumidor,
                Grupo = ucDTO.Grupo,
                Classe = ucDTO.Classe,
                SubClasse = ucDTO.SubClasse,
            };

            var existConsumidor = _context.Consumidor.Any(c => c.Id == ucDTO.IdConsumidor);

            if (!existConsumidor)
            {
                return BadRequest("Não existe esse consumidor em nossa base de dados!");
            }

            _context.Uc.Add(uc);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterUcPorId",
                new { id = uc.Id }, uc);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, UcDTO ucDTO)
        {
            if (ucDTO is null)
            {
                return BadRequest();
            }

            var uc = _context.Uc.FirstOrDefault(u => u.Id == id);

            uc.IdConsumidor = ucDTO.IdConsumidor;
            uc.Classe = ucDTO.Classe;
            uc.SubClasse = ucDTO.SubClasse;
            uc.Grupo = ucDTO.Grupo;

            _context.SaveChanges();
            return Ok(uc);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var uc = _context.Uc.FirstOrDefault(c => c.Id == id);
            if(uc is null)
            {
                return NotFound();
            }
            _context.Uc.Remove(uc);
            _context.SaveChanges();
            return Ok(uc);
        }

    }
}

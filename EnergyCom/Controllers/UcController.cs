using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnergyCom.Controllers
{
    [ApiController]
    [Route("api/uc")]
    public class UcController : ControllerBase
    {
        private readonly IAplicUc _aplicUcService;

        public UcController(IAplicUc aplicUc)
        {
            _aplicUcService = aplicUc;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UcResponseDTO>>> Get(CancellationToken cancellationToken)
        {
            var ucs = await _aplicUcService.GetAll(cancellationToken);
            if (ucs is null || ucs.Count == 0)
            {
                return NotFound("Não existe nenhuma uc cadastrada.");
            }
            return Ok(ucs);
        }

        [HttpGet("{id}", Name = "ObterUcPorId")]
        public async Task<ActionResult<UcResponseDTO>> GetById(int id, CancellationToken cancellationToken)
        {
            var uc = await _aplicUcService.GetById(id, cancellationToken);
            if (uc is null)
            {
                return NotFound("Não existe uma Uc com esse Id");
            }
            return Ok(uc);
        }

        [HttpPost]
        public async Task<ActionResult<UcResponseDTO>> Post(UcDTO ucDTO, CancellationToken cancellationToken)
        {
            if (ucDTO is null)
            {
                return BadRequest();
            }

            try
            {
                var uc = await _aplicUcService.Create(ucDTO, cancellationToken);
                return new CreatedAtRouteResult("ObterUcPorId", new { id = uc.Id }, uc);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UcResponseDTO>> Put(int id, UcDTO ucDTO, CancellationToken cancellationToken)
        {
            if (ucDTO is null)
            {
                return BadRequest();
            }

            try
            {
                var uc = await _aplicUcService.Update(id, ucDTO, cancellationToken);
                return Ok(uc);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _aplicUcService.Delete(id, cancellationToken);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

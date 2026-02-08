using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnergyCom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumidorController : ControllerBase
    {
        private readonly IAplicConsumidor _aplicConsumidor;

        public ConsumidorController(IAplicConsumidor aplicConsumidor)
        {
            _aplicConsumidor = aplicConsumidor;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsumidorResponseDTO>>> Get(CancellationToken cancellationToken)
        {
            var consumidores = await _aplicConsumidor.GetAll(cancellationToken);
            if (consumidores is null || consumidores.Count == 0)
            {
                return NotFound("Não há nenhum consumidor cadastrado!");
            }
            return Ok(consumidores);
        }

        [HttpGet("{id}", Name = "ObterConsumidor")]
        public async Task<ActionResult<ConsumidorResponseDTO>> Get(int id, CancellationToken cancellationToken)
        {
            var consumidor = await _aplicConsumidor.GetById(id, cancellationToken);
            if (consumidor is null)
            {
                return NotFound("Não há nenhum consumidor cadastrado com esse ID");
            }
            return Ok(consumidor);
        }

        [HttpPost]
        public async Task<ActionResult<ConsumidorResponseDTO>> Post(ConsumidorDTO dto, CancellationToken cancellationToken)
        {
            if (dto is null)
            {
                return BadRequest();
            }

            try
            {
               var consumidor = await _aplicConsumidor.Create(dto, cancellationToken);
               return new CreatedAtRouteResult("ObterConsumidor", new { id = consumidor.Id }, consumidor);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ConsumidorResponseDTO>> Put(int id, ConsumidorDTO dto, CancellationToken cancellationToken)
        {
            if(dto is null)
            {
                return BadRequest();
            }

            try
            {
                var consumidor = await _aplicConsumidor.Update(id, dto, cancellationToken);
                return Ok(consumidor);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ConsumidorResponseDTO>> Delete(int id, CancellationToken cancellationToken)
        {
            var IdExiste = _aplicConsumidor.GetById(id, cancellationToken);

            if (IdExiste is null)
            {
                return BadRequest("Id não existe!");
            }

            try
            {
                await _aplicConsumidor.Delete(id, cancellationToken);
                return Ok();
            } catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces;
using EnergyCom.Domains;

namespace Application.Aplic
{
    public class AplicConsumidor : IAplicConsumidor
    {
        private readonly IConsumidorRepository _consumidorRepository;
        private readonly IConsumidorService _consumidorService;
        private readonly IUnitOfWork _unitOfWork;

        public AplicConsumidor(IConsumidorRepository consumidorRepository, IConsumidorService consumidorService, IUnitOfWork unitOfWork)
        {
            _consumidorRepository = consumidorRepository;
            _consumidorService = consumidorService;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ConsumidorResponseDTO>> GetAll(CancellationToken cancellationToken)
        {
            var consumidores = await _consumidorRepository.GetAll(cancellationToken);
            return consumidores.Select(MapToResponse).ToList();
        }

        public async Task<ConsumidorResponseDTO> GetById(int id, CancellationToken cancellation)
        {
            var consumidor = await _consumidorRepository.GetById(id, cancellation);
            if (consumidor == null)
            {
                return null;
            }

            return MapToResponse(consumidor);
        }

        public async Task<ConsumidorResponseDTO> Create(ConsumidorDTO dto, CancellationToken cancellationToken)
        {
            var consumidor = new Consumidor
            {
                Name = dto.Name,
                Inscricao = dto.Inscricao,
                DebitoConta = dto.DebitoConta,
            };

            _consumidorRepository.Create(consumidor);
            await _unitOfWork.Commit(cancellationToken);
            return MapToResponse(consumidor);
        }

        public async Task<ConsumidorResponseDTO> Update(int id, ConsumidorDTO dto, CancellationToken cancellationToken)
        {
            var consumidor = new Consumidor
            {
                Name = dto.Name,
                Inscricao = dto.Inscricao,
                DebitoConta = dto.DebitoConta,
            };

            _consumidorRepository.Update(consumidor);
            await _unitOfWork.Commit(cancellationToken);
            return MapToResponse(consumidor);
        }

        public async Task Delete (int id, CancellationToken cancellationToken)
        {
            var consumidor = await _consumidorRepository.GetById(id, cancellationToken);
            if (consumidor is null)
            {
                throw new KeyNotFoundException("Não existe um Consumidor com esse Id.");
            }
            //depois aplicar logica de faturas em aberto

            _consumidorRepository.Delete(consumidor);
            await _unitOfWork.Commit(cancellationToken);
        }

        private static ConsumidorResponseDTO MapToResponse(EnergyCom.Domains.Consumidor consumidor)
        {
            return new ConsumidorResponseDTO
            {
                Id = consumidor.Id,
                Name = consumidor.Name,
                Inscricao = consumidor.Inscricao,
                DebitoConta = consumidor.DebitoConta
            };
        }


    }
}

using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Services
{
    public class AplicUc : IAplicUc
    {
        private readonly IUcRepository _ucRepository;
        private readonly IConsumidorRepository _consumidorRepository;
        private readonly IUcService _ucService;
        private readonly IUnitOfWork _unitOfWork;

        public AplicUc(
            IUcRepository ucRepository,
            IConsumidorRepository consumidorRepository,
            IUcService ucService,
            IUnitOfWork unitOfWork)
        {
            _ucRepository = ucRepository;
            _consumidorRepository = consumidorRepository;
            _ucService = ucService;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UcResponseDTO>> GetAll(CancellationToken cancellationToken)
        {
            var ucs = await _ucRepository.GetAll(cancellationToken);
            return ucs.Select(MapToResponse).ToList();
        }

        public async Task<UcResponseDTO> GetById(int id, CancellationToken cancellationToken)
        {
            var uc = await _ucRepository.GetById(id, cancellationToken);
            if (uc is null)
                return null;

            return MapToResponse(uc);
        }

        public async Task<UcResponseDTO> Create(UcDTO dto, CancellationToken cancellationToken)
        {
            var consumidor = await _consumidorRepository.GetById(dto.IdConsumidor, cancellationToken);
            if (consumidor is null)
                throw new InvalidOperationException("Não existe esse consumidor em nossa base de dados!");

            var uc = _ucService.CriarUc(dto.IdConsumidor, dto.Grupo, dto.Classe, dto.SubClasse);

            _ucRepository.Create(uc);
            await _unitOfWork.Commit(cancellationToken);

            return MapToResponse(uc);
        }

        public async Task<UcResponseDTO> Update(int id, UcDTO dto, CancellationToken cancellationToken)
        {
            var uc = await _ucRepository.GetById(id, cancellationToken);
            if (uc is null)
                throw new KeyNotFoundException("Não existe uma Uc com esse Id.");

            _ucService.AtualizarUc(uc, dto.IdConsumidor, dto.Grupo, dto.Classe, dto.SubClasse);

            _ucRepository.Update(uc);
            await _unitOfWork.Commit(cancellationToken);

            return MapToResponse(uc);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var uc = await _ucRepository.GetById(id, cancellationToken);
            if (uc is null)
                throw new KeyNotFoundException("Não existe uma Uc com esse Id.");

            _ucRepository.Delete(uc);
            await _unitOfWork.Commit(cancellationToken);
        }

        private static UcResponseDTO MapToResponse(EnergyCom.Domains.Uc uc)
        {
            return new UcResponseDTO
            {
                Id = uc.Id,
                IdConsumidor = uc.IdConsumidor,
                Grupo = uc.Grupo,
                Classe = uc.Classe,
                SubClasse = uc.SubClasse,
                CreatedAt = uc.CreatedAt,
                UpdatedAt = uc.UpdatedAt
            };
        }
    }
}

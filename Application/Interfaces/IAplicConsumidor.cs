using Application.DTOs;

namespace Application.Interfaces
{
    public interface IAplicConsumidor
    {
        Task<List<ConsumidorResponseDTO>> GetAll(CancellationToken cancellationToken);
        Task<ConsumidorResponseDTO> GetById(int id, CancellationToken cancellationToken);
        Task<ConsumidorResponseDTO> Create(ConsumidorDTO dto, CancellationToken cancellationToken);
        Task<ConsumidorResponseDTO> Update(int id, ConsumidorDTO dto, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}

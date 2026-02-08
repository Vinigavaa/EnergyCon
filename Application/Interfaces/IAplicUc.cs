using Application.DTOs;

namespace Application.Interfaces
{
    public interface IAplicUc
    {
        Task<List<UcResponseDTO>> GetAll(CancellationToken cancellationToken);
        Task<UcResponseDTO> GetById(int id, CancellationToken cancellationToken);
        Task<UcResponseDTO> Create(UcDTO dto, CancellationToken cancellationToken);
        Task<UcResponseDTO> Update(int id, UcDTO dto, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
    }
}

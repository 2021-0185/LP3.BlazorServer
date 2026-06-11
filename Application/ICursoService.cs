using LP3.BlazorServer.Shared.DTOs;

namespace LP3.BlazorServer.Application.Services
{
    public interface ICursoService
    {
        Task<IEnumerable<CursoDto>> GetAllAsync();
        Task<CursoDto?> GetByIdAsync(int id);
        Task<CursoDto?> GetByCodigoAsync(string codigo);
        Task<bool> CreateAsync(CursoFormDto dto); // Usamos CursoFormDto para recibir datos del formulario
        Task<bool> UpdateAsync(int id, CursoFormDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
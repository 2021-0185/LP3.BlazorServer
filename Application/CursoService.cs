using LP3.BlazorServer.Data.Repositories;
using LP3.BlazorServer.Shared.DTOs;
using LP3.BlazorServer.Shared.Extensions;

namespace LP3.BlazorServer.Application.Services
{
    public class CursoService : ICursoService
    {
        // 1. Dejamos una Sola variable privada en minúscula y con su tipo correcto
        private readonly ICursoRepository _cursoRepository;

        // 2. El constructor recibe el repositorio y lo asigna a la variable correcta
        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        // 1. Obtener todos los cursos
        public async Task<IEnumerable<CursoDto>> GetAllAsync()
        {
            // Corregido: usamos _cursoRepository
            var cursos = await _cursoRepository.ListAsync();
            return cursos.Select(c => c.ToDto());
        }

        // 2. Obtener curso por ID
        public async Task<CursoDto?> GetByIdAsync(int id)
        {
            var curso = await _cursoRepository.GetByIdAsync(id);
            return curso?.ToDto();
        }

        // 3. Buscar curso por código
        public async Task<CursoDto?> GetByCodigoAsync(string codigo)
        {
            var curso = await _cursoRepository.GetByCodigoAsync(codigo);
            return curso?.ToDto();
        }

        // 4. Crear nuevo curso
        public async Task<bool> CreateAsync(CursoFormDto dto)
        {
            if (dto == null) return false;

            var nuevaEntidad = dto.ToEntity();
            
            await _cursoRepository.AddAsync(nuevaEntidad);
            return await _cursoRepository.SaveChangesAsync();
        }

        // 5. Actualizar curso existente
        public async Task<bool> UpdateAsync(int id, CursoFormDto dto)
        {
            if (dto == null || id != dto.Id) return false;

            var cursoExistente = await _cursoRepository.GetByIdAsync(id);
            if (cursoExistente == null) return false;

            cursoExistente.Nombre = dto.Nombre;
            cursoExistente.Codigo = dto.Codigo;
            cursoExistente.Creditos = dto.Creditos;
            cursoExistente.Activo = dto.Activo;

            _ = _cursoRepository.Update(cursoExistente);
            
            // Corregido: usamos _cursoRepository
            return await _cursoRepository.SaveChangesAsync();
        }

        // 6. Eliminar curso
        public async Task<bool> DeleteAsync(int id)
        {
            var curso = await _cursoRepository.GetByIdAsync(id);
            if (curso == null) return false;

            _cursoRepository.Delete(curso);
            
            // Corregido: usamos _cursoRepository
            return await _cursoRepository.SaveChangesAsync();
        }
    }
}
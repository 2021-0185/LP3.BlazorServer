using LP3.BlazorServer.Domain.Entities;
using LP3.BlazorServer.Shared.DTOs;


namespace LP3.BlazorServer.Shared.Extensions
{
    public static class CursoExtensions
    {
        // Convierte de Entidad de Base de Datos (Curso) a DTO de lectura (CursoDto)
        public static CursoDto ToDto(this Curso curso)
        {
            if (curso == null) return null!;

            return new CursoDto
            {
                Id = curso.Id,
                Nombre = curso.Nombre,
                Codigo = curso.Codigo,
                Creditos = curso.Creditos,
                Activo = curso.Activo
            };
        }

        // Convierte de DTO de Formulario (CursoFormDto) a Entidad de Base de Datos (Curso)
        public static Curso ToEntity(this CursoFormDto dto)
        {
            if (dto == null) return null!;

            return new Curso
            {
                // Si el Id es nulo (curso nuevo), se asigna 0 para que EF lo detecte como nuevo
                Id = dto.Id ?? 0, 
                Nombre = dto.Nombre,
                Codigo = dto.Codigo,
                Creditos = dto.Creditos,
                Activo = dto.Activo
            };
        }
    }
}
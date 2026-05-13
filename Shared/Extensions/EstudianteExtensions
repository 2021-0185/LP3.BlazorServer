namespace LP3.BlazorServer.Shared.Extensions;
using LP3.BlazorServer.Domain.Entities;
using LP3.BlazorServer.Shared.DTOs;

/// <summary>
/// Métodos de conversión entre Entidad y DTO.
/// </summary>
public static class EstudianteExtensions
{
    public static EstudianteDto ToDto(this Estudiante e)
        => new()
        {
            Id        = e.Id,
            Nombre    = e.Nombre,
            Apellido  = e.Apellido,
            Matricula = e.Matricula,
            Estado    = e.Estado.ToString()
        };

    public static Estudiante ToEntity(this EstudianteFormDto dto)
        => new()
        {
            Nombre    = dto.Nombre,
            Apellido  = dto.Apellido,
            Matricula = dto.Matricula,
            Email     = dto.Email,
            Estado    = dto.Estado
        };
}
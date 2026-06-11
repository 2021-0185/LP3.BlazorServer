using LP3.BlazorServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LP3.BlazorServer.Data.Repositories;

#pragma warning disable CS9107 // El parámetro se captura en el estado del tipo envolvente y su valor también se pasa al constructor base. La clase base también puede capturar el valor.
public class EstudianteRepository(ApplicationDbContext context) : Repository<Estudiante>(context), IEstudianteRepository
#pragma warning restore CS9107 // El parámetro se captura en el estado del tipo envolvente y su valor también se pasa al constructor base. La clase base también puede capturar el valor.
{
	public async Task<Estudiante?> GetByMatriculaAsync(string matricula)
	{
		return await context.Estudiantes
			.AsNoTracking()
			.FirstOrDefaultAsync(e => e.Matricula == matricula);
	}
}
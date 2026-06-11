using LP3.BlazorServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LP3.BlazorServer.Data.Repositories
{
    // Hereda de la clase base Repository y además implementa tu interfaz de Cursos
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        private readonly ApplicationDbContext _context;

        // El constructor recibe el DbContext y se lo pasa correctamente a la clase base
        public CursoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // ÚNICO método personalizado que requiere este repositorio específico
        public async Task<Curso?> GetByCodigoAsync(string codigo)
        {
            return await _context.Cursos
                .AsNoTracking() // Optimiza la consulta para operaciones de solo lectura
                .FirstOrDefaultAsync(c => c.Codigo == codigo);
        }

        // Método de persistencia requerido por tu interfaz
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
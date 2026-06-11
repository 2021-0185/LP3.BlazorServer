using LP3.BlazorServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LP3.BlazorServer.Data.Repositories
{
    // Al heredar de IRepository<Curso>, ya ganas ListAsync(), AddAsync(), Update() y Remove()
    public interface ICursoRepository : IRepository<Curso>
    {
        // Único método de consulta personalizado para este módulo
        Task<Curso?> GetByCodigoAsync(string codigo);

        // Contrato para confirmar los cambios en la base de datos
        Task<bool> SaveChangesAsync();
    }
}
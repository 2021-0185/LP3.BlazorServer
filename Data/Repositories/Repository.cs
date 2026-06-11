namespace LP3.BlazorServer.Data.Repositories;
using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _set;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _set = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id) => await _set.FindAsync(id);
    
    public async Task<IReadOnlyList<T>> ListAsync() => await _set.AsNoTracking().ToListAsync();
    
    public async Task AddAsync(T entity)
    {
        await _set.AddAsync(entity);
        // Quitamos el SaveChanges de aquí para delegarlo al flujo del Servicio
    }

    public async Task Update(T entity)
    {
        _set.Update(entity);
        // Al quitar el SaveChanges de aquí, permitimos un control de transacciones limpio
    }

    public async Task Remove(T entity)
    {
        _set.Remove(entity);
    }

    // Agregamos el método de manera genérica para que todos los repositorios hijos lo hereden de forma nativa
    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
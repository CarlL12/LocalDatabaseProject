using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public abstract class Repo<Tentity, TContext> where Tentity : class where TContext : DbContext
{
    private readonly TContext _context;

    protected Repo(TContext context)
    {
        _context = context;
    }

    public virtual async Task<Tentity> AddAsync(Tentity entity)
    {
        try
        {
            _context.Set<Tentity>().Add(entity);

            await _context.SaveChangesAsync();
            return entity;

        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public virtual async Task<IEnumerable<Tentity>> GetAllAsync()
    {
        try
        {
            var result = await _context.Set<Tentity>().ToListAsync();

            if (result != null)
            {

                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }


    public virtual async Task<Tentity> GetOneAsync(Expression<Func<Tentity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<Tentity>().FirstOrDefaultAsync(predicate);

            if (result != null)
            {

                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }
    public virtual async Task<Tentity> UpdateAsync(Expression<Func<Tentity, bool>> predicate, Tentity updatedEntity)
    {
        try
        {
            var existingEntity = await _context.Set<Tentity>().FirstOrDefaultAsync(predicate);

            if (existingEntity != null)
            {
                
                _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);

                await _context.SaveChangesAsync();

                return existingEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }
    public virtual async Task<bool> DeleteAsync(Expression<Func<Tentity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<Tentity>().FirstOrDefaultAsync(predicate);

            if (result != null)
            {

                _context.Set<Tentity>().Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }

        return false!;
    }

    public virtual async Task<bool> ExistsAsync(Expression<Func<Tentity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<Tentity>().AnyAsync(predicate);

            return result;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }

        return false!;
    }
}

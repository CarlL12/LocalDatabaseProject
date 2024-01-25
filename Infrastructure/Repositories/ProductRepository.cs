

using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public  class ProductRepository : Repo<ProductEntity, ProductContext>
{
    private readonly ProductContext _context;

    public ProductRepository(ProductContext context) : base(context)
    {
        _context = context;
    }

    public async  Task<IEnumerable<ProductEntity>> GetWithAllAsync()
    {
        try
        {
            var result = await _context.Products.Include(x => x.Category).Include(x => x.Manufacture).Include(x => x.Price).Include(x => x.ProductPicture).ToListAsync();

            if (result != null)
            {

                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public async Task<ProductEntity> GetOneWithAllAsync(Expression<Func<ProductEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Products.Include(x => x.Category).Include(x => x.Manufacture).Include(x => x.Price).Include(x => x.ProductPicture).FirstOrDefaultAsync(predicate);

            if (result != null)
            {

                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }
}


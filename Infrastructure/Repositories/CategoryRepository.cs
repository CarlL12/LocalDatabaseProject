
using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;
public class CategoryRepository : Repo<CategoryEntity, ProductContext>
{
    private readonly ProductContext _context;

    public CategoryRepository(ProductContext context) : base(context)
    {
        _context = context;
    }
}

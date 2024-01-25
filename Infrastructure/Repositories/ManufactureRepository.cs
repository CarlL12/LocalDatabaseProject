
using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public  class ManufactureRepository : Repo<ManufactureEntity, ProductContext>
{
    private readonly ProductContext _context;

    public ManufactureRepository(ProductContext context) : base(context)
    {
        _context = context;
    }
}

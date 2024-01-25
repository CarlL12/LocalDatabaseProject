

using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public  class PriceRepository : Repo<PriceEntity, ProductContext>
{
    private readonly ProductContext _context;

    public PriceRepository(ProductContext context) : base(context)
    {
        _context = context;
    }
}

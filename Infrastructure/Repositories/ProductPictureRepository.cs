
using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public  class ProductPictureRepository : Repo<ProductPictureEntity, ProductContext>
{
    private readonly ProductContext _context;

    public ProductPictureRepository(ProductContext context) : base(context)
    {
        _context = context;
    }
}

using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public  class WorkPlaceRepository : Repo<WorkPlaceEntity, DataContext>
{
    private readonly DataContext _context;

    public WorkPlaceRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}

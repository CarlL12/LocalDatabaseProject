using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public  class EducationRepository : Repo<EducationEntity, DataContext>
{
    private readonly DataContext _context;

    public EducationRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}

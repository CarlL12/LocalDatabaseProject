using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public  class ContactInformationRepository : Repo<ContactInformationEntity, DataContext>
{
    private readonly DataContext _context;

    public ContactInformationRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}


using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public  class ContactAddressRepository : Repo<ContactAddressEntity, DataContext>
{
    private readonly DataContext _context;

    public ContactAddressRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}

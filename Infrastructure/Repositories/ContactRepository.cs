using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public  class ContactRepository : Repo<ContactEntity, DataContext>
{
    private readonly DataContext _context;

    public ContactRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ContactEntity>> GetWithAllAsync()
    {
        try
        {
            var result = await _context.Contacts.Include(x => x.ContactAddress).Include(x => x.ContactInformation).Include(x => x.Education).Include(x => x.WorkPlace).ToListAsync();

            if (result != null)
            {

                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public async Task<ContactEntity> GetOneWithAllAsync(Expression<Func<ContactEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Contacts.Include(x => x.ContactAddress).Include(x => x.ContactInformation).Include(x => x.Education).Include(x => x.WorkPlace).FirstOrDefaultAsync(predicate);

            if (result != null)
            {

                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }
}

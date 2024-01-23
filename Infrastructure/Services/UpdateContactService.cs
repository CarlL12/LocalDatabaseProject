using Infrastructure.Entities;
using Infrastructure.Repositories;
namespace Infrastructure.Services;

public  class UpdateContactService(ContactRepository contactRepository, ContactAddressRepository addressRepository, ContactInformationRepository informationRepository, EducationRepository educationRepository, WorkPlaceRepository workPlaceRepository)
{
    private readonly ContactRepository _contactRepository = contactRepository;
    private readonly ContactAddressRepository _addressRepository = addressRepository;
    private readonly ContactInformationRepository _informationRepository = informationRepository;
    private readonly EducationRepository _educationRepository = educationRepository;
    private readonly WorkPlaceRepository _workPlaceRepository = workPlaceRepository;

    public async Task<bool> UpdateContactAsync(ContactEntity entity)
    {
        var personidResult = await _contactRepository.ExistsAsync(x => x.PersonId == entity.PersonId);

        if(personidResult)
        {
            return true;
        }
        return false;
    }
}

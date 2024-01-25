using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public  class ContactService (ContactRepository contactRepository, ContactAddressRepository addressRepository, ContactInformationRepository informationRepository, EducationRepository educationRepository, WorkPlaceRepository workPlaceRepository)
{
    private readonly ContactRepository _contactRepository = contactRepository;
    private readonly ContactAddressRepository _addressRepository = addressRepository;
    private readonly ContactInformationRepository _informationRepository = informationRepository;
    private readonly EducationRepository _educationRepository = educationRepository;
    private readonly WorkPlaceRepository _workPlaceRepository = workPlaceRepository;

    public async Task<bool> CreateContactAsync(Contact contact)
    {
        var newContact = new ContactEntity();

        var workPlaceResult = await CreateWorkPlaceAsync(contact);

        var educationResult = await CreateEducationAsync(contact);

        var addressResult = await CreateContactAddressAsync(contact);


        newContact.PersonId = contact.PersonId;
        newContact.FirstName = contact.FirstName;
        newContact.LastName = contact.LastName;
        newContact.Age = contact.Age;
        newContact.ContactAddressId = addressResult.Id;
        newContact.WorkPlaceId = workPlaceResult.Id;
        newContact.EducationId = educationResult.Id;

        var result = await _contactRepository.AddAsync(newContact);

        if(result != null)
        {
            var infoResult = await CreateContactInformationAsync(contact);

            return infoResult;
        }
        else
        {
            return false;
        }

    }

    public async Task<bool> CreateContactInformationAsync(Contact contact)
    {

        var newEntity = new ContactInformationEntity();

            newEntity.ContactId = contact.PersonId;
            newEntity.Email = contact.Email;
            newEntity.PhoneNumber = contact.PhoneNumber;

          var result =  await _informationRepository.AddAsync(newEntity);
            
        if(result != null)
        {
            return true;
        }
        else
        {
            return false;
        }


    }
    public async Task<WorkPlaceEntity> CreateWorkPlaceAsync(Contact contact)

    {
         var existingCompanyName = await _workPlaceRepository.GetOneAsync(x => x.CompanyName == contact.CompanyName);
        var existingTitle = await _workPlaceRepository.GetOneAsync(x => x.Title == contact.Title);

        var newWorkPlace = new WorkPlaceEntity();
        
        if (existingCompanyName != null)
        {
            newWorkPlace.CompanyName = existingCompanyName.CompanyName;
        }
        else
        {
            newWorkPlace.CompanyName = contact.CompanyName;
        }
        if (existingTitle != null)
        {
            newWorkPlace.Title = existingTitle.Title;
            newWorkPlace.Id = existingTitle.Id;

            return newWorkPlace;
        }
        else
        {
            newWorkPlace.Title = contact.Title;

            var result = await _workPlaceRepository.AddAsync(newWorkPlace);

            return newWorkPlace;
        }

       
    }

    public async Task<EducationEntity> CreateEducationAsync(Contact contact)
    {
        var existingEducation = await _educationRepository.GetOneAsync(x => x.EducationName == contact.EducationName);
        var existingInstitutionName = await _educationRepository.GetOneAsync(x => x.InstitutionName == contact.InstitutionName);

        var newEducation = new EducationEntity();

        if (existingEducation != null)
        {
            newEducation.EducationName = existingEducation.EducationName;

        }
        else
        {
            newEducation.EducationName = contact.EducationName;
        }
        if (existingInstitutionName != null)
        {
            newEducation.InstitutionName = existingInstitutionName.InstitutionName;
            newEducation.Id = existingInstitutionName.Id;

            return newEducation;

        }
        else
        {
            newEducation.InstitutionName = contact.InstitutionName;
        }

        var result = await _educationRepository.AddAsync(newEducation);



        return newEducation;

    }

    public async Task<ContactAddressEntity> CreateContactAddressAsync(Contact contact)
    {
        var existingStreetName = await _addressRepository.GetOneAsync(x => x.StreetName == contact.StreetName);
        var existingPostalCode = await _addressRepository.GetOneAsync(x => x.PostalCode == contact.PostalCode);
        var existingCity = await _addressRepository.GetOneAsync(x => x.City == contact.City); 

        var contactAddress = new ContactAddressEntity();

        if (existingStreetName != null)
        {
            contactAddress.StreetName = existingStreetName.StreetName;
        }
        else
        {
            contactAddress.StreetName = contact.StreetName;
        }
        if (existingPostalCode != null)
        {
            contactAddress.PostalCode = existingPostalCode.PostalCode;
        }
        else
        {
            contactAddress.PostalCode = contact.PostalCode;
        }
        if(existingCity != null)
        {
            contactAddress.City = existingCity.City;
            contactAddress.Id = existingCity.Id;

            return contactAddress;
        }
        else
        {
            contactAddress.City = contact.City;
        }

        var result = await _addressRepository.AddAsync(contactAddress);


        return contactAddress;
    }

    public async Task<IEnumerable<Contact>> GetAllContacts ()
    {
        var list = new List<Contact>();
        var result = await _contactRepository.GetWithAllAsync();

        Console.Clear();
        if (result != null)
        {
            foreach (ContactEntity contactEntity in result)
            {
                var contact = new Contact
                {
                    PersonId = contactEntity.PersonId,
                    FirstName = contactEntity.FirstName,
                    LastName = contactEntity.LastName,
                    Age = contactEntity.Age,
                    StreetName = contactEntity.ContactAddress.StreetName,
                    City = contactEntity.ContactAddress.City,
                    PostalCode = contactEntity.ContactAddress.PostalCode,
                    Email = contactEntity.ContactInformation.Email,
                    PhoneNumber = contactEntity.ContactInformation.PhoneNumber,
                    CompanyName = contactEntity.WorkPlace.CompanyName,
                    Title = contactEntity.WorkPlace.Title,
                    EducationName = contactEntity.Education.EducationName,
                    InstitutionName = contactEntity.Education.InstitutionName,
                };

                list.Add(contact);
            };

            return list;
        }
        else 
        { 
            return null!; 
        }
        
    }

    public async Task<Contact> GetOneAsync(string personId)
    {
        var result = await _contactRepository.GetOneWithAllAsync(x => x.PersonId == personId);

        if(result != null)
        {
            var contact = new Contact
            {
                PersonId = result.PersonId,
                FirstName = result.FirstName,
                LastName = result.LastName,
                Age = result.Age,
                City = result.ContactAddress.City,
                StreetName = result.ContactAddress.StreetName,
                PostalCode = result.ContactAddress.PostalCode,
                Email = result.ContactInformation.Email,
                PhoneNumber = result.ContactInformation.PhoneNumber,
                EducationName = result.Education.EducationName,
                InstitutionName = result.Education.InstitutionName,
                CompanyName = result.WorkPlace.CompanyName,
                Title = result.WorkPlace.Title,

            };
            return contact;
        }
        else
        { 
            return null!; 
        
        }

    }

    public async Task<bool> UpdateContacts(Contact contact)
    {

        var workPlaceResult = await CreateWorkPlaceAsync(contact);

        var educationResult = await CreateEducationAsync(contact);

        var addressResult = await CreateContactAddressAsync(contact);

        var newContact = new ContactEntity
        {
            PersonId = contact.PersonId,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Age = contact.Age,
            ContactAddressId = addressResult.Id,
            EducationId = educationResult.Id,
            WorkPlaceId = workPlaceResult.Id
        };

        var newInfo = new ContactInformationEntity
        {
            ContactId = contact.PersonId,
            Email = contact.Email,
            PhoneNumber =   contact.PhoneNumber
        };

        var contactResult = await _contactRepository.UpdateAsync(x => x.PersonId == contact.PersonId, newContact);

        var informationResult = await _informationRepository.UpdateAsync(x => x.ContactId == contact.PersonId, newInfo);

        if (contactResult != null && informationResult != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> ContactExistsPersonId(Contact contact)
    {
        var result = await _contactRepository.ExistsAsync(x => x.PersonId == contact.PersonId);

        if(result)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public async Task<bool> DeleteContact(Contact contact)
    {
        var contactResult = await _contactRepository.DeleteAsync(x => x.PersonId == contact.PersonId);

        if(contactResult)
        {
            return true;
        }
        return false;

    }


}

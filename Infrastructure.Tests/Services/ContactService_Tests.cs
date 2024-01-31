
using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Tests.Services;

public class ContactService_Tests
{
    private readonly DataContext _context = new(new DbContextOptionsBuilder<DataContext>()

    .UseInMemoryDatabase($"{Guid.NewGuid()}")
    .Options);



    [Fact]

    public async Task CreateContactAsync_ShouldCreate_One_ContactAnd_Return_True()
    {
        // Arrange
        var contact = new Contact
        {
            PersonId = "test",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            StreetName = "Test",
            City = "Test",
            PostalCode = 111,
            EducationName = "Test",
            InstitutionName = "Test",
            Email = "Test",
            PhoneNumber = "Test",
            CompanyName = "Test",
            Title = "Test",
        };

        var addressRepo = new ContactAddressRepository(_context);
        var informationRepo = new ContactInformationRepository(_context);
        var contactRepo = new ContactRepository(_context);
        var educationRepo = new EducationRepository(_context);
        var workRepo = new WorkPlaceRepository(_context);

        var contactService = new ContactService(contactRepo, addressRepo, informationRepo, educationRepo, workRepo);

        // Act
        var result = await contactService.CreateContactAsync(contact);


        //Assert
        Assert.True(result);


    }

    [Fact]

    public async Task CreateContactInformationAsync_ShouldAdd_One_InformationEntity_ToDB_AndReturnTrue()
    {
        // Arrange
        var contact = new Contact
        {
            PersonId = "test",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            StreetName = "Test",
            City = "Test",
            PostalCode = 111,
            EducationName = "Test",
            InstitutionName = "Test",
            Email = "Test",
            PhoneNumber = "Test",
            CompanyName = "Test",
            Title = "Test",
        };

        var addressRepo = new ContactAddressRepository(_context);
        var informationRepo = new ContactInformationRepository(_context);
        var contactRepo = new ContactRepository(_context);
        var educationRepo = new EducationRepository(_context);
        var workRepo = new WorkPlaceRepository(_context);

        var contactService = new ContactService(contactRepo, addressRepo, informationRepo, educationRepo, workRepo);

        // Act
        var result = await contactService.CreateContactInformationAsync(contact);


        //Assert
        Assert.True(result);
    }

    [Fact]

    public async Task CreateWorkPlaceAsync_ShouldAdd_One_WorkPlaceEntity_ToDB_AndReturnEntity()
    {
        // Arrange
        var contact = new Contact
        {
            PersonId = "test",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            StreetName = "Test",
            City = "Test",
            PostalCode = 111,
            EducationName = "Test",
            InstitutionName = "Test",
            Email = "Test",
            PhoneNumber = "Test",
            CompanyName = "Test",
            Title = "Test",
        };

        var addressRepo = new ContactAddressRepository(_context);
        var informationRepo = new ContactInformationRepository(_context);
        var contactRepo = new ContactRepository(_context);
        var educationRepo = new EducationRepository(_context);
        var workRepo = new WorkPlaceRepository(_context);

        var contactService = new ContactService(contactRepo, addressRepo, informationRepo, educationRepo, workRepo);

        // Act
        var result = await contactService.CreateWorkPlaceAsync(contact);


        //Assert
        Assert.NotNull(result);
    }

    [Fact]

    public async Task CreateEducationAsync_ShouldAdd_One_EducationEntity_ToDB_AndReturnEntity()
    {
        // Arrange
        var contact = new Contact
        {
            PersonId = "test",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            StreetName = "Test",
            City = "Test",
            PostalCode = 111,
            EducationName = "Test",
            InstitutionName = "Test",
            Email = "Test",
            PhoneNumber = "Test",
            CompanyName = "Test",
            Title = "Test",
        };

        var addressRepo = new ContactAddressRepository(_context);
        var informationRepo = new ContactInformationRepository(_context);
        var contactRepo = new ContactRepository(_context);
        var educationRepo = new EducationRepository(_context);
        var workRepo = new WorkPlaceRepository(_context);

        var contactService = new ContactService(contactRepo, addressRepo, informationRepo, educationRepo, workRepo);

        // Act
        var result = await contactService.CreateEducationAsync(contact);


        //Assert
        Assert.NotNull(result);

    }
    [Fact]

    public async Task CreateContactAddressAsync_ShouldAdd_One_AddressEntity_ToDB_AndReturnEntity ()
    {
        // Arrange
        var contact = new Contact
        {
            PersonId = "test",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            StreetName = "Test",
            City = "Test",
            PostalCode = 111,
            EducationName = "Test",
            InstitutionName = "Test",
            Email = "Test",
            PhoneNumber = "Test",
            CompanyName = "Test",
            Title = "Test",
        };

        var addressRepo = new ContactAddressRepository(_context);
        var informationRepo = new ContactInformationRepository(_context);
        var contactRepo = new ContactRepository(_context);
        var educationRepo = new EducationRepository(_context);
        var workRepo = new WorkPlaceRepository(_context);

        var contactService = new ContactService(contactRepo, addressRepo, informationRepo, educationRepo, workRepo);

        // Act
        var result = await contactService.CreateContactAddressAsync(contact);


        //Assert
        Assert.NotNull(result);
    }

    [Fact]

    public async Task GetAllContacts_ShouldGet_AllEntites_AndReturnList_OfTypeContact()
    {
        // Arrange
        var contact = new Contact
        {
            PersonId = "test",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            StreetName = "Test",
            City = "Test",
            PostalCode = 111,
            EducationName = "Test",
            InstitutionName = "Test",
            Email = "Test",
            PhoneNumber = "Test",
            CompanyName = "Test",
            Title = "Test",
        };

        var addressRepo = new ContactAddressRepository(_context);
        var informationRepo = new ContactInformationRepository(_context);
        var contactRepo = new ContactRepository(_context);
        var educationRepo = new EducationRepository(_context);
        var workRepo = new WorkPlaceRepository(_context);

        var contactService = new ContactService(contactRepo, addressRepo, informationRepo, educationRepo, workRepo);

        // Act
        await contactService.CreateContactAsync(contact);

        var result = contactService.GetAllContactsAsync();


        //Assert
        Assert.NotNull(result);
    }

    [Fact] 

    public async Task GetOneAsync_ShouldReturn_OneContact()
    {
        // Arrange
        var contact = new Contact
        {
            PersonId = "test",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            StreetName = "Test",
            City = "Test",
            PostalCode = 111,
            EducationName = "Test",
            InstitutionName = "Test",
            Email = "Test",
            PhoneNumber = "Test",
            CompanyName = "Test",
            Title = "Test",
        };

        var addressRepo = new ContactAddressRepository(_context);
        var informationRepo = new ContactInformationRepository(_context);
        var contactRepo = new ContactRepository(_context);
        var educationRepo = new EducationRepository(_context);
        var workRepo = new WorkPlaceRepository(_context);

        var contactService = new ContactService(contactRepo, addressRepo, informationRepo, educationRepo, workRepo);

        // Act
        await contactService.CreateContactAsync(contact);

        var result = contactService.GetOneAsync(contact.PersonId);


        //Assert
        Assert.NotNull(result);
    }

    [Fact]

    public async Task UpdateContacts_ShouldUpdate_AllTables_AndReturn_True()
    {
        // Arrange
        var contact = new Contact
        {
            PersonId = "test",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            StreetName = "Test",
            City = "Test",
            PostalCode = 111,
            EducationName = "Test",
            InstitutionName = "Test",
            Email = "Test",
            PhoneNumber = "Test",
            CompanyName = "Test",
            Title = "Test",
        };

        var newContact = new Contact
        {
            PersonId = "test",
            FirstName = "test2",
            LastName = "test2",
            Age = 2,
            StreetName = "test2",
            City = "test2",
            PostalCode = 222,
            EducationName = "test2",
            InstitutionName = "test2",
            Email = "test2",
            PhoneNumber = "test2",
            CompanyName = "test2",
            Title = "test2",
        };

        var addressRepo = new ContactAddressRepository(_context);
        var informationRepo = new ContactInformationRepository(_context);
        var contactRepo = new ContactRepository(_context);
        var educationRepo = new EducationRepository(_context);
        var workRepo = new WorkPlaceRepository(_context);

        var contactService = new ContactService(contactRepo, addressRepo, informationRepo, educationRepo, workRepo);

        // Act
        await contactService.CreateContactAsync(contact);

        var result = await contactService.UpdateContactsAsync(newContact);


        //Assert
        Assert.True(result);
    }

    [Fact]

    public async Task ContactExistsPersonId_ShouldCheck_If_AContactEntity_ExistsWithThe_SamePersonId_AndReturnTrue()
    {
        // Arrange
        var contact = new Contact
        {
            PersonId = "test",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            StreetName = "Test",
            City = "Test",
            PostalCode = 111,
            EducationName = "Test",
            InstitutionName = "Test",
            Email = "Test",
            PhoneNumber = "Test",
            CompanyName = "Test",
            Title = "Test",
        };

        var addressRepo = new ContactAddressRepository(_context);
        var informationRepo = new ContactInformationRepository(_context);
        var contactRepo = new ContactRepository(_context);
        var educationRepo = new EducationRepository(_context);
        var workRepo = new WorkPlaceRepository(_context);

        var contactService = new ContactService(contactRepo, addressRepo, informationRepo, educationRepo, workRepo);

        // Act
        await contactService.CreateContactAsync(contact);

        var result = await contactService.ContactExistsPersonIdAsync(contact);


        //Assert
        Assert.True(result);
    }

    [Fact]

    public async Task DeleteContact_ShouldDelete_ContactAndInformationEntity_WithSamePersonId_AndReturnTrue()
    {
        // Arrange
        var contact = new Contact
        {
            PersonId = "test",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            StreetName = "Test",
            City = "Test",
            PostalCode = 111,
            EducationName = "Test",
            InstitutionName = "Test",
            Email = "Test",
            PhoneNumber = "Test",
            CompanyName = "Test",
            Title = "Test",
        };

        var addressRepo = new ContactAddressRepository(_context);
        var informationRepo = new ContactInformationRepository(_context);
        var contactRepo = new ContactRepository(_context);
        var educationRepo = new EducationRepository(_context);
        var workRepo = new WorkPlaceRepository(_context);

        var contactService = new ContactService(contactRepo, addressRepo, informationRepo, educationRepo, workRepo);

        // Act
        await contactService.CreateContactAsync(contact);

        var result = await contactService.DeleteContactAsync(contact);


        //Assert
        Assert.True(result);

    }
}

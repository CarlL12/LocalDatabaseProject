

using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace Infrastructure.Tests.Repositories;

public  class ContactRepository_Tests
{
    private readonly DataContext _context = new(new DbContextOptionsBuilder<DataContext>()

    .UseInMemoryDatabase($"{Guid.NewGuid()}")
    .Options);


    [Fact]

    public async Task AddAsync_Should_Add_One_ContactEntity_To_Database_And_Return_Entity()
    {
        // Arrange

        var addressEntity = new ContactAddressEntity
        {
            PostalCode = 44443,
            StreetName = "Holmen 1",
            City = "Stockholm"
        };

        var educationEntity = new EducationEntity
        {
            InstitutionName = "Test",
            EducationName = "Test",
        };

        var wpEntity = new WorkPlaceEntity
        {
            CompanyName = "Test",
            Title = "Test",
        };

        var edRepo = new EducationRepository(_context);

        var addressRepo = new ContactAddressRepository(_context);

        var wpRepo = new WorkPlaceRepository(_context);

        var contactRepo = new ContactRepository(_context);

        // Act

        var addressResult = await addressRepo.AddAsync(addressEntity);

        var edResult = await edRepo.AddAsync(educationEntity);

        var wpResult = await wpRepo.AddAsync(wpEntity);

        var contactEntity = new ContactEntity
        {
            PersonId = "01",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            ContactAddressId = addressEntity.Id,
            EducationId = edResult.Id,
            WorkPlaceId = wpResult.Id,
        };

        var result = await contactRepo.AddAsync(contactEntity);

        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task GetWithAllAsync_ShouldGet_All_EntitesFrom_DB()
    {
        var addressEntity = new ContactAddressEntity
        {
            PostalCode = 44443,
            StreetName = "Holmen 1",
            City = "Stockholm"
        };

        var educationEntity = new EducationEntity
        {
            InstitutionName = "Test",
            EducationName = "Test",
        };

        var wpEntity = new WorkPlaceEntity
        {
            CompanyName = "Test",
            Title = "Test",
        };

        var edRepo = new EducationRepository(_context);

        var addressRepo = new ContactAddressRepository(_context);

        var wpRepo = new WorkPlaceRepository(_context);

        var contactRepo = new ContactRepository(_context);

        // Act

        var addressResult = await addressRepo.AddAsync(addressEntity);

        var edResult = await edRepo.AddAsync(educationEntity);

        var wpResult = await wpRepo.AddAsync(wpEntity);

        var contactEntity = new ContactEntity
        {
            PersonId = "01",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            ContactAddressId = addressEntity.Id,
            EducationId = edResult.Id,
            WorkPlaceId = wpResult.Id,
        };

        await contactRepo.AddAsync(contactEntity);

        var result = await contactRepo.GetWithAllAsync();

        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task GetOneWithAll_ShouldGet_One_ContactWith_AllEntites()
    {
        var addressEntity = new ContactAddressEntity
        {
            PostalCode = 44443,
            StreetName = "Holmen 1",
            City = "Stockholm"
        };

        var educationEntity = new EducationEntity
        {
            InstitutionName = "Test",
            EducationName = "Test",
        };

        var wpEntity = new WorkPlaceEntity
        {
            CompanyName = "Test",
            Title = "Test",
        };

        var edRepo = new EducationRepository(_context);

        var addressRepo = new ContactAddressRepository(_context);

        var wpRepo = new WorkPlaceRepository(_context);

        var contactRepo = new ContactRepository(_context);

        var infoRepo = new ContactInformationRepository(_context);



        // Act

        var addressResult = await addressRepo.AddAsync(addressEntity);

        var edResult = await edRepo.AddAsync(educationEntity);

        var wpResult = await wpRepo.AddAsync(wpEntity);



        var contactEntity = new ContactEntity
        {
            PersonId = "01",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            ContactAddressId = addressEntity.Id,
            EducationId = edResult.Id,
            WorkPlaceId = wpResult.Id,
        };

        var infoEntity = new ContactInformationEntity
        {
            ContactId = contactEntity.PersonId,
            Email = "test",
            PhoneNumber = "123"
        };


        await contactRepo.AddAsync(contactEntity);

        await infoRepo.AddAsync(infoEntity);

        var result = await contactRepo.GetOneWithAllAsync(x => x.PersonId == contactEntity.PersonId);

        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task DeleteAsync_ShouldDeleteEntity_And_Return_True()
    {
        // Arrange


        var addressEntity = new ContactAddressEntity
        {
            PostalCode = 44443,
            StreetName = "Holmen 1",
            City = "Stockholm"
        };

        var educationEntity = new EducationEntity
        {
            InstitutionName = "Test",
            EducationName = "Test",
        };

        var wpEntity = new WorkPlaceEntity
        {
            CompanyName = "Test",
            Title = "Test",
        };

        var edRepo = new EducationRepository(_context);

        var addressRepo = new ContactAddressRepository(_context);

        var wpRepo = new WorkPlaceRepository(_context);

        var contactRepo = new ContactRepository(_context);

        // Act

        var addressResult = await addressRepo.AddAsync(addressEntity);

        var edResult = await edRepo.AddAsync(educationEntity);

        var wpResult = await wpRepo.AddAsync(wpEntity);

        var contactEntity = new ContactEntity
        {
            PersonId = "01",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            ContactAddressId = addressEntity.Id,
            EducationId = edResult.Id,
            WorkPlaceId = wpResult.Id,
        };

        await contactRepo.AddAsync(contactEntity);

        var result = await contactRepo.DeleteAsync(x => x.PersonId == contactEntity.PersonId);



        // Assert
        Assert.True(result);

    }

    [Fact]

    public async Task ExistsAsync_ShouldCheck_If_EntityExists_And_ReturnTrue()
    {
        // Arrange

        var addressEntity = new ContactAddressEntity
        {
            PostalCode = 44443,
            StreetName = "Holmen 1",
            City = "Stockholm"
        };

        var educationEntity = new EducationEntity
        {
            InstitutionName = "Test",
            EducationName = "Test",
        };

        var wpEntity = new WorkPlaceEntity
        {
            CompanyName = "Test",
            Title = "Test",
        };

        var edRepo = new EducationRepository(_context);

        var addressRepo = new ContactAddressRepository(_context);

        var wpRepo = new WorkPlaceRepository(_context);

        var contactRepo = new ContactRepository(_context);

        // Act

        var addressResult = await addressRepo.AddAsync(addressEntity);

        var edResult = await edRepo.AddAsync(educationEntity);

        var wpResult = await wpRepo.AddAsync(wpEntity);

        var contactEntity = new ContactEntity
        {
            PersonId = "01",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            ContactAddressId = addressEntity.Id,
            EducationId = edResult.Id,
            WorkPlaceId = wpResult.Id,
        };

        await contactRepo.AddAsync(contactEntity);

        var result = await contactRepo.ExistsAsync(x => x.PersonId == contactEntity.PersonId);



        // Assert
        Assert.True(result);

    }

    [Fact]

    public async Task GetAllAsync_ShouldGetAll_From_DB_And_ReturnList()
    {
        // Arrange

        var addressEntity = new ContactAddressEntity
        {
            PostalCode = 44443,
            StreetName = "Holmen 1",
            City = "Stockholm"
        };

        var educationEntity = new EducationEntity
        {
            InstitutionName = "Test",
            EducationName = "Test",
        };

        var wpEntity = new WorkPlaceEntity
        {
            CompanyName = "Test",
            Title = "Test",
        };

        var edRepo = new EducationRepository(_context);

        var addressRepo = new ContactAddressRepository(_context);

        var wpRepo = new WorkPlaceRepository(_context);

        var contactRepo = new ContactRepository(_context);

        // Act

        var addressResult = await addressRepo.AddAsync(addressEntity);

        var edResult = await edRepo.AddAsync(educationEntity);

        var wpResult = await wpRepo.AddAsync(wpEntity);

        var contactEntity = new ContactEntity
        {
            PersonId = "01",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            ContactAddressId = addressEntity.Id,
            EducationId = edResult.Id,
            WorkPlaceId = wpResult.Id,
        };

        await contactRepo.AddAsync(contactEntity);

        var result = await contactRepo.GetAllAsync();



        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task GetOneAsync_ShouldGetOne_From_DB_And_ReturnEntity()
    {
        // Arrange

        var addressEntity = new ContactAddressEntity
        {
            PostalCode = 44443,
            StreetName = "Holmen 1",
            City = "Stockholm"
        };

        var educationEntity = new EducationEntity
        {
            InstitutionName = "Test",
            EducationName = "Test",
        };

        var wpEntity = new WorkPlaceEntity
        {
            CompanyName = "Test",
            Title = "Test",
        };

        var edRepo = new EducationRepository(_context);

        var addressRepo = new ContactAddressRepository(_context);

        var wpRepo = new WorkPlaceRepository(_context);

        var contactRepo = new ContactRepository(_context);

        // Act

        var addressResult = await addressRepo.AddAsync(addressEntity);

        var edResult = await edRepo.AddAsync(educationEntity);

        var wpResult = await wpRepo.AddAsync(wpEntity);

        var contactEntity = new ContactEntity
        {
            PersonId = "01",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            ContactAddressId = addressEntity.Id,
            EducationId = edResult.Id,
            WorkPlaceId = wpResult.Id,
        };

        await contactRepo.AddAsync(contactEntity);

        var result = await contactRepo.GetOneAsync(x => x.PersonId == contactEntity.PersonId);



        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task UpdateAsync_ShouldUpdateEntity_And_ReturnEntity()
    {
        // Arrange

        var addressEntity = new ContactAddressEntity
        {
            PostalCode = 44443,
            StreetName = "Holmen 1",
            City = "Stockholm"
        };

        var educationEntity = new EducationEntity
        {
            InstitutionName = "Test",
            EducationName = "Test",
        };

        var wpEntity = new WorkPlaceEntity
        {
            CompanyName = "Test",
            Title = "Test",
        };

        var edRepo = new EducationRepository(_context);

        var addressRepo = new ContactAddressRepository(_context);

        var wpRepo = new WorkPlaceRepository(_context);

        var contactRepo = new ContactRepository(_context);

        // Act

        var addressResult = await addressRepo.AddAsync(addressEntity);

        var edResult = await edRepo.AddAsync(educationEntity);

        var wpResult = await wpRepo.AddAsync(wpEntity);

        var contactEntity = new ContactEntity
        {
            PersonId = "01",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            ContactAddressId = addressEntity.Id,
            EducationId = edResult.Id,
            WorkPlaceId = wpResult.Id,
        };

        await contactRepo.AddAsync(contactEntity);

        var newEntity = new ContactEntity
        {
            PersonId = "01",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
            ContactAddressId = addressEntity.Id,
            EducationId = edResult.Id,
            WorkPlaceId = wpResult.Id,
        };

        var result = await contactRepo.UpdateAsync(x => x.PersonId == contactEntity.PersonId, newEntity);



        // Assert
        Assert.NotNull(result);

    }
}

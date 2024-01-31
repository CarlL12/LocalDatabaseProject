
using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tests.Repositories;

public  class ContactInformationRepository_Tests
{
    private readonly DataContext _context = new(new DbContextOptionsBuilder<DataContext>()

    .UseInMemoryDatabase($"{Guid.NewGuid()}")
    .Options);


    [Fact]

    public async Task AddAsync_Should_Add_One_InformationEntity_To_Database_And_Return_Entity()
    {
        // Arrange

        var contactEntity = new ContactEntity
        {
            PersonId = "01",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
        };



        var infoRepo = new ContactInformationRepository(_context);

        var contactRepo = new ContactRepository(_context);

        // Act

        var contactResult = contactRepo.AddAsync(contactEntity);

        var informationEntity = new ContactInformationEntity
        {
            ContactId = contactEntity.PersonId,
            Email = "carl@domain.com",
            PhoneNumber = "1234567890",
        };

        var result = await infoRepo.AddAsync(informationEntity);

        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task DeleteAsync_ShouldDeleteEntity_And_Return_True()
    {
        // Arrange

        var contactEntity = new ContactEntity
        {
            PersonId = "01",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
        };

        var informationEntity = new ContactInformationEntity
        {
            ContactId = contactEntity.PersonId,
            Email = "carl@domain.com",
            PhoneNumber = "1234567890",
        };

        var infoRepo = new ContactInformationRepository(_context);

        var contactRepo = new ContactRepository(_context);

        // Act

        await contactRepo.AddAsync(contactEntity);

        await infoRepo.AddAsync(informationEntity);

        var result = await infoRepo.DeleteAsync(x => x.Email == informationEntity.Email);



        // Assert
        Assert.True(result);

    }

    [Fact]

    public async Task ExistsAsync_ShouldCheck_If_EntityExists_And_ReturnTrue()
    {
        // Arrange

        var contactEntity = new ContactEntity
        {
            PersonId = "01",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
        };

        var informationEntity = new ContactInformationEntity
        {
            ContactId = contactEntity.PersonId,
            Email = "carl@domain.com",
            PhoneNumber = "1234567890",
        };

        var infoRepo = new ContactInformationRepository(_context);

        var contactRepo = new ContactRepository(_context);

        // Act

        await contactRepo.AddAsync(contactEntity);

        await infoRepo.AddAsync(informationEntity);

        var result = await infoRepo.ExistsAsync(x => x.Email == informationEntity.Email);



        // Assert
        Assert.True(result);

    }

    [Fact]

    public async Task GetAllAsync_ShouldGetAll_From_DB_And_ReturnList()
    {
        // Arrange

        var contactEntity = new ContactEntity
        {
            PersonId = "01",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
        };

        var informationEntity = new ContactInformationEntity
        {
            ContactId = contactEntity.PersonId,
            Email = "carl@domain.com",
            PhoneNumber = "1234567890",
        };

        var infoRepo = new ContactInformationRepository(_context);

        var contactRepo = new ContactRepository(_context);

        // Act

        await contactRepo.AddAsync(contactEntity);

        await infoRepo.AddAsync(informationEntity);

        var result = await infoRepo.GetAllAsync();



        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task GetOneAsync_ShouldGetOne_From_DB_And_ReturnEntity()
    {
        // Arrange

        var contactEntity = new ContactEntity
        {
            PersonId = "01",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
        };

        var informationEntity = new ContactInformationEntity
        {
            ContactId = contactEntity.PersonId,
            Email = "carl@domain.com",
            PhoneNumber = "1234567890",
        };

        var infoRepo = new ContactInformationRepository(_context);

        var contactRepo = new ContactRepository(_context);

        // Act

        await contactRepo.AddAsync(contactEntity);

        await infoRepo.AddAsync(informationEntity);

        var result = await infoRepo.GetOneAsync(x => x.Email == informationEntity.Email);



        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task UpdateAsync_ShouldUpdateEntity_And_ReturnEntity()
    {
        // Arrange

        var contactEntity = new ContactEntity
        {
            PersonId = "01",
            FirstName = "Test",
            LastName = "Test",
            Age = 1,
        };

        var informationEntity = new ContactInformationEntity
        {
            ContactId = contactEntity.PersonId,
            Email = "carl@domain.com",
            PhoneNumber = "1234567890",
        };

        var infoRepo = new ContactInformationRepository(_context);

        var contactRepo = new ContactRepository(_context);

        // Act

        await contactRepo.AddAsync(contactEntity);

        await infoRepo.AddAsync(informationEntity);

        var newEntity = new ContactInformationEntity
        {
            ContactId = contactEntity.PersonId,
            Email = "hej@domain.com",
            PhoneNumber = "32323232",
        };

        var result = await infoRepo.UpdateAsync(x => x.Email == informationEntity.Email, newEntity);



        // Assert
        Assert.NotNull(result);

    }
}

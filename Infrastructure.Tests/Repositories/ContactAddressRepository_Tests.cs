
using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tests.Repositories;

public  class ContactAddressRepository_Tests
{

    private readonly DataContext _context = new(new DbContextOptionsBuilder<DataContext>()

    .UseInMemoryDatabase($"{Guid.NewGuid()}")
    .Options);


    [Fact]

    public async Task AddAsync_Should_Add_One_AddressEntity_To_Database_And_Return_Entity()
    {
        // Arrange

        var addressEntity = new ContactAddressEntity
        {
            PostalCode = 44443,
            StreetName = "Holmen 1",
            City = "Stockholm"
        };

        var addressRepo = new ContactAddressRepository(_context);

        // Act

        var result = await addressRepo.AddAsync(addressEntity);

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

        var addressRepo = new ContactAddressRepository(_context);

        // Act

        await addressRepo.AddAsync(addressEntity);

        var result = await addressRepo.DeleteAsync(x => x.City == addressEntity.City);



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

        var addressRepo = new ContactAddressRepository(_context);

        // Act

        await addressRepo.AddAsync(addressEntity);

        var result = await addressRepo.ExistsAsync(x => x.StreetName == addressEntity.StreetName);
       


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
        var addressRepo = new ContactAddressRepository(_context);

        // Act

        await addressRepo.AddAsync(addressEntity);

        var result = await addressRepo.GetAllAsync();



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

        var addressRepo = new ContactAddressRepository(_context);

        // Act

        await addressRepo.AddAsync(addressEntity);

        var result = await addressRepo.GetOneAsync(x => x.PostalCode == addressEntity.PostalCode);



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



        var addressRepo = new ContactAddressRepository(_context);

        // Act

       var addResult = await addressRepo.AddAsync(addressEntity);

        var newEntity = new ContactAddressEntity
        {
            Id = addResult.Id,
            PostalCode = 44441,
            StreetName = "Holmen 2",
            City = "Göteborg"
        };

        var result = await addressRepo.UpdateAsync(x => x.City == addressEntity.City, newEntity);



        // Assert
        Assert.NotNull(result);

    }
}

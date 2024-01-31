

using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tests.Repositories;

public  class ManufactureRepository_Tests
{
    private readonly ProductContext _context = new(new DbContextOptionsBuilder<ProductContext>()

    .UseInMemoryDatabase($"{Guid.NewGuid()}")
    .Options);


    [Fact]

    public async Task AddAsync_Should_Add_One_ManufactureEntity_To_Database_And_Return_Entity()
    {
        // Arrange

        var manufactureEntity = new ManufactureEntity
        {
            Manufacture = "Test",
        };

        var manuRepo = new ManufactureRepository(_context);

        // Act

        var result = await manuRepo.AddAsync(manufactureEntity);

        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task DeleteAsync_ShouldDeleteEntity_And_Return_True()
    {
        // Arrange


        var manufactureEntity = new ManufactureEntity
        {
            Manufacture = "Test",
        };

        var manuRepo = new ManufactureRepository(_context);

        // Act

        await manuRepo.AddAsync(manufactureEntity);

        var result = await manuRepo.DeleteAsync(x => x.Manufacture == manufactureEntity.Manufacture);



        // Assert
        Assert.True(result);

    }

    [Fact]

    public async Task ExistsAsync_ShouldCheck_If_EntityExists_And_ReturnTrue()
    {
        // Arrange


        var manufactureEntity = new ManufactureEntity
        {
            Manufacture = "Test",
        };

        var manuRepo = new ManufactureRepository(_context);

        // Act

        await manuRepo.AddAsync(manufactureEntity);

        var result = await manuRepo.ExistsAsync(x => x.Manufacture == manufactureEntity.Manufacture);



        // Assert
        Assert.True(result);

    }

    [Fact]

    public async Task GetAllAsync_ShouldGetAll_From_DB_And_ReturnList()
    {
        // Arrange


        var manufactureEntity = new ManufactureEntity
        {
            Manufacture = "Test",
        };

        var manuRepo = new ManufactureRepository(_context);

        // Act

        await manuRepo.AddAsync(manufactureEntity);

        var result = await manuRepo.GetAllAsync();



        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task GetOneAsync_ShouldGetOne_From_DB_And_ReturnEntity()
    {
        // Arrange


        var manufactureEntity = new ManufactureEntity
        {
            Manufacture = "Test",
        };

        var manuRepo = new ManufactureRepository(_context);

        // Act

        await manuRepo.AddAsync(manufactureEntity);

        var result = await manuRepo.GetOneAsync(x => x.Manufacture == manufactureEntity.Manufacture);



        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task UpdateAsync_ShouldUpdateEntity_And_ReturnEntity()
    {
        // Arrange


        var manufactureEntity = new ManufactureEntity
        {
            Manufacture = "Test",
        };

        var manuRepo = new ManufactureRepository(_context);

        // Act

        var addResult = await manuRepo.AddAsync(manufactureEntity);

        var newEntity = new ManufactureEntity
        {
            Id = addResult.Id,
            Manufacture = "Test2"
        };

        var result = await manuRepo.UpdateAsync(x => x.Manufacture == manufactureEntity.Manufacture, newEntity);



        // Assert
        Assert.NotNull(result);

    }
}

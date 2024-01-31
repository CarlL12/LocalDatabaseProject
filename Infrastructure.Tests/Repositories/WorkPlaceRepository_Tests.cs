

using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tests.Repositories;

public  class WorkPlaceRepository_Tests
{
    private readonly DataContext _context = new(new DbContextOptionsBuilder<DataContext>()

    .UseInMemoryDatabase($"{Guid.NewGuid()}")
    .Options);


    [Fact]

    public async Task AddAsync_Should_Add_One_WorkPlaceEntity_To_Database_And_Return_Entity()
    {
        // Arrange

        var wpEntity = new WorkPlaceEntity
        {
            CompanyName = "Test",
            Title = "Test",
        };

        var wpRepo = new WorkPlaceRepository(_context);

        // Act

        var result = await wpRepo.AddAsync(wpEntity);

        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task DeleteAsync_ShouldDeleteEntity_And_Return_True()
    {
        // Arrange


        var wpEntity = new WorkPlaceEntity
        {
            CompanyName = "Test",
            Title = "Test",
        };

        var wpRepo = new WorkPlaceRepository(_context);

        // Act

        await wpRepo.AddAsync(wpEntity);

        var result = await wpRepo.DeleteAsync(x => x.CompanyName == wpEntity.CompanyName);



        // Assert
        Assert.True(result);

    }

    [Fact]

    public async Task ExistsAsync_ShouldCheck_If_EntityExists_And_ReturnTrue()
    {
        // Arrange

        var wpEntity = new WorkPlaceEntity
        {
            CompanyName = "Test",
            Title = "Test",
        };

        var wpRepo = new WorkPlaceRepository(_context);

        // Act

        await wpRepo.AddAsync(wpEntity);

        var result = await wpRepo.ExistsAsync(x => x.CompanyName == wpEntity.CompanyName);



        // Assert
        Assert.True(result);

    }

    [Fact]

    public async Task GetAllAsync_ShouldGetAll_From_DB_And_ReturnList()
    {
        // Arrange

        var wpEntity = new WorkPlaceEntity
        {
            CompanyName = "Test",
            Title = "Test",
        };

        var wpRepo = new WorkPlaceRepository(_context);

        // Act

        await wpRepo.AddAsync(wpEntity);

        var result = await wpRepo.GetAllAsync();



        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task GetOneAsync_ShouldGetOne_From_DB_And_ReturnEntity()
    {
        // Arrange

        var wpEntity = new WorkPlaceEntity
        {
            CompanyName = "Test",
            Title = "Test",
        };

        var wpRepo = new WorkPlaceRepository(_context);

        // Act

        await wpRepo.AddAsync(wpEntity);

        var result = await wpRepo.GetOneAsync(x => x.CompanyName == wpEntity.CompanyName);



        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task UpdateAsync_ShouldUpdateEntity_And_ReturnEntity()
    {
        // Arrange

        var wpEntity = new WorkPlaceEntity
        {
            CompanyName = "Test",
            Title = "Test",
        };

        var wpRepo = new WorkPlaceRepository(_context);

        // Act

        var addResult = await wpRepo.AddAsync(wpEntity);

        var newEntity = new WorkPlaceEntity
        {
            Id = addResult.Id,
            CompanyName = "Test2",
            Title = "Test2",
        };

        var result = await wpRepo.UpdateAsync(x => x.CompanyName == wpEntity.CompanyName, newEntity);



        // Assert
        Assert.NotNull(result);

    }
}

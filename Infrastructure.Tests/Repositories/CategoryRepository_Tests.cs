
using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tests.Repositories;

public  class CategoryRepository_Tests
{
    private readonly ProductContext _context = new(new DbContextOptionsBuilder<ProductContext>()
        
        .UseInMemoryDatabase($"{Guid.NewGuid()}")
        .Options);


    [Fact]

    public async Task AddAsync_Should_Add_One_CategoryEntity_To_Database_And_Return_Entity()
    {
        // Arrange

        var categoryEntity = new CategoryEntity
        {
            CategoryName = "Test",
        };

        var categoryRepo = new CategoryRepository(_context);

        // Act

        var result = await categoryRepo.AddAsync(categoryEntity);

        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task DeleteAsync_ShouldDeleteEntity_And_Return_True()
    {
        // Arrange

        var categoryEntity = new CategoryEntity
        {
            CategoryName = "Test",
        };

        var categoryRepo = new CategoryRepository(_context);

        // Act

        await categoryRepo.AddAsync(categoryEntity);

        var result = await categoryRepo.DeleteAsync(x => x.CategoryName == categoryEntity.CategoryName);



        // Assert
        Assert.True(result);

    }

    [Fact]

    public async Task ExistsAsync_ShouldCheck_If_EntityExists_And_ReturnTrue()
    {
        // Arrange

        var categoryEntity = new CategoryEntity
        {
            CategoryName = "Test",
        };

        var categoryRepo = new CategoryRepository(_context);

        // Act

        await categoryRepo.AddAsync(categoryEntity);

        var result = await categoryRepo.ExistsAsync(x => x.CategoryName == categoryEntity.CategoryName);



        // Assert
        Assert.True(result);

    }

    [Fact]

    public async Task GetAllAsync_ShouldGetAll_From_DB_And_ReturnList()
    {
        // Arrange

        var categoryEntity = new CategoryEntity
        {
            CategoryName = "Test",
        };

        var categoryRepo = new CategoryRepository(_context);

        // Act

        await categoryRepo.AddAsync(categoryEntity);

        var result = await categoryRepo.GetAllAsync();



        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task GetOneAsync_ShouldGetOne_From_DB_And_ReturnEntity()
    {
        // Arrange

        var categoryEntity = new CategoryEntity
        {
            CategoryName = "Test",
        };

        var categoryRepo = new CategoryRepository(_context);

        // Act

        await categoryRepo.AddAsync(categoryEntity);

        var result = await categoryRepo.GetOneAsync(x => x.CategoryName == categoryEntity.CategoryName);



        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task UpdateAsync_ShouldUpdateEntity_And_ReturnEntity()
    {
        // Arrange

        var categoryEntity = new CategoryEntity
        {
            CategoryName = "Test",
        };

 

        var categoryRepo = new CategoryRepository(_context);

        // Act

        var addResult = await categoryRepo.AddAsync(categoryEntity);

        var newEntity = new CategoryEntity
        {
            Id = addResult.Id,
            CategoryName = "Test2"
        };

        var result = await categoryRepo.UpdateAsync(x => x.CategoryName == categoryEntity.CategoryName, newEntity);



        // Assert
        Assert.NotNull(result);

    }

}

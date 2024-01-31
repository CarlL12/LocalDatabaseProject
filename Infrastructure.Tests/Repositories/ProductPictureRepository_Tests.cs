

using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tests.Repositories;

public  class ProductPictureRepository_Tests
{
    private readonly ProductContext _context = new(new DbContextOptionsBuilder<ProductContext>()

.UseInMemoryDatabase($"{Guid.NewGuid()}")
.Options);


    [Fact]

    public async Task AddAsync_Should_Add_One_ProductPictureEntity_To_Database_And_Return_Entity()
    {
        // Arrange

        var pictureEntity = new ProductPictureEntity
        {
            Picture = "Test",
        };

        var pictureRepo = new ProductPictureRepository(_context);

        // Act

        var result = await pictureRepo.AddAsync(pictureEntity);

        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task DeleteAsync_ShouldDeleteEntity_And_Return_True()
    {
        // Arrange

        var pictureEntity = new ProductPictureEntity
        {
            Picture = "Test",
        };

        var pictureRepo = new ProductPictureRepository(_context);

        // Act

        await pictureRepo.AddAsync(pictureEntity);

        var result = await pictureRepo.DeleteAsync(x => x.Picture == pictureEntity.Picture);



        // Assert
        Assert.True(result);

    }

    [Fact]

    public async Task ExistsAsync_ShouldCheck_If_EntityExists_And_ReturnTrue()
    {
        // Arrange


        var pictureEntity = new ProductPictureEntity
        {
            Picture = "Test",
        };

        var pictureRepo = new ProductPictureRepository(_context);

        // Act

        await pictureRepo.AddAsync(pictureEntity);

        var result = await pictureRepo.ExistsAsync(x => x.Picture == pictureEntity.Picture);



        // Assert
        Assert.True(result);

    }

    [Fact]

    public async Task GetAllAsync_ShouldGetAll_From_DB_And_ReturnList()
    {
        // Arrange

        var pictureEntity = new ProductPictureEntity
        {
            Picture = "Test",
        };

        var pictureRepo = new ProductPictureRepository(_context);

        // Act

        await pictureRepo.AddAsync(pictureEntity);

        var result = await pictureRepo.GetAllAsync();



        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task GetOneAsync_ShouldGetOne_From_DB_And_ReturnEntity()
    {
        // Arrange


        var pictureEntity = new ProductPictureEntity
        {
            Picture = "Test",
        };

        var pictureRepo = new ProductPictureRepository(_context);

        // Act

        await pictureRepo.AddAsync(pictureEntity);

        var result = await pictureRepo.GetOneAsync(x => x.Picture == pictureEntity.Picture);



        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task UpdateAsync_ShouldUpdateEntity_And_ReturnEntity()
    {
        // Arrange


        var pictureEntity = new ProductPictureEntity
        {
            Picture = "Test",
        };

        var pictureRepo = new ProductPictureRepository(_context);

        // Act

        var addResult = await pictureRepo.AddAsync(pictureEntity);

        var newEntity = new ProductPictureEntity
        {
            Id = addResult.Id,
            Picture = "Test2"
        };

        var result = await pictureRepo.UpdateAsync(x => x.Picture == pictureEntity.Picture, newEntity);



        // Assert
        Assert.NotNull(result);

    }
}



using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tests.Repositories;

public  class PriceRepository_Tests
{
    private readonly ProductContext _context = new(new DbContextOptionsBuilder<ProductContext>()

    .UseInMemoryDatabase($"{Guid.NewGuid()}")
    .Options);


    [Fact]

    public async Task AddAsync_Should_Add_One_PriceEntity_To_Database_And_Return_Entity()
    {
        // Arrange

        var productEntity = new ProductEntity
        {
            ArticleNumber = "123123",
            Title = "asdasd",
            Description = "Test",
        };


        var priceRepo = new PriceRepository(_context);

        var productRepo = new ProductRepository(_context);

        // Act

        var contactResult = productRepo.AddAsync(productEntity);

        var priceEntity = new PriceEntity
        {
            ProductId = productEntity.ArticleNumber,
            ProductPrice = 120,
            SalePrice = 150
        };

        var result = await priceRepo.AddAsync(priceEntity);

        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task DeleteAsync_ShouldDeleteEntity_And_Return_True()
    {
        // Arrange

        var productEntity = new ProductEntity
        {
            ArticleNumber = "123123",
            Title = "asdasd",
            Description = "Test",
        };

        var priceEntity = new PriceEntity
        {
            ProductId = productEntity.ArticleNumber,
            ProductPrice = 120,
            SalePrice = 150
        };

        var priceRepo = new PriceRepository(_context);

        var productRepo = new ProductRepository(_context);

        // Act

        await productRepo.AddAsync(productEntity);

        await priceRepo.AddAsync(priceEntity);

        var result = await priceRepo.DeleteAsync(x => x.ProductId == priceEntity.ProductId);



        // Assert
        Assert.True(result);

    }

    [Fact]

    public async Task ExistsAsync_ShouldCheck_If_EntityExists_And_ReturnTrue()
    {
        // Arrange

        var productEntity = new ProductEntity
        {
            ArticleNumber = "123123",
            Title = "asdasd",
            Description = "Test",
        };

        var priceEntity = new PriceEntity
        {
            ProductId = productEntity.ArticleNumber,
            ProductPrice = 120,
            SalePrice = 150
        };

        var priceRepo = new PriceRepository(_context);

        var productRepo = new ProductRepository(_context);

        // Act

        await productRepo.AddAsync(productEntity);

        await priceRepo.AddAsync(priceEntity);

        var result = await priceRepo.ExistsAsync(x => x.ProductId == priceEntity.ProductId);



        // Assert
        Assert.True(result);

    }

    [Fact]

    public async Task GetAllAsync_ShouldGetAll_From_DB_And_ReturnList()
    {
        // Arrange

        var productEntity = new ProductEntity
        {
            ArticleNumber = "123123",
            Title = "asdasd",
            Description = "Test",
        };

        var priceEntity = new PriceEntity
        {
            ProductId = productEntity.ArticleNumber,
            ProductPrice = 120,
            SalePrice = 150
        };

        var priceRepo = new PriceRepository(_context);

        var productRepo = new ProductRepository(_context);

        // Act

        await productRepo.AddAsync(productEntity);

        await priceRepo.AddAsync(priceEntity);

        var result = await priceRepo.GetAllAsync();



        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task GetOneAsync_ShouldGetOne_From_DB_And_ReturnEntity()
    {
        // Arrange

        var productEntity = new ProductEntity
        {
            ArticleNumber = "123123",
            Title = "asdasd",
            Description = "Test",
        };

        var priceEntity = new PriceEntity
        {
            ProductId = productEntity.ArticleNumber,
            ProductPrice = 120,
            SalePrice = 150
        };

        var priceRepo = new PriceRepository(_context);

        var productRepo = new ProductRepository(_context);

        // Act

        await productRepo.AddAsync(productEntity);

        await priceRepo.AddAsync(priceEntity);

        var result = await priceRepo.GetOneAsync(x => x.ProductId == priceEntity.ProductId);



        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task UpdateAsync_ShouldUpdateEntity_And_ReturnEntity()
    {
        // Arrange

        var productEntity = new ProductEntity
        {
            ArticleNumber = "123123",
            Title = "asdasd",
            Description = "Test",
        };

        var priceEntity = new PriceEntity
        {
            ProductId = productEntity.ArticleNumber,
            ProductPrice = 120,
            SalePrice = 150
        };

        var priceRepo = new PriceRepository(_context);

        var productRepo = new ProductRepository(_context);

        // Act

        await productRepo.AddAsync(productEntity);

        await priceRepo.AddAsync(priceEntity);

        var newEntity = new PriceEntity
        {
            ProductId = productEntity.ArticleNumber,
            ProductPrice = 11,
            SalePrice = 22,
        };

        var result = await priceRepo.UpdateAsync(x => x.ProductId == priceEntity.ProductId, newEntity);



        // Assert
        Assert.NotNull(result);

    }
}

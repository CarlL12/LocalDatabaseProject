

using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tests.Repositories;

public  class ProductRepository_Tests
{
    private readonly ProductContext _context = new(new DbContextOptionsBuilder<ProductContext>()

    .UseInMemoryDatabase($"{Guid.NewGuid()}")
    .Options);


    [Fact]

    public async Task AddAsync_Should_Add_One_ProductEntity_To_Database_And_Return_Entity()
    {
        // Arrange

        var categoryEntity = new CategoryEntity
        {
            CategoryName = "Test"
        };

        var manufactureEntity = new ManufactureEntity
        {
            Manufacture = "Test"
        };

        var pictureEntity = new ProductPictureEntity
        {
            Picture = "Url12"
        };



        var categoryRepo = new CategoryRepository(_context);

        var manufactureRepo = new ManufactureRepository(_context);

        var pictureRepo = new ProductPictureRepository(_context);

        var productRepo = new ProductRepository(_context);

        var priceRepo = new PriceRepository(_context);

        // Act

        var mfResult = manufactureRepo.AddAsync(manufactureEntity);

        var cgResult = categoryRepo.AddAsync(categoryEntity);

        var pResult = pictureRepo.AddAsync(pictureEntity);

        var productEntity = new ProductEntity
        {
            ArticleNumber = "01",
            Title = "Test",
            Description = "Test",
            CategoryId = cgResult.Id,
            ManufactureId = mfResult.Id,
            ProductPictureId = pResult.Id,
        };


        var result = await productRepo.AddAsync(productEntity);

        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task GetWithAllAsync_ShouldGet_All_EntitesFrom_DB()
    {
        // Arrange

        var categoryEntity = new CategoryEntity
        {
            CategoryName = "Test"
        };

        var manufactureEntity = new ManufactureEntity
        {
            Manufacture = "Test"
        };

        var pictureEntity = new ProductPictureEntity
        {
            Picture = "Url12"
        };



        var categoryRepo = new CategoryRepository(_context);

        var manufactureRepo = new ManufactureRepository(_context);

        var pictureRepo = new ProductPictureRepository(_context);

        var productRepo = new ProductRepository(_context);

        var priceRepo = new PriceRepository(_context);

        // Act

        var mfResult = manufactureRepo.AddAsync(manufactureEntity);

        var cgResult = categoryRepo.AddAsync(categoryEntity);

        var pResult = pictureRepo.AddAsync(pictureEntity);

        var productEntity = new ProductEntity
        {
            ArticleNumber = "01",
            Title = "Test",
            Description = "Test",
            CategoryId = cgResult.Id,
            ManufactureId = mfResult.Id,
            ProductPictureId = pResult.Id,
        };


        await productRepo.AddAsync(productEntity);

        var result = productRepo.GetWithAllAsync();

        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task GetOneWithAll_ShouldGet_One_ProductWith_AllEntites()
    {
        // Arrange

        var categoryEntity = new CategoryEntity
        {
            CategoryName = "Test"
        };

        var manufactureEntity = new ManufactureEntity
        {
            Manufacture = "Test"
        };

        var pictureEntity = new ProductPictureEntity
        {
            Picture = "Url12"
        };



        var categoryRepo = new CategoryRepository(_context);

        var manufactureRepo = new ManufactureRepository(_context);

        var pictureRepo = new ProductPictureRepository(_context);

        var productRepo = new ProductRepository(_context);

        var priceRepo = new PriceRepository(_context);

        // Act

        var mfResult = manufactureRepo.AddAsync(manufactureEntity);

        var cgResult = categoryRepo.AddAsync(categoryEntity);

        var pResult = pictureRepo.AddAsync(pictureEntity);

        var productEntity = new ProductEntity
        {
            ArticleNumber = "01",
            Title = "Test",
            Description = "Test",
            CategoryId = cgResult.Id,
            ManufactureId = mfResult.Id,
            ProductPictureId = pResult.Id,
        };


        await productRepo.AddAsync(productEntity);

        var result = productRepo.GetOneWithAllAsync(x => x.ArticleNumber == productEntity.ArticleNumber);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]

    public async Task DeleteAsync_ShouldDeleteEntity_And_Return_True()
    {
        // Arrange


        var categoryEntity = new CategoryEntity
        {
            CategoryName = "Test"
        };

        var manufactureEntity = new ManufactureEntity
        {
            Manufacture = "Test"
        };

        var pictureEntity = new ProductPictureEntity
        {
            Picture = "Url12"
        };

        var categoryRepo = new CategoryRepository(_context);

        var manufactureRepo = new ManufactureRepository(_context);

        var pictureRepo = new ProductPictureRepository(_context);

        var productRepo = new ProductRepository(_context);

        // Act

        var mfResult = manufactureRepo.AddAsync(manufactureEntity);

        var cgResult = categoryRepo.AddAsync(categoryEntity);

        var pResult = pictureRepo.AddAsync(pictureEntity);

        var productEntity = new ProductEntity
        {
            ArticleNumber = "01",
            Title = "Test",
            Description = "Test",
            CategoryId = cgResult.Id,
            ManufactureId = mfResult.Id,
            ProductPictureId = pResult.Id,
        };

        await productRepo.AddAsync(productEntity);

        var result = await productRepo.DeleteAsync(x => x.ArticleNumber == productEntity.ArticleNumber);



        // Assert
        Assert.True(result);

    }

    [Fact]

    public async Task ExistsAsync_ShouldCheck_If_EntityExists_And_ReturnTrue()
    {
        // Arrange

        var categoryEntity = new CategoryEntity
        {
            CategoryName = "Test"
        };

        var manufactureEntity = new ManufactureEntity
        {
            Manufacture = "Test"
        };

        var pictureEntity = new ProductPictureEntity
        {
            Picture = "Url12"
        };

        var categoryRepo = new CategoryRepository(_context);

        var manufactureRepo = new ManufactureRepository(_context);

        var pictureRepo = new ProductPictureRepository(_context);

        var productRepo = new ProductRepository(_context);

        // Act

        var mfResult = manufactureRepo.AddAsync(manufactureEntity);

        var cgResult = categoryRepo.AddAsync(categoryEntity);

        var pResult = pictureRepo.AddAsync(pictureEntity);

        var productEntity = new ProductEntity
        {
            ArticleNumber = "01",
            Title = "Test",
            Description = "Test",
            CategoryId = cgResult.Id,
            ManufactureId = mfResult.Id,
            ProductPictureId = pResult.Id,
        };

        await productRepo.AddAsync(productEntity);

        var result = await productRepo.ExistsAsync(x => x.ArticleNumber == productEntity.ArticleNumber);



        // Assert
        Assert.True(result);

    }

    [Fact]

    public async Task GetAllAsync_ShouldGetAll_From_DB_And_ReturnList()
    {
        // Arrange

        var categoryEntity = new CategoryEntity
        {
            CategoryName = "Test"
        };

        var manufactureEntity = new ManufactureEntity
        {
            Manufacture = "Test"
        };

        var pictureEntity = new ProductPictureEntity
        {
            Picture = "Url12"
        };

        var categoryRepo = new CategoryRepository(_context);

        var manufactureRepo = new ManufactureRepository(_context);

        var pictureRepo = new ProductPictureRepository(_context);

        var productRepo = new ProductRepository(_context);

        // Act

        var mfResult = manufactureRepo.AddAsync(manufactureEntity);

        var cgResult = categoryRepo.AddAsync(categoryEntity);

        var pResult = pictureRepo.AddAsync(pictureEntity);

        var productEntity = new ProductEntity
        {
            ArticleNumber = "01",
            Title = "Test",
            Description = "Test",
            CategoryId = cgResult.Id,
            ManufactureId = mfResult.Id,
            ProductPictureId = pResult.Id,
        };

        await productRepo.AddAsync(productEntity);

        var result = await productRepo.GetAllAsync();



        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task GetOneAsync_ShouldGetOne_From_DB_And_ReturnEntity()
    {
        // Arrange

        var categoryEntity = new CategoryEntity
        {
            CategoryName = "Test"
        };

        var manufactureEntity = new ManufactureEntity
        {
            Manufacture = "Test"
        };

        var pictureEntity = new ProductPictureEntity
        {
            Picture = "Url12"
        };

        var categoryRepo = new CategoryRepository(_context);

        var manufactureRepo = new ManufactureRepository(_context);

        var pictureRepo = new ProductPictureRepository(_context);

        var productRepo = new ProductRepository(_context);

        // Act

        var mfResult = manufactureRepo.AddAsync(manufactureEntity);

        var cgResult = categoryRepo.AddAsync(categoryEntity);

        var pResult = pictureRepo.AddAsync(pictureEntity);

        var productEntity = new ProductEntity
        {
            ArticleNumber = "01",
            Title = "Test",
            Description = "Test",
            CategoryId = cgResult.Id,
            ManufactureId = mfResult.Id,
            ProductPictureId = pResult.Id,
        };

        await productRepo.AddAsync(productEntity);

        var result = await productRepo.GetOneAsync(x => x.ArticleNumber == productEntity.ArticleNumber);



        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task UpdateAsync_ShouldUpdateEntity_And_ReturnEntity()
    {
        // Arrange

        var categoryEntity = new CategoryEntity
        {
            CategoryName = "Test"
        };

        var manufactureEntity = new ManufactureEntity
        {
            Manufacture = "Test"
        };

        var pictureEntity = new ProductPictureEntity
        {
            Picture = "Url12"
        };

        var categoryRepo = new CategoryRepository(_context);

        var manufactureRepo = new ManufactureRepository(_context);

        var pictureRepo = new ProductPictureRepository(_context);

        var productRepo = new ProductRepository(_context);

        // Act

        var mfResult = manufactureRepo.AddAsync(manufactureEntity);

        var cgResult = categoryRepo.AddAsync(categoryEntity);

        var pResult = pictureRepo.AddAsync(pictureEntity);

        var productEntity = new ProductEntity
        {
            ArticleNumber = "01",
            Title = "Test",
            Description = "Test",
            CategoryId = cgResult.Id,
            ManufactureId = mfResult.Id,
            ProductPictureId = pResult.Id,
        };

        await productRepo.AddAsync(productEntity);

        var newEntity = new ProductEntity
        {
            ArticleNumber = "01",
            Title = "Test2",
            Description = "Test2",
            CategoryId = cgResult.Id,
            ManufactureId = mfResult.Id,
            ProductPictureId = pResult.Id,
        };

        var result = await productRepo.UpdateAsync(x => x.ArticleNumber == productEntity.ArticleNumber, newEntity);



        // Assert
        Assert.NotNull(result);

    }
}

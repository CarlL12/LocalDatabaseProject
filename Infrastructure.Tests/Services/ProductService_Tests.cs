
using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;


namespace Infrastructure.Tests.Services;

public class ProductService_Tests
{

    private readonly ProductContext _context = new(new DbContextOptionsBuilder<ProductContext>()

     .UseInMemoryDatabase($"{Guid.NewGuid()}")
     .Options);


    [Fact]

    public async Task CreateProductAsync_ShouldCreate_OneProduct_AndReturnTrue()
    {
        var product = new Product
        {
            ArticleNumber = "123",
            Description = "Description",
            Title = "Title",
            Price = 1,
            SalePrice = 1,
            Manufacture = "Test",
            CategoryName = "Category",
            ProductPicture = "Test"
        };

        var categoryRepo = new CategoryRepository(_context);
        var manufactureRepo = new ManufactureRepository(_context);
        var productRepo = new ProductRepository(_context);
        var pictureRepo = new ProductPictureRepository(_context);
        var priceRepo = new PriceRepository(_context);

        var productService = new ProductService(categoryRepo, manufactureRepo, priceRepo, pictureRepo, productRepo);

        // Act
        var result = await productService.CreateProductAsync(product);


        //Assert
        Assert.True(result);

    }

    [Fact]

    public async Task CreateCategoryAsync_ShouldCreate_OneCategory_AndReturnEntity()
    {
        var product = new Product
        {
            ArticleNumber = "123",
            Description = "Description",
            Title = "Title",
            Price = 1,
            SalePrice = 1,
            Manufacture = "Test",
            CategoryName = "Category",
            ProductPicture = "Test"
        };

        var categoryRepo = new CategoryRepository(_context);
        var manufactureRepo = new ManufactureRepository(_context);
        var productRepo = new ProductRepository(_context);
        var pictureRepo = new ProductPictureRepository(_context);
        var priceRepo = new PriceRepository(_context);

        var productService = new ProductService(categoryRepo, manufactureRepo, priceRepo, pictureRepo, productRepo);

        // Act
        var result = await productService.CreateCategoryAsync(product);


        //Assert
        Assert.NotNull(result);
    }

    [Fact]

    public async Task CreateManufactureAsync_ShouldCreate_OneManufacture_AndReturnEntity()
    {
        var product = new Product
        {
            ArticleNumber = "123",
            Description = "Description",
            Title = "Title",
            Price = 1,
            SalePrice = 1,
            Manufacture = "Test",
            CategoryName = "Category",
            ProductPicture = "Test"
        };

        var categoryRepo = new CategoryRepository(_context);
        var manufactureRepo = new ManufactureRepository(_context);
        var productRepo = new ProductRepository(_context);
        var pictureRepo = new ProductPictureRepository(_context);
        var priceRepo = new PriceRepository(_context);

        var productService = new ProductService(categoryRepo, manufactureRepo, priceRepo, pictureRepo, productRepo);

        // Act
        var result = await productService.CreateManufactureAsync(product);


        //Assert
        Assert.NotNull(result);
    }

    [Fact]

    public async Task CreateProductPictureAsync_ShouldCreate_OneProductPicture_AndReturnEntity()
    {
        var product = new Product
        {
            ArticleNumber = "123",
            Description = "Description",
            Title = "Title",
            Price = 1,
            SalePrice = 1,
            Manufacture = "Test",
            CategoryName = "Category",
            ProductPicture = "Test"
        };

        var categoryRepo = new CategoryRepository(_context);
        var manufactureRepo = new ManufactureRepository(_context);
        var productRepo = new ProductRepository(_context);
        var pictureRepo = new ProductPictureRepository(_context);
        var priceRepo = new PriceRepository(_context);

        var productService = new ProductService(categoryRepo, manufactureRepo, priceRepo, pictureRepo, productRepo);

        // Act
        var result = await productService.CreateProductPictureAsync(product);


        //Assert
        Assert.NotNull(result);
    }

    [Fact] 

    public async Task CreatePriceAsync_ShouldCreate_OnePriceAndSalePrice_AndReturnTrue()
    {
        var product = new Product
        {
            ArticleNumber = "123",
            Description = "Description",
            Title = "Title",
            Price = 1,
            SalePrice = 1,
            Manufacture = "Test",
            CategoryName = "Category",
            ProductPicture = "Test"
        };

        var categoryRepo = new CategoryRepository(_context);
        var manufactureRepo = new ManufactureRepository(_context);
        var productRepo = new ProductRepository(_context);
        var pictureRepo = new ProductPictureRepository(_context);
        var priceRepo = new PriceRepository(_context);

        var productService = new ProductService(categoryRepo, manufactureRepo, priceRepo, pictureRepo, productRepo);

        // Act
        var result = await productService.CreatePriceAsync(product);


        //Assert
        Assert.True(result);
    }

    [Fact]

    public async Task GetAllProductsAsync_ShouldGetAllProducts_AndReturnList()
    {
        var product = new Product
        {
            ArticleNumber = "123",
            Description = "Description",
            Title = "Title",
            Price = 1,
            SalePrice = 1,
            Manufacture = "Test",
            CategoryName = "Category",
            ProductPicture = "Test"
        };

        var categoryRepo = new CategoryRepository(_context);
        var manufactureRepo = new ManufactureRepository(_context);
        var productRepo = new ProductRepository(_context);
        var pictureRepo = new ProductPictureRepository(_context);
        var priceRepo = new PriceRepository(_context);

        var productService = new ProductService(categoryRepo, manufactureRepo, priceRepo, pictureRepo, productRepo);

        // Act
        await productService.CreateProductAsync(product);

        var result = await productService.GetAllProductsAsync();


        //AssertS
        Assert.NotNull(result);
    }

    [Fact]

    public async Task GetOneAsync_ShouldGetOneProduct_AndReturnProduct()
    {
        var product = new Product
        {
            ArticleNumber = "123",
            Description = "Description",
            Title = "Title",
            Price = 1,
            SalePrice = 1,
            Manufacture = "Test",
            CategoryName = "Category",
            ProductPicture = "Test"
        };

        var categoryRepo = new CategoryRepository(_context);
        var manufactureRepo = new ManufactureRepository(_context);
        var productRepo = new ProductRepository(_context);
        var pictureRepo = new ProductPictureRepository(_context);
        var priceRepo = new PriceRepository(_context);

        var productService = new ProductService(categoryRepo, manufactureRepo, priceRepo, pictureRepo, productRepo);

        // Act
        await productService.CreateProductAsync(product);

        var result = await productService.GetOneAsync(product.ArticleNumber);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]

    public async Task UpdateProductsAsync_ShouldUpdateProduct_AndReturnTrue()
    {
        var product = new Product
        {
            ArticleNumber = "123",
            Description = "Description",
            Title = "Title",
            Price = 1,
            SalePrice = 1,
            Manufacture = "Test",
            CategoryName = "Category",
            ProductPicture = "Test"
        };



        var categoryRepo = new CategoryRepository(_context);
        var manufactureRepo = new ManufactureRepository(_context);
        var productRepo = new ProductRepository(_context);
        var pictureRepo = new ProductPictureRepository(_context);
        var priceRepo = new PriceRepository(_context);

        var productService = new ProductService(categoryRepo, manufactureRepo, priceRepo, pictureRepo, productRepo);

        // Act
        await productService.CreateProductAsync(product);

        var newProduct = new Product
        {
            ArticleNumber = product.ArticleNumber,
            Description = "Description",
            Title = "Title",
            Price = 1,
            SalePrice = 1,
            Manufacture = "Test",
            CategoryName = "Category",
            ProductPicture = "Test"
        };

        var result = await productService.UpdateProductsAsync(newProduct);

        //Assert
        Assert.True(result);
    }

    [Fact]

    public async Task DeleteProductAsync_ShouldDeleteProduct_AndReturnTrue()
    {
        var product = new Product
        {
            ArticleNumber = "123",
            Description = "Description",
            Title = "Title",
            Price = 1,
            SalePrice = 1,
            Manufacture = "Test",
            CategoryName = "Category",
            ProductPicture = "Test"
        };

        var categoryRepo = new CategoryRepository(_context);
        var manufactureRepo = new ManufactureRepository(_context);
        var productRepo = new ProductRepository(_context);
        var pictureRepo = new ProductPictureRepository(_context);
        var priceRepo = new PriceRepository(_context);

        var productService = new ProductService(categoryRepo, manufactureRepo, priceRepo, pictureRepo, productRepo);

        // Act
        await productService.CreateProductAsync(product);

        var result = await productService.DeleteProductAsync(product);

        //Assert
        Assert.True(result);
    }
}

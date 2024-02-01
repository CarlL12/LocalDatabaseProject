
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Services;

public  class ProductService(CategoryRepository categoryRepository, ManufactureRepository manufactureRepository, PriceRepository priceRepository, ProductPictureRepository productPictureRepository, ProductRepository productRepository)
{
    private readonly CategoryRepository _categoryRepository = categoryRepository;
    private readonly ManufactureRepository _manufactureRepository = manufactureRepository;
    private readonly PriceRepository _priceRepository = priceRepository;
    private readonly ProductPictureRepository _productPictureRepository = productPictureRepository;
    private readonly ProductRepository _productRepository = productRepository;


    public async Task<bool> CreateProductAsync(Product product)
    {

        var categoryResult = await CreateCategoryAsync(product);
        var manufactureResult = await CreateManufactureAsync(product);
        var pictureResult = await CreateProductPictureAsync(product);

        var guid = Guid.NewGuid();

        var newProduct = new ProductEntity
        {
            ArticleNumber = guid.ToString().ToUpper(),
            Title = product.Title,
            Description = product.Description,
            CategoryId = categoryResult.Id,
            ManufactureId = manufactureResult.Id,
            ProductPictureId = pictureResult.Id,
        };



        var result = await _productRepository.AddAsync(newProduct);
        
        if(result != null)
        {
            product.ArticleNumber = result.ArticleNumber;

            var priceResult = await CreatePriceAsync(product);

            return priceResult;
        }

        else
        {
            return false;
        }
    }

    public async Task<CategoryEntity> CreateCategoryAsync(Product product)
    {

        var existingCategory = await _categoryRepository.GetOneAsync(x => x.CategoryName == product.CategoryName);

        var categoryEntity = new CategoryEntity();

        if(existingCategory != null)
        {
            categoryEntity.CategoryName = existingCategory.CategoryName;
            categoryEntity.Id = existingCategory.Id;
            return categoryEntity;
        }
        else
        {
            categoryEntity.CategoryName= product.CategoryName;
           

            var result = await _categoryRepository.AddAsync(categoryEntity);

            return result;
        }
    }

    public async Task<ManufactureEntity> CreateManufactureAsync(Product product)
    {
        var existingManufacture = await _manufactureRepository.GetOneAsync(x => x.Manufacture == product.Manufacture);

        if (existingManufacture != null)
        {
            return existingManufacture;
        }
        else
        {
            var result = await _manufactureRepository.AddAsync(product);

            return result;
        }
    }

    public async Task<ProductPictureEntity> CreateProductPictureAsync(Product product)
    {

        var existingPicture = await _productPictureRepository.GetOneAsync(x => x.Picture == product.ProductPicture);

        if(existingPicture != null)
        {
            return existingPicture;
        }
        else
        {
            var result = await _productPictureRepository.AddAsync(product);

            return result;
        }
    }

    public async Task<bool> CreatePriceAsync(Product product)

    {

        var newPrice = new PriceEntity
        {
            ProductId = product.ArticleNumber,
            ProductPrice = product.Price,
            SalePrice = product.SalePrice

        };

        var result = await _priceRepository.AddAsync(newPrice);

        if (result != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var list = new List<Product>();
        var result = await _productRepository.GetWithAllAsync();


        if (result != null)
        {
            foreach (ProductEntity productEntity in result)
            {
                var product = new Product
                {
                    ArticleNumber = productEntity.ArticleNumber,
                    Title = productEntity.Title,
                    Description = productEntity.Description,
                    Price = productEntity.Price!.ProductPrice,
                    SalePrice = productEntity.Price.SalePrice,
                    CategoryName = productEntity.Category.CategoryName,
                    Manufacture = productEntity.Manufacture.Manufacture,
                    ProductPicture = productEntity.ProductPicture.Picture!
                };

                list.Add(product);
            };

            return list;
        }
        else
        {
            return null!;
        }

    }

    public async Task<Product> GetOneAsync(string articleNumber)
    {
        var result = await _productRepository.GetOneWithAllAsync(x => x.ArticleNumber == articleNumber);

        if (result != null)
        {
            var product = new Product
            {
                ArticleNumber = result.ArticleNumber,
                Title = result.Title,
                Description = result.Description,
                Price = result.Price!.ProductPrice,
                SalePrice = result.Price!.SalePrice,
                Manufacture = result.Manufacture.Manufacture,
                ProductPicture = result.ProductPicture.Picture!,
                CategoryName= result.Category.CategoryName,

            };
            return product;
        }
        else
        {
            return null!;

        }

    }

    public async Task<bool> UpdateProductsAsync(Product product)
    {

        var categoryResult = await CreateCategoryAsync(product);
        var manufactureResult = await CreateManufactureAsync(product);
        var pictureResult = await CreateProductPictureAsync(product);

        var newProduct = new ProductEntity
        {
            ArticleNumber = product.ArticleNumber,
            Title = product.Title,
            Description = product.Description,
            CategoryId = categoryResult.Id,
            ManufactureId = manufactureResult.Id,
            ProductPictureId = pictureResult.Id
        };

        var newPrice = new PriceEntity
        {
            ProductId = product.ArticleNumber,
            ProductPrice = product.Price,
            SalePrice = product.SalePrice
        };

        var productResult = await _productRepository.UpdateAsync(x => x.ArticleNumber == product.ArticleNumber, newProduct);

        var priceResult = await _priceRepository.UpdateAsync(x => x.ProductId == product.ArticleNumber, newPrice);

        if (productResult != null && priceResult != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> DeleteProductAsync(Product product)
    {

        var priceResult = await _priceRepository.DeleteAsync(x => x.ProductId == product.ArticleNumber);

        var productResult = await _productRepository.DeleteAsync(x => x.ArticleNumber == product.ArticleNumber);

        if (productResult && priceResult)
        {
            return true;
        }
        return false;

    }


}

using Infrastructure.Dtos;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services;

public class ProductMenuService(ProductService productService)
{
    private readonly ProductService _productService = productService;

    public async Task ShowProductsMenu()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("1. Add product");
            Console.WriteLine("2. Show all");
            Console.WriteLine("3. Update/delete product");
            Console.WriteLine("4. Return to main menu");
            Console.Write("");
            if (int.TryParse(Console.ReadLine(), out int option))
            {
                switch (option)
                {
                    case 1:
                        await AddProduct();
                        break;
                    case 2:
                        await ShowAllMenu();
                        break;
                    case 3:
                        await UpdateOrDeleteProductMenu();
                        break;
                    case 4:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        }

    }

    public async Task AddProduct()
    {
        var running = true;

        while (running)
        {
            Console.Clear();
            var product = new Product();


            Console.Clear();
            Console.Write("Title:");
            product.Title = Console.ReadLine()!;
            Console.Write("Description(optional):");
            product.Description = Console.ReadLine()!;
            Console.Write("Price:");
            product.Price = int.Parse(Console.ReadLine()!);
            Console.Write("Sale Price(optional):");
            string salePriceInput = Console.ReadLine()!;
            product.SalePrice = int.TryParse(salePriceInput, out int salePrice) ? (int?)salePrice : null;
            Console.Write("Manufacture :");
            product.Manufacture = Console.ReadLine()!;
            Console.Write("Category:");
            product.CategoryName = Console.ReadLine()!;
            Console.Write("Product picture url:");
            product.ProductPicture = Console.ReadLine()!;

            Console.Clear();

            var contactResult = await _productService.CreateProductAsync(product);

            if (contactResult)
            {
                Console.Clear();
                Console.WriteLine("Product was created!");

                running = false;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again.");
            }

        }
    }

    public async Task ShowAllMenu()
    {
        Console.Clear();

        foreach (var product in await _productService.GetAllProductsAsync())
        {
            Console.WriteLine("_________________");
            Console.WriteLine($"Article number: {product.ArticleNumber}");
            Console.WriteLine($"Title: {product.Title}");
            Console.WriteLine($"Description: {product.Description}");
            Console.WriteLine($"Price: {product.Price}");
            Console.WriteLine($"Sale price: {product.SalePrice}");
            Console.WriteLine($"Manufacture: {product.Manufacture}");
            Console.WriteLine($"Category name: {product.CategoryName}");
            Console.WriteLine($"Product picture: {product.ProductPicture}");

        }
        Console.WriteLine("_________________");
        Console.WriteLine("Press any key to return to menu");
        Console.ReadKey();



    }


    public async Task UpdateOrDeleteProductMenu()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Enter article number: ");
            Console.Write("");
            string Id = Console.ReadLine()!;


            var product = await _productService.GetOneAsync(Id);

            if (product != null)
            {
                Console.Clear();
                Console.WriteLine($"Article number: {product.ArticleNumber}");
                Console.WriteLine($"Title: {product.Title}");
                Console.WriteLine($"Description: {product.Description}");
                Console.WriteLine($"Price: {product.Price}");
                Console.WriteLine($"Sale price: {product.SalePrice}");
                Console.WriteLine($"Manufacture: {product.Manufacture}");
                Console.WriteLine($"Category name: {product.CategoryName}");
                Console.WriteLine($"Product picture: {product.ProductPicture}");


                Console.WriteLine("______________");

                Console.WriteLine("1. Update");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Exit");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:

                            Console.Clear();
                            var newProduct = new Product { ArticleNumber = product.ArticleNumber };

                            Console.WriteLine("Update with new values");
                            Console.Write("Title:");
                            newProduct.Title = Console.ReadLine()!;
                            Console.Write("Description:");
                            newProduct.Description = Console.ReadLine()!;
                            Console.Write("Price:");
                            newProduct.Price = int.Parse(Console.ReadLine()!);
                            Console.Write("Sale price:");
                            string salePriceInput = Console.ReadLine()!;
                            product.SalePrice = int.TryParse(salePriceInput, out int salePrice) ? (int?)salePrice : null;
                            Console.Write("Manufacture:");
                            newProduct.Manufacture = Console.ReadLine()!;
                            Console.Write("CategoryName:");
                            newProduct.CategoryName = Console.ReadLine()!;
                            Console.Write("Product picture url:");
                            newProduct.ProductPicture = Console.ReadLine()!;


                            var updateResult = await _productService.UpdateProductsAsync(newProduct);

                            if (updateResult)
                            {
                                Console.Clear();
                                Console.WriteLine("Product was updated");
                                running = false;
                            }
                            else
                            {
                                Console.WriteLine("Something went wrong");
                            }


                            break;
                        case 2:
                            var result = await _productService.DeleteProduct(product);

                            if (result)
                            {
                                Console.Clear();
                                Console.WriteLine("Product was deleted");
                                running = false;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Could not delete product");
                            }
                            break;
                        case 3:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
                running = false;
                Console.ReadKey();
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Could not find the product you where searching for, please try again.");
                Console.ReadKey();
            }


        }
    }
}
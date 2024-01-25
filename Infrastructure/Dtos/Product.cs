
namespace Infrastructure.Dtos;

public  class Product
{
    public string ArticleNumber { get; set; } = null!;

    public string? Description {  get; set; }

    public string Title { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal? SalePrice { get; set; }

    public string Manufacture { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public string ProductPicture { get; set; } = null!;
}

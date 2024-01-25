using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Dtos;


namespace Infrastructure.Entities;

public partial class ProductPictureEntity
{
    [Key]
    public int Id { get; set; }

    [Column("Picture")]
    public string? Picture { get; set; }

    [InverseProperty("ProductPicture")]
    public virtual ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();

    public static implicit operator ProductPictureEntity(Product product)
    {

        return new ProductPictureEntity
        {
            Picture = product.ProductPicture
        };
    }
}

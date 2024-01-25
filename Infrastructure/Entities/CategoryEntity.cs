
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Dtos;


namespace Infrastructure.Entities;

public partial class CategoryEntity
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string CategoryName { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();

    public static implicit operator CategoryEntity(Product product)
    {

        return new CategoryEntity
        {
            CategoryName = product.CategoryName
        };
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public partial class PriceEntity
{
    [Key]
    [StringLength(400)]
    public string ProductId { get; set; } = null!;

    [Column("ProductPrice", TypeName = "money")]
    public decimal ProductPrice { get; set; }

    [Column(TypeName = "money")]
    public decimal? SalePrice { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Price")]
    public virtual ProductEntity Product { get; set; } = null!;

    public static implicit operator PriceEntity(Product product)
    {

        return new PriceEntity
        {
            ProductId = product.ArticleNumber,
            ProductPrice = product.Price,
            SalePrice = product.SalePrice
        };
    }
}

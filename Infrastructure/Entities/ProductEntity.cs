using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public partial class ProductEntity
{
    [Key]
    [StringLength(400)]
    public string ArticleNumber { get; set; } = null!;

    public string? Description { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    public int ManufactureId { get; set; }

    public int CategoryId { get; set; }

    public int ProductPictureId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual CategoryEntity Category { get; set; } = null!;

    [ForeignKey("ManufactureId")]
    [InverseProperty("Products")]
    public virtual ManufactureEntity Manufacture { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual PriceEntity? Price { get; set; }

    [ForeignKey("ProductPictureId")]
    [InverseProperty("Products")]
    public virtual ProductPictureEntity ProductPicture { get; set; } = null!;

    public static implicit operator ProductEntity(Product product)
    {
        return new ProductEntity
        {
            ArticleNumber = product.ArticleNumber,
            Description = product.Description,
            Title = product.Title
        };
    }
}

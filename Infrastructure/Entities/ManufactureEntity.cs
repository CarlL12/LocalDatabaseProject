using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Entities;

public partial class ManufactureEntity
{
    [Key]
    public int Id { get; set; }

    [Column("Manufacture")]
    [StringLength(50)]
    public string Manufacture { get; set; } = null!;

    [InverseProperty("Manufacture")]
    public virtual ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();

    public static implicit operator ManufactureEntity(Product product)
    {
        return new ManufactureEntity
        {
            Manufacture = product.Manufacture
        };
    }
}

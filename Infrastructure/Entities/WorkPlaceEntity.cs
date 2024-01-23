using Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;


public class WorkPlaceEntity
{
    [Key]

    public int Id { get; set; }

    [Required]
    [StringLength(40)]
    public string CompanyName { get; set; } = null!;

    [Required]
    [StringLength(30)]
    public string Title { get; set; } = null!;

    public virtual ICollection<ContactEntity> Contacts { get; set; } = new List<ContactEntity>();

    public static implicit operator WorkPlaceEntity(Contact contact)
    {
        return new WorkPlaceEntity
        {
            CompanyName = contact.CompanyName,
            Title = contact.Title,
        };
    }

}

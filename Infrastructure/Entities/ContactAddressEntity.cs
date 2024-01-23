using Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;


public class ContactAddressEntity
{

    [Key]

    public int Id { get; set; }

    [Required]

    [StringLength(30)]

    public string StreetName { get; set; } = null!;

    [Required]
    [StringLength(30)]

    public string City { get; set; } = null!;
    [Required]

    public int PostalCode { get; set; }

    public virtual ICollection<ContactEntity> Contacts { get; set; } = new List<ContactEntity>();

    public static implicit operator ContactAddressEntity(Contact contact)
    {
        return new ContactAddressEntity
        {
            StreetName = contact.StreetName,
            City = contact.City,
            PostalCode = contact.PostalCode,
        };
    }

}


using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Dtos;

namespace Infrastructure.Entities;

public class ContactInformationEntity
{

    [Key]
    [ForeignKey(nameof(ContactEntity))]

    public string ContactId { get; set; } = null!;

    [Required]
    [StringLength(40)]

    public string Email { get; set; } = null!;

    [Required]
    [StringLength(20)]

    public string PhoneNumber { get; set; } = null!;

    public virtual ContactEntity Contact { get; set; } = null!;

    public static implicit operator ContactInformationEntity(Contact contact)
    {
        return new ContactInformationEntity
        {
            ContactId = contact.PersonId,
            Email = contact.Email,
            PhoneNumber = contact.PhoneNumber,
        };
    }
}

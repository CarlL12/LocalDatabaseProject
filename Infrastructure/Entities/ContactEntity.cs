using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Dtos;

namespace Infrastructure.Entities;

public class ContactEntity
{
    [Key]
    public string PersonId { get; set; } = null!;

    [Required]

    [StringLength(20)]

    public string FirstName { get; set; } = null!;

    [Required]

    [StringLength(30)]

    public string LastName { get; set; } = null!;

    [Required]

    public int Age { get; set; }

    [Required]
    [ForeignKey(nameof(ContactAddressEntity))]
    public int ContactAddressId { get; set; }

    [Required]
    [ForeignKey(nameof(WorkPlaceEntity))]
    public int WorkPlaceId { get; set; }

    [Required]
    [ForeignKey(nameof(EducationEntity))]
    public int EducationId { get; set; }

    public virtual ContactAddressEntity ContactAddress { get; set; } = null!;

    public virtual WorkPlaceEntity WorkPlace { get; set; } = null!;

    public virtual EducationEntity Education { get; set; } = null!;

    public virtual ContactInformationEntity ContactInformation { get; set; } = null!;

    public static implicit operator ContactEntity(Contact contact)
    {
        return new ContactEntity
        {
            PersonId = contact.PersonId,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Age = contact.Age,
        };
    }

}

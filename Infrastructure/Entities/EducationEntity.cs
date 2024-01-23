using Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;


public class EducationEntity
{
    [Key]

    public int Id { get; set; }

    [Required]
    [StringLength(100)]

    public string EducationName { get; set; } = null!;

    [Required]
    [StringLength(100)]

    public string InstitutionName { get; set; } = null!;

    public virtual ICollection<ContactEntity> Contacts { get; set; } = new List<ContactEntity>();

    public static implicit operator EducationEntity(Contact contact) 
    {
        return new EducationEntity
        {
            EducationName = contact.EducationName,
            InstitutionName = contact.InstitutionName,
        };
    }
}

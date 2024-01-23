using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos;

public  class Contact
{
    
    public string PersonId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Age { get; set; }

    public string StreetName { get; set; } = null!;

    public string City { get; set; } = null!;

    public int PostalCode { get; set; }

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string EducationName { get; set; } = null!;

    public string InstitutionName { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string Title { get; set; } = null!;

    //public static implicit operator Contact (ContactEntity contactEntity,ContactAddressEntity addressEntity, ContactInformationEntity informationEntity, EducationEntity educationEntity, WorkPlaceEntity workPlaceEntity)
    //{
    //    var contact = new Contact
    //    {
    //        PersonId = contactEntity.PersonId,
    //        FirstName = contactEntity.FirstName,
    //        LastName = contactEntity.LastName,
    //        Age = contactEntity.Age,
    //        StreetName = addressEntity.StreetName,
    //        City = addressEntity.City,
    //        PostalCode = addressEntity.PostalCode,
    //        Email = informationEntity.Email,
    //        PhoneNumber = informationEntity.PhoneNumber,
    //        EducationName = educationEntity.EducationName,
    //        InstitutionName = educationEntity.InstitutionName,
    //        CompanyName = workPlaceEntity.CompanyName,
    //        Title = workPlaceEntity.Title
    //    };

    //    return contact;
    //}
}

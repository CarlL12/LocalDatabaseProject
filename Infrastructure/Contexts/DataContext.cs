using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public partial class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public virtual DbSet<ContactEntity> Contacts { get; set; }
    public virtual DbSet<ContactAddressEntity> Address { get; set; }
    public virtual DbSet<ContactInformationEntity> Information { get; set; }
    public virtual DbSet<EducationEntity> Educations { get; set; }
    public virtual DbSet<WorkPlaceEntity> WorkPlaces { get; set; }


}

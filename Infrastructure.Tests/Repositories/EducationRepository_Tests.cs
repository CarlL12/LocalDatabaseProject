

using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tests.Repositories;

public  class EducationRepository_Tests
{

    private readonly DataContext _context = new(new DbContextOptionsBuilder<DataContext>()

    .UseInMemoryDatabase($"{Guid.NewGuid()}")
    .Options);


    [Fact]

    public async Task AddAsync_Should_Add_One_EducationEntity_To_Database_And_Return_Entity()
    {
        // Arrange

        var educationEntity = new EducationEntity
        {
            InstitutionName = "Test",
            EducationName = "Test",
        };

        var educationRepo = new EducationRepository(_context);

        // Act

        var result = await educationRepo.AddAsync(educationEntity);

        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task DeleteAsync_ShouldDeleteEntity_And_Return_True()
    {
        // Arrange


        var educationEntity = new EducationEntity
        {
            InstitutionName = "Test",
            EducationName = "Test",
        };

        var educationRepo = new EducationRepository(_context);

        // Act

        await educationRepo.AddAsync(educationEntity);

        var result = await educationRepo.DeleteAsync(x => x.EducationName == educationEntity.EducationName);



        // Assert
        Assert.True(result);

    }

    [Fact]

    public async Task ExistsAsync_ShouldCheck_If_EntityExists_And_ReturnTrue()
    {
        // Arrange

        var educationEntity = new EducationEntity
        {
            InstitutionName = "Test",
            EducationName = "Test",
        };

        var educationRepo = new EducationRepository(_context);

        // Act

        await educationRepo.AddAsync(educationEntity);

        var result = await educationRepo.ExistsAsync(x => x.EducationName == educationEntity.EducationName);



        // Assert
        Assert.True(result);

    }

    [Fact]

    public async Task GetAllAsync_ShouldGetAll_From_DB_And_ReturnList()
    {
        // Arrange

        var educationEntity = new EducationEntity
        {
            InstitutionName = "Test",
            EducationName = "Test",
        };

        var educationRepo = new EducationRepository(_context);

        // Act

        await educationRepo.AddAsync(educationEntity);

        var result = await educationRepo.GetAllAsync();



        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task GetOneAsync_ShouldGetOne_From_DB_And_ReturnEntity()
    {
        // Arrange

        var educationEntity = new EducationEntity
        {
            InstitutionName = "Test",
            EducationName = "Test",
        };

        var educationRepo = new EducationRepository(_context);

        // Act

        await educationRepo.AddAsync(educationEntity);

        var result = await educationRepo.GetOneAsync(x => x.EducationName == educationEntity.EducationName);



        // Assert
        Assert.NotNull(result);

    }

    [Fact]

    public async Task UpdateAsync_ShouldUpdateEntity_And_ReturnEntity()
    {
        // Arrange

        var educationEntity = new EducationEntity
        {
            InstitutionName = "Test",
            EducationName = "Test",
        };

        var educationRepo = new EducationRepository(_context);

        // Act

        var addResult = await educationRepo.AddAsync(educationEntity);

        var newEntity = new EducationEntity
        {
            Id = addResult.Id,
            InstitutionName = "Test2",
            EducationName = "Test2",
        };

        var result = await educationRepo.UpdateAsync(x => x.EducationName == educationEntity.EducationName, newEntity);



        // Assert
        Assert.NotNull(result);

    }
}

﻿// <auto-generated />
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Entities.ContactAddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Infrastructure.Entities.ContactEntity", b =>
                {
                    b.Property<string>("PersonId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("ContactAddressId")
                        .HasColumnType("int");

                    b.Property<int>("EducationId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("WorkPlaceId")
                        .HasColumnType("int");

                    b.HasKey("PersonId");

                    b.HasIndex("ContactAddressId");

                    b.HasIndex("EducationId");

                    b.HasIndex("WorkPlaceId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Infrastructure.Entities.ContactInformationEntity", b =>
                {
                    b.Property<string>("ContactId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ContactId");

                    b.ToTable("Information");
                });

            modelBuilder.Entity("Infrastructure.Entities.EducationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EducationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("InstitutionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("Infrastructure.Entities.WorkPlaceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("WorkPlaces");
                });

            modelBuilder.Entity("Infrastructure.Entities.ContactEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.ContactAddressEntity", "ContactAddress")
                        .WithMany("Contacts")
                        .HasForeignKey("ContactAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.EducationEntity", "Education")
                        .WithMany("Contacts")
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.WorkPlaceEntity", "WorkPlace")
                        .WithMany("Contacts")
                        .HasForeignKey("WorkPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactAddress");

                    b.Navigation("Education");

                    b.Navigation("WorkPlace");
                });

            modelBuilder.Entity("Infrastructure.Entities.ContactInformationEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.ContactEntity", "Contact")
                        .WithOne("ContactInformation")
                        .HasForeignKey("Infrastructure.Entities.ContactInformationEntity", "ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Infrastructure.Entities.ContactAddressEntity", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("Infrastructure.Entities.ContactEntity", b =>
                {
                    b.Navigation("ContactInformation")
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Entities.EducationEntity", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("Infrastructure.Entities.WorkPlaceEntity", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
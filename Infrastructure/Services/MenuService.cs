
using Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore.Update;

namespace Infrastructure.Services;

public  class MenuService(ContactService contactService, ProductMenuService productMenuService)
{
    private readonly ContactService _contactService = contactService;
    private readonly ProductMenuService _productMenuService = productMenuService;

   public async Task ShowMeny()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Show Contacts");
            Console.WriteLine("2. Show Products");
            Console.WriteLine("3. Exit");
            Console.Write("");
            if (int.TryParse(Console.ReadLine(), out int option))
            {
                Console.Clear();
                switch (option)
                {
                    case 1:
                        await ShowContactsMenu();
                        break;
                    case 2:
                        await _productMenuService.ShowProductsMenu();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    public async Task ShowContactsMenu()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("1. Add contact");
            Console.WriteLine("2. Show all");
            Console.WriteLine("3. Update/delete contact");
            Console.WriteLine("4. Return to main menu");
            Console.Write("");
            if (int.TryParse(Console.ReadLine(), out int option))
            {
                switch (option)
                {
                    case 1:
                        await AddContactMenu();
                        break;
                    case 2:
                        await ShowAllMenu();
                        break;
                    case 3:
                        await UpdateOrDeleteContactMenu();
                        break;
                    case 4:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        }

    }

    public async Task ShowAllMenu()
    {
            Console.Clear();
            int count = 1;

            foreach (var contact in await _contactService.GetAllContactsAsync())
            {
                Console.WriteLine("_________________");
                Console.WriteLine($"Contact {count} ");
                Console.WriteLine($"PersonId: {contact.PersonId}");
                Console.WriteLine($"First name: {contact.FirstName}");
                Console.WriteLine($"Last name: {contact.LastName}");
                Console.WriteLine($"Age: {contact.Age}");
                Console.WriteLine($"Street name: {contact.StreetName}");
                Console.WriteLine($"Postal code: {contact.PostalCode}");
                Console.WriteLine($"City: {contact.City}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Education: {contact.EducationName}");
                Console.WriteLine($"School name: {contact.InstitutionName}");
                Console.WriteLine($"Company: {contact.CompanyName}");
                Console.WriteLine($"Work title: {contact.Title}");

                count++;
            }


           Console.WriteLine("Press any key to return to menu");
           Console.ReadKey();

   

    }
    public async Task UpdateOrDeleteContactMenu()
    {
        bool running = true;

        while(running)
        {
            Console.Clear();
            Console.WriteLine("Type the personid of the contact you wish to get:?");
            Console.Write("");
            string Id = Console.ReadLine()!;


            var contact = await _contactService.GetOneAsync(Id);

            if(contact != null)
            {
                Console.Clear();
                Console.WriteLine($"PersonId: {contact.PersonId}");
                Console.WriteLine($"First name: {contact.FirstName}");
                Console.WriteLine($"Last name: {contact.LastName}");
                Console.WriteLine($"Age: {contact.Age}");
                Console.WriteLine($"Street name: {contact.StreetName}");
                Console.WriteLine($"Postal code: {contact.PostalCode}");
                Console.WriteLine($"City: {contact.City}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Education: {contact.EducationName}");
                Console.WriteLine($"School name: {contact.InstitutionName}");
                Console.WriteLine($"Company: {contact.CompanyName}");
                Console.WriteLine($"Work title: {contact.Title}");

                Console.WriteLine("______________");

                Console.WriteLine("1. Update");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Exit");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:

                            Console.Clear();
                            var newContact = new Contact { PersonId = contact.PersonId };

                            Console.WriteLine("Update with new values");
                            Console.Write("First name:");
                            newContact.FirstName = Console.ReadLine()!;
                            Console.Write("Last name:");
                            newContact.LastName = Console.ReadLine()!;
                            Console.Write("Age:");
                            newContact.Age = int.Parse(Console.ReadLine()!);
                            Console.Write("Email:");
                            newContact.Email = Console.ReadLine()!;
                            Console.Write("Phone number:");
                            newContact.PhoneNumber = Console.ReadLine()!;
                            Console.Write("Street name:");
                            newContact.StreetName = Console.ReadLine()!;
                            Console.Write("Postal code:");
                            newContact.PostalCode = int.Parse(Console.ReadLine()!);
                            Console.Write("City:");
                            newContact.City = Console.ReadLine()!;
                            Console.Write("Company name:");
                            newContact.CompanyName = Console.ReadLine()!;
                            Console.Write("Job title:");
                            newContact.Title = Console.ReadLine()!;
                            Console.Write("School name:");
                            newContact.InstitutionName = Console.ReadLine()!;
                            Console.Write("Education name:");
                            newContact.EducationName = Console.ReadLine()!;

                            var updateResult = await _contactService.UpdateContactsAsync(newContact);

                            if(updateResult)
                            {
                                Console.Clear();
                                Console.WriteLine("Contact was updated");
                                running = false;
                            }
                            else
                            {
                                Console.WriteLine("Something went wrong");
                            }
                           

                            break;
                        case 2:
                            var result = await _contactService.DeleteContactAsync(contact);

                            if (result)
                            {
                                Console.Clear();
                                Console.WriteLine("Contact was deleted");
                                running = false;
                            }
                            else
                            {
                                Console.WriteLine("Could not delete contact");
                            }
                            break;
                        case 3:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
                running = false;
                Console.ReadKey();
            }
            
            else
            {
                Console.Clear();
                Console.WriteLine("Could not find the contact you where searching for, please try again.");
                Console.ReadKey();
            }

       
        }


    }
    public async Task AddContactMenu()
    {
        var running = true;
   
        while (running)
        {
            Console.Clear();
            var contact = new Contact();
            Console.Write("PersonId:");
            contact.PersonId = Console.ReadLine()!;

            var result = await _contactService.ContactExistsPersonIdAsync(contact);

            if (!result)
            {
                Console.Clear();
                Console.Write("First name:");
                contact.FirstName = Console.ReadLine()!;
                Console.Write("Last name:");
                contact.LastName = Console.ReadLine()!;
                Console.Write("Age:");
                contact.Age = int.Parse(Console.ReadLine()!);
                Console.Write("Email:");
                contact.Email = Console.ReadLine()!;
                Console.Write("Phone number:");
                contact.PhoneNumber = Console.ReadLine()!;
                Console.Write("Street name:");
                contact.StreetName = Console.ReadLine()!;
                Console.Write("Postal code:");
                contact.PostalCode = int.Parse(Console.ReadLine()!);
                Console.Write("City:");
                contact.City = Console.ReadLine()!;
                Console.Write("Company name:");
                contact.CompanyName = Console.ReadLine()!;
                Console.Write("Job title:");
                contact.Title = Console.ReadLine()!;
                Console.Write("School name:");
                contact.InstitutionName = Console.ReadLine()!;
                Console.Write("Education name:");
                contact.EducationName = Console.ReadLine()!;
                Console.Clear();

                var contactResult = await _contactService.CreateContactAsync(contact);

                if (contactResult)
                {
                    Console.Clear();
                    Console.WriteLine($"Contact {contact.FirstName} {contact.LastName} was created");

                    running = false;
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Something went wrong, please try again.");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("A contact with same personid already exists");
                Console.WriteLine("You need to choose another personid");
                Console.ReadKey();
            }
        }

    }


}

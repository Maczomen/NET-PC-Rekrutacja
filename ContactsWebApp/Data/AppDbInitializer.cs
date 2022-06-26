using ContactsWebApp.Data.Enums;
using ContactsWebApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsWebApp.Data
{
    //class to initialize sample data to an empty database
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                //ensure that database is created
                context.Database.EnsureCreated();

                //add 4 examplary contacts
                if (!context.Contact.Any())
                {
                    context.Contact.AddRange(new List<Contact>()
                    {
                        new Contact()
                        {

                            name = "Piotr",
                            surname = "Zarzycki",
                            email = "zarzycki.p@wp.pl",
                            password = "AlaMaKota1",
                            phoneNumber = "601077215",
                            dateOfBirth = new DateTime(2000, 10, 20),
                            category = ContactCategory.Private,
                            subCategory = null
                        },
                        new Contact()
                        {
                            name = "Adam",
                            surname = "Kminicki",
                            email = "azarzycki.p@wp.pl",
                            password = "AlaMaKota1",
                            phoneNumber = "601077000",
                            dateOfBirth = new DateTime(2010, 1, 12),
                            category = ContactCategory.Private,
                            subCategory = null
                        },
                        new Contact()
                        {
                            name = "Ewa",
                            surname = "Smolecka",
                            email = "bzarzycki.p@wp.pl",
                            password = "AlaMaKota1",
                            phoneNumber = "111111111",
                            dateOfBirth = new DateTime(2002, 9, 1),
                            category = ContactCategory.Business,
                            subCategory = "Boss"
                        },
                        new Contact()
                        {
                            name = "Adam",
                            surname = "Kminicki",
                            email = "dzarzycki.p@wp.pl",
                            password = "AlaMaKota1",
                            phoneNumber = "000999000",
                            dateOfBirth = new DateTime(2033, 11, 2),
                            category = ContactCategory.Other,
                            subCategory = "Znajomy"
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}

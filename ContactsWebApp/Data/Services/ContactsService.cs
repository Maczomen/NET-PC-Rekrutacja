using ContactsWebApp.Data.Enums;
using ContactsWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactsWebApp.Data.Services
{
    //service that is responsible for mediation between database and Contacts Controller
    //almost all methods work in async format
    public class ContactsService : IContactsService
    {
        private readonly ApplicationDbContext _context;
        public ContactsService(ApplicationDbContext context)
        {
            _context = context;
        }

        async Task IContactsService.AddAsync(Contact contact)
        {
            //checking if contact given is of Business category
            if (contact.subCategoryBuisness != null && contact.category == ContactCategory.Business)
            {
                //mapping his category for seving in database
                contact.subCategory = BusinessContactCategoryDictionary.translateBusinessContactCategoryToString(contact.subCategoryBuisness);
            }
            try
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
            } catch (Exception e) {
                throw new Exception("Email already exists");
            }
        }

        async Task IContactsService.DeleteAsync(int id)
        {
            var contact = await _context.Contact.FirstOrDefaultAsync(m => m.Id == id);
            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();
        }

        async Task<IEnumerable<Contact>> IContactsService.GetAllAsync()
        {
            var result = await _context.Contact.ToListAsync();
            return result;
        }

        async Task<Contact> IContactsService.GetByIdAsync(int id)
        {
            var result = await _context.Contact.FirstOrDefaultAsync(m => m.Id == id);
            return result;
        }

        async Task<Contact> IContactsService.UpdateAsync(int id, Contact contact)
        {
            //checking if contact given is of Business category
            if (contact.subCategoryBuisness != null && contact.category == ContactCategory.Business)
            {
                //mapping his category for seving in database
                contact.subCategory = BusinessContactCategoryDictionary.translateBusinessContactCategoryToString(contact.subCategoryBuisness);
            }
            try
            {
                _context.Update(contact);
                await _context.SaveChangesAsync();
                return contact;
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw e;
            }
        }

        bool IContactsService.ContactExists(int id)
        {
            return _context.Contact.Any(e => e.Id == id);
        }
    }
}

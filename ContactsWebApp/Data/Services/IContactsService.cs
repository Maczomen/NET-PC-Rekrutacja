using ContactsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsWebApp.Data.Services
{
    public interface IContactsService
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);
        Task AddAsync(Contact contact);
        Task<Contact> UpdateAsync(int id, Contact contact);
        Task DeleteAsync(int id);
        bool ContactExists(int id);
    }
}

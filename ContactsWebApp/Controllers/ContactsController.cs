using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactsWebApp.Data;
using ContactsWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using ContactsWebApp.Data.Services;

namespace ContactsWebApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactsService _service;

        public ContactsController(IContactsService context)
        {
            _service = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        // GET: Contacts/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var contact = await _service.GetByIdAsync(id.Value);

            if (contact == null) 
                return NotFound();

            return View(contact);
        }


        // GET: Contacts/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,surname,email,password,phoneNumber,dateOfBirth,category,subCategory,subCategoryBuisness")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddAsync(contact);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e) { 
                    return View(contact); 
                }
            }
            return View(contact);
        }

        // GET: Contacts/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) 
                return NotFound();

            var contact = await _service.GetByIdAsync(id.Value);

            if (contact == null) 
                return NotFound();

            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,surname,email,password,phoneNumber,dateOfBirth,category,subCategory,subCategoryBuisness")] Contact contact)
        {
            if (id != contact.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _service.UpdateAsync(id, contact);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.ContactExists(contact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var contact = await _service.GetByIdAsync(id.Value);

            if (contact == null)
                return NotFound();

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var contact = await _service.GetByIdAsync(id.Value);

            if (contact == null)
                return NotFound();

            await _service.DeleteAsync(id.Value);

            
            return RedirectToAction(nameof(Index));
        }
    }
}

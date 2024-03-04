using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PB.Data;
using PB.Models;

namespace PB.Controllers
{
    public class PhonebookController : Controller
    {
        private  readonly PhonebookUIContext _context = new PhonebookUIContext();

        [HttpGet("/Phonebook/Edit/")]
        public IActionResult Edit(int id)
        {
            Contact? c;
            try
            {
                c = _context?.Contacts?.First(x => x.ContactId == id);
            }
            catch
            {
                c = null;
            }
            if (c == null)
            {
                return View("Error");
            }
            return View("Edit",c); 
        }

        [HttpGet("/Phonebook/Index")]
        public IActionResult Index(int id)
        { 
            Phonebook Phonebook = _context.Phonebooks.Include(p => p.Contacts).Where(p => p.PhonebookId == id).First();
            return View(Phonebook);
        }

        [HttpGet("/Phonebook/Delete/")]
        public IActionResult DeleteItem(int id)
        {
            Contact? c;
            try
            {
              c  = _context?.Contacts?.First(x => x.ContactId == id);
            }
            catch
            {
                c = null;
            }

             if (c == null)
            {   
                return View("Index");
            }
          
            Phonebook Phonebook = _context.Phonebooks.Include(p => p.Contacts).Where(p=>p.PhonebookId == c.PhonebookId).First();
            try {
                _context.Contacts.Remove(c);
                _context.SaveChanges();
                return View("Index",Phonebook);
            }
        catch (Exception ex)
        {
                // Handle any errors
                return View("Error",ex);
        }

              
        }

        [HttpPost("/Phonebook/SaveItem")]
        public IActionResult SaveItem(Contact c) {


            Phonebook Phonebook = _context.Phonebooks.Include(p => p.Contacts).Where(p => p.PhonebookId == c.PhonebookId).First();
             var i = Phonebook.Contacts.FindIndex(x=>x.ContactId == c.ContactId);
            Phonebook.Contacts[i] = c;
            try
            {
                _context.Phonebooks.Update(Phonebook);
                _context.SaveChanges();
                return View("Index", Phonebook);
            }
            catch (Exception ex)
            {
                // Handle any errors
                return View("Error", ex);
            }
        }
    }
}

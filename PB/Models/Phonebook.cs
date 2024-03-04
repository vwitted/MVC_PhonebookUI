using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;


namespace PB.Models
{

    public class Phonebook 
    {
        //public Phonebook()  {}
     
        public int PhonebookId { get; set; }
        public List<Contact> Contacts { get; set; }
    }

}


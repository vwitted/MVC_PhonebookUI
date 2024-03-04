using Microsoft.AspNetCore.Mvc.RazorPages; 
using PB.Models;

namespace PB.Models {
public class Contact

{
    public Contact()
    {

    }
    public Contact(string forename, string surname, List<PhoneNumber> numbers)
    {
        this.Forename = forename;
        this.Surname = surname;
        this.Numbers = numbers;
    }
    public int ContactId { get; set; }

    public string Forename { get; set; }

    public string Surname { get; set; }

    public virtual List<PhoneNumber> Numbers { get; set; } = new List<PhoneNumber>();

    public int PhonebookId { get; set; }

    public Phonebook Phonebook { get; set; }



}
}

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PB.Models
{

    public class PhoneNumber
    {
    //    public PhoneNumber() { }
        public PhoneNumber(string Number)
        {
            this.Number = Number;
        }
        public int PhoneNumberId { get; set; }
        public string Number { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}

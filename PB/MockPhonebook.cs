using Microsoft.Identity.Client;
using PB.Data;
using PB.Models;
using System.Text;
namespace PB.mocking { 

    public static class MockPhonebook
    {
        public static Boolean UseMockedData = true;

         static string[] Forenames = { "James", "Alan", "July" };

        static string[] Surnames = { "Smith", "McAdams", "Burdon" };



         public static void generateMockData()
        {
            static PhoneNumber getNumbers()
            {
                return new PhoneNumber(Random.Shared.NextInt64(100000000, 999999999).ToString());
            }

            static Contact getMockContact()
            {

                var forename = Forenames[Random.Shared.Next(2)];
                var surname = Surnames[Random.Shared.Next(2)];
                var numbers = new List<PhoneNumber>();
                for (int i = 0; i < Random.Shared.Next(10); i++)
                {
                    numbers.Add(getNumbers());
                }
       
                return new Contact(forename, surname, numbers);
            }
            List<Contact> contacts = new List<Contact>();
            for (int i = 0; i < Random.Shared.Next(200); i++)
            {
                contacts.Add(getMockContact());

            }
            
            var phonebook = new Phonebook() { Contacts = contacts };
            using (var db = new PhonebookUIContext())
            {
                db.Phonebooks.Add(phonebook);
                db.SaveChanges();
            }
            
        }

    }
}   

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBook
    {
        List<Contact> addressBook = new List<Contact>();
        public AddressBook()
        {
            Contact address1 = new Contact()
            {
                FirstName = Console.ReadLine(),
                LastName = Console.ReadLine(),
                Address = Console.ReadLine(),
                City = Console.ReadLine(),
                State = Console.ReadLine(),
                ZipCode = Convert.ToInt32(Console.ReadLine()),
                PhoneNumber = Convert.ToInt64(Console.ReadLine()),
                EmailId = Console.ReadLine()
            };
            Contact address2 = new Contact()
            {
                FirstName = Console.ReadLine(),
                LastName = Console.ReadLine(),
                Address = Console.ReadLine(),
                City = Console.ReadLine(),
                State = Console.ReadLine(),
                ZipCode = Convert.ToInt32(Console.ReadLine()),
                PhoneNumber = Convert.ToInt64(Console.ReadLine()),
                EmailId = Console.ReadLine(),
            };
            addressBook.Add(address1);
            addressBook.Add(address2);
        }
        public void AddNewContactToAddressBook(Contact contact)
        {
            addressBook.Add(contact);
        }
        public void Display()
        {
            foreach(var contact in addressBook)
            {
                Console.WriteLine(contact.FirstName+" "+contact.LastName+" "+contact.Address+" "+contact.City+" "+contact.State+" "+contact.ZipCode+" "+contact.PhoneNumber+" "+contact.EmailId);
            }
        }
    }
}

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
        public void EditContactInAddressBook(string name)
        {
            foreach(var contact in addressBook)
            {
                if (contact.FirstName.Equals(name))
                {
                    Console.WriteLine("Enter the Option To Update");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter the FirstName to Update");
                            contact.FirstName = Console.ReadLine(); break;
                        case 2:
                            Console.WriteLine("Enter the LastName to Update");
                            contact.LastName = Console.ReadLine(); break;
                        case 3:
                            Console.WriteLine("Enter the Address to Update");
                            contact.Address = Console.ReadLine(); break;
                        case 4:
                            Console.WriteLine("Enter the City to Update");
                            contact.City = Console.ReadLine(); break;
                        case 5:
                            Console.WriteLine("Enter the State to Update");
                            contact.State = Console.ReadLine(); break;
                        case 6:
                            Console.WriteLine("Enter the Email to Update");
                            contact.ZipCode = Convert.ToInt32(Console.ReadLine()); break;
                        case 7:
                            Console.WriteLine("Enter the Postal to Update");
                            contact.PhoneNumber = Convert.ToInt64(Console.ReadLine()); break;
                        case 8:
                            Console.WriteLine("Enter the MobileNumber to Update");
                            contact.EmailId = Console.ReadLine();
                            break;
                    }
                }
                Display();
            }
        }
        public void DeleteContactFromAddressBook(string name1)
        {
            Contact delete = new Contact();
            foreach(var contact in addressBook)
            {
                if (contact.FirstName.Equals(name1))
                {
                    delete = contact;
                }
            }
            addressBook.Remove(delete);
            Display();
        }
    }
}

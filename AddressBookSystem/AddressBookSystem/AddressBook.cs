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
        Dictionary<string,List<Contact>> dict = new Dictionary<string,List<Contact>>();
        public AddressBook()
        {
            Console.WriteLine("Enter the details: 1.First Name 2.Last Name 3.Address 4.City 5.State 6.Zip Code 7.Phone number 8.EmailId");
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
            Console.WriteLine("Enter the details: 1.First Name 2.Last Name 3.Address 4.City 5.State 6.Zip Code 7.Phone number 8.EmailId");
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
                    Console.WriteLine("Enter the Option To Update: 1.First Name\n2.Last Name\n3.Address\n4.City\n5.State\n6.ZipCode\n7.Phone Number\n8.Email Id");
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
                            Console.WriteLine("Enter the ZipCode to Update");
                            contact.ZipCode = Convert.ToInt32(Console.ReadLine()); break;
                        case 7:
                            Console.WriteLine("Enter the Phone number to Update");
                            contact.PhoneNumber = Convert.ToInt64(Console.ReadLine()); break;
                        case 8:
                            Console.WriteLine("Enter the Email Id to Update");
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
        public bool NameExist(string name)
        {
            foreach(var data in dict.Keys)
            {
                if (data.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }
        public void AddDictionary(string name)
        {
            if (dict==null)
            {
                dict.Add(name, addressBook);
                return;
            }
            if (NameExist(name)==false)
            {
                dict.Add(name,addressBook);
            }
        }
        public void EditDictionary(string name1, string contactName)
        {
            foreach(var data in dict)
            {
                if (dict.Keys.Equals(name1))
                {
                    addressBook = data.Value;
                    EditContactInAddressBook(contactName);
                }
            }
        }
        public void DeleteDictionary(string name2, string contactName)
        {
            foreach(var data in dict)
            {
                if (data.Key.Equals(name2))
                {
                    addressBook=data.Value;
                    DeleteContactFromAddressBook(contactName);
                }
            }
            dict.Remove(name2);
        }
    }
}

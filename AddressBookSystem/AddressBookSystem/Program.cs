using System;
using AddressBookSystem;
public class Program
{
    public static void Main(String[] args )
    {
        AddressBook addressBook = new AddressBook();
        bool end = true;
        Console.WriteLine("2.Add a new unique contact details\n2.Edit contact\n3.Delete Contact\n4.Add Multiple contacts\n5.Edit Dictionary\n6.Delete Dictionary");
        while ( end )
        {
            Console.WriteLine("Take an option to execute");
            int option = Convert.ToInt32( Console.ReadLine());
            switch( option )
            {
                case 1:
                    Console.WriteLine("Enter teh first name");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Enter the last name");
                    string lastName = Console.ReadLine();
                    addressBook.AddNewUniqueContactToAddressBook(firstName, lastName);
                    break;
                case 2:
                    Console.WriteLine("Enter the firstName to edit");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the last name");
                    string name2 = Console.ReadLine();
                    addressBook.EditContactInAddressBook(name,name2);
                    break;
                case 3:
                    Console.WriteLine("Enter the name to delete");
                    string name1 = Console.ReadLine();
                    addressBook.DeleteContactFromAddressBook( name1 );
                    break;
                case 4:
                    Console.WriteLine("Enter the Address Book to add");
                    string dictName = Console.ReadLine();
                    addressBook.AddDictionary(dictName);
                    break;
                case 5:
                    Console.WriteLine("Enter the Dictionary and Name to Edit Dictionary");
                    string name3 = Console.ReadLine();
                    string contactName=Console.ReadLine();
                    addressBook.EditDictionary(name3,contactName);
                    break;
                case 6:
                    Console.WriteLine("Enter the Dictionary and Name to Delete Dictionary");
                    string name4 = Console.ReadLine();
                    string deleteDict = Console.ReadLine();
                    addressBook.DeleteDictionary(name4,deleteDict);
                    break;
                case 7:
                    Console.WriteLine("Enter a valid Choice");
                    break;
                    default: end = false;
                    break;
            }
        }
    }
}
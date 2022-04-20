using System;
using AddressBookSystem;
public class Program
{
    public static void Main(String[] args )
    {
        AddressBook addressBook = new AddressBook();
        bool end = true;
        Console.WriteLine("1.Add new contact");
        while ( end )
        {
            Console.WriteLine("Take an option to execute");
            int option = Convert.ToInt32( Console.ReadLine());
            switch( option )
            {
                case 1:
                    Console.WriteLine("Enter the details: 1.First Name 2.Last Name 3.Address 4.City 5.State 6.Zip Code 7.Phone number 8.EmailId");
                    addressBook.Display();
                    break;
                    case 2:
                    Console.WriteLine("Enter the name to edit");
                    string name = Console.ReadLine();
                    addressBook.EditContactInAddressBook( name );
                    break;
                    case 3: 
                    default: end = false;
                    break;
            }
        }
    }
}
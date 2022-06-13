using System;
using AddressBookSystem;
public class Program
{
    public static void Main(String[] args )
    {
        AddressBook addressBook = new AddressBook();
        bool end = true;
        Console.WriteLine("1.Add a new unique contact details\n2.Display" +
            "\n3.Edit contact\n4.Delete Contact\n5.Add Multiple contacts" +
            "\n6.Edit Dictionary\n7.Delete Dictionary\n8.Search a person in a city" +
            "\n9.View all the persons by City\n10.View all the persons by State\n11.View number of person in a city" +
            "\n12.Sort entries by person name\n13.Sort Entries by city or state\n14.Read or Write Adress book" +
            "\n15.Read or Write CSV File\n16.Read or Write JSON file\n17.Retrive Entries from DataBase");
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
                    addressBook.AddNewUniqueContactDetailsToAddressBook(firstName, lastName);
                    break;
                case 2:
                    addressBook.Display();
                    break;
                case 3:
                    Console.WriteLine("Enter the firstName to edit");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the last name");
                    string name2 = Console.ReadLine();
                    addressBook.EditContactInAddressBook(name,name2);
                    break;
                case 4:
                    Console.WriteLine("Enter the name to delete");
                    string name1 = Console.ReadLine();
                    addressBook.DeleteContactFromAddressBook( name1 );
                    break;
                case 5:
                    Console.WriteLine("Enter the Address Book to add");
                    string dictName = Console.ReadLine();
                    addressBook.AddDictionary(dictName);
                    break;
                case 6:
                    Console.WriteLine("Enter the Dictionary and Name to Edit Dictionary");
                    string name3 = Console.ReadLine();
                    string contactName=Console.ReadLine();
                    addressBook.EditDictionary(name3,contactName);
                    break;
                case 7:
                    Console.WriteLine("Enter the Dictionary and Name to Delete Dictionary");
                    string name4 = Console.ReadLine();
                    string deleteDict = Console.ReadLine();
                    addressBook.DeleteDictionary(name4,deleteDict);
                    break;
                case 8:
                    Console.WriteLine("City Name");
                    string cityName = Console.ReadLine();
                    addressBook.SearchPersonInCity(cityName);
                    break;
                case 9:
                    Console.WriteLine("Enter the name of a city");
                    string nameOfCity = Console.ReadLine();
                    addressBook.ViewPersonByCity(nameOfCity);
                    break;
                case 10:
                    Console.WriteLine("Enter the name of the state");
                    string nameOfState = Console.ReadLine();
                    addressBook.ViewPersonByState(nameOfState);
                    break;
                case 11:
                    addressBook.PersonCountByCity();
                    break;
                case 12:
                    addressBook.SortEntriesByPersonName();
                    break;
                case 13:
                    addressBook.SortEntriesByStateOrCity();
                    break;
                case 14:
                    addressBook.ReadOrWriteAddressBook();
                    break;
                case 15:
                    addressBook.ReadOrWriteCSVFile();
                    break;
                case 16:
                    addressBook.ReadOrWriteJSONFile();
                    break;
                case 17:
                    addressBook.RetriveEntriesFromDB();
                    break;
                case 18:
                    Contact contact = new Contact();
                    Console.WriteLine("Enter First Name, Id , City , Zipcode to Update");
                    contact.FirstName = Console.ReadLine();
                    contact.Id = Convert.ToInt32(Console.ReadLine());
                    contact.City = Console.ReadLine();
                    contact.ZipCode = Convert.ToInt32(Console.ReadLine());
                    addressBook.UpdateContactOfDB(contact);
                    break;
                case 19:
                    Console.WriteLine("Enter a valid Choice");
                    break;
                    default: end = false;
                    break;
            }
        }
    }
}
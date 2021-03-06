using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBook
    {
        private SqlConnection connect;
        List<Contact> addressBook = new List<Contact>();
        Dictionary<string,List<Contact>> dictionary = new Dictionary<string,List<Contact>>();
        const string TXT_FILE_PATH = @"D:\PracticeProblem\AddressBookSystem\AddressBookSystem\AddressBookSystem\AddressBook1.txt";
        const string CSV_FILEPATH_IMPORT = @"D:\PracticeProblem\AddressBookSystem\AddressBookSystem\AddressBookSystem\AddressBookImport.csv";
        const string CSV_FILEPATH_EXPORT = @"D:\PracticeProblem\AddressBookSystem\AddressBookSystem\AddressBookSystem\AddressBookExport.csv";
        const string JSON_FILEPATH_EXPORT = @"D:\PracticeProblem\AddressBookSystem\AddressBookSystem\AddressBookSystem\AddressbookExport1.json";
        public AddressBook()
        {
            Contact address1 = new Contact()
            {
                FirstName = "Arpan",
                LastName = "Suji",
                Address = "Jaldhaka",
                City = "Kolkata",
                State = "West Bengal",
                EmailId = "abc@gmai.com",
                ZipCode = 734503,
                PhoneNumber = 9546112345,
            };
            Contact address2 = new Contact()
            {
                FirstName = "Raju",
                LastName = "Gupta",
                Address = "Kalimpong",
                City = "Hyderabad",
                State = "Telengana",
                EmailId = "abc@gmail.com",
                ZipCode = 734003,
                PhoneNumber = 25646789,
            };
            addressBook.Add(address1);
            addressBook.Add(address2);
        }
        private void Connection()
        {
            string connectingString = "Data Source=(localdb)\\MSSQLLocaldb;Initial Catalog=AddressBookDB";
            connect = new SqlConnection(connectingString);
        }
        public void AddNewUniqueContactDetailsToAddressBook(string firstName,string lastName)
        {
            foreach (Contact contact in addressBook)
            {
                if(contact.FirstName == firstName && contact.LastName==lastName)
                {
                    Console.WriteLine("********WARNING*********\nIt is a Duplicate Name\nEnter the adresss with different Name of a person");
                    EditContactInAddressBook(firstName, lastName);
                }
                else
                {
                    Display();
                }
            }
        }
        public void Display()
        {
            foreach(Contact contact in addressBook)
            {
                Console.WriteLine("The Contact Details:");
                Console.WriteLine("1.First Name: "+contact.FirstName+"\n2.Last Name: "+contact.LastName+"\n3.Address: "+contact.Address+"\n4.City: "+contact.City+"\n5.State: "+contact.State+"\n6.Zip Code: "+contact.ZipCode+"\n7.Phone Number: "+contact.PhoneNumber+"\n8.Email-ID: "+contact.EmailId+"\n");
            }
        }
        public void EditContactInAddressBook(string firstName,string lastName)
        {
            foreach (Contact contact in addressBook)
            {
                if (contact.FirstName.Equals(firstName) && contact.LastName.Equals(lastName))
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
            foreach(Contact contact in addressBook)
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
            foreach(var data in dictionary.Keys)
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
            if (dictionary==null)
            {
                dictionary.Add(name, addressBook);
                return;
            }
            if (NameExist(name)==false)
            {
                dictionary.Add(name,addressBook);
            }
            Display();
        }
        public void EditDictionary(string name1, string contactName)
        {
            foreach(var data in dictionary)
            {
                if (data.Key.Equals(name1))
                {
                    addressBook = data.Value;
                }
            }
            EditContactInAddressBook(name1,contactName);
            Display();
        }
        public void DeleteDictionary(string name2, string contactName)
        {
            foreach(var data in dictionary)
            {
                if (data.Key.Equals(name2))
                {
                    addressBook=data.Value;
                }
            }
            DeleteContactFromAddressBook(contactName);
            dictionary.Remove(name2);
            Display();
        }
        public void SearchPersonInCity(string cityName)
        {
            foreach(var list in addressBook)
            {
                if(list.City.Equals(cityName))
                {   
                        Console.WriteLine(list.FirstName + " " + list.LastName + " " +list.EmailId+" "+list.PhoneNumber+" "+list.City+" "+list.State+" "+list.ZipCode);   
                }
            }
        }
        public void ViewPersonByCity(string city)
        {
            var result = addressBook.Where(x => x.City.Equals(city)).ToList();
            foreach (var data in result)
            {
                Console.WriteLine(data.FirstName + " " + data.LastName + " " + data.PhoneNumber + " " + data.Address + " " + data.EmailId + " " + data.State + " " + data.ZipCode); 
            }
        }
        public void ViewPersonByState(string state)
        {
            var result = addressBook.Where(x => x.State.Equals(state)).ToList();
            foreach (var data in result)
            {
                Console.WriteLine(data.FirstName + " " + data.LastName + " " + data.PhoneNumber + " " + data.Address + " " + data.EmailId + " " + data.State + " " + data.ZipCode);
            }
        }
        public void PersonCountByCity()
        {
            int count = 0;
            Console.WriteLine("Enter the name of the city");
            string nameOfCity = Console.ReadLine();
            foreach (var data in addressBook)
            {
                if (data.City.Contains(nameOfCity))
                {
                    count++;
                }
            }
            Console.WriteLine(count+" "+"Persons are in there in "+nameOfCity+" "+"city");
        }
        public void SortEntriesByPersonName()
        {
            var result = addressBook.OrderBy(x=>x.FirstName).ToList();
            foreach (var data in result)
            {
                Console.WriteLine(data.FirstName + " " + data.LastName + " " + data.PhoneNumber+" "+data.Address+" "+data.EmailId+" "+data.State+" "+data.ZipCode);
            }
        }
        public void SortEntriesByStateOrCity()
        {
            Console.WriteLine("1.Sorting by City name\n2.Sorting by State name");
            bool check = true;
            while(check)
            {
                Console.WriteLine("Enter your choice:");
                int opt = Convert.ToInt32(Console.ReadLine());
                switch(opt)
                {
                    case 1:
                        var result = addressBook.OrderBy(x => x.City).ToList();
                        foreach(var data in result)
                        {
                            Console.WriteLine(data.FirstName + " " + data.LastName + " " + data.PhoneNumber + " " + data.Address + " " + data.EmailId + " " + data.State + " " + data.ZipCode);
                        }
                        break;
                    case 2:
                        var value = addressBook.OrderBy(x => x.State).ToList();
                        foreach (var data in value)
                        {
                            Console.WriteLine(data.FirstName + " " + data.LastName + " " + data.PhoneNumber + " " + data.Address + " " + data.EmailId + " " + data.State + " " + data.ZipCode);
                        }
                        break;
                }
            }
        }
        public void ReadOrWriteAddressBook()
        {
            if (File.Exists(TXT_FILE_PATH))
            {
                StreamReader reader = new StreamReader(TXT_FILE_PATH);
                try
                {
                    string s = "";
                    while ((s = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    reader.Close();
                }
            }
        }
        public void ReadOrWriteCSVFile()
        {
            using (var reader = new StreamReader(CSV_FILEPATH_IMPORT))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Contact>().ToList();
                    Console.WriteLine("After Reading CSV File");
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.FirstName + " " + data.LastName + " " + data.Address + " " + data.City + " " + data.State + " " + data.EmailId + " " + data.ZipCode+" "+data.PhoneNumber);
                    }
                    using (var writter = new StreamWriter(CSV_FILEPATH_EXPORT))
                    {
                        using (var csvExport = new CsvWriter(writter, CultureInfo.InvariantCulture))
                        {
                            csvExport.WriteRecords(records);
                        }
                    }
                }
            }
        }
        public void ReadOrWriteJSONFile()
        {
            using (var reader = new StreamReader(CSV_FILEPATH_IMPORT))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Contact>().ToList();
                    Console.WriteLine("After Reading CSV File");
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.FirstName + " " + data.LastName + " " + data.Address + " " + data.City + " " + data.State + " " + data.EmailId + " " + data.ZipCode + " " + data.PhoneNumber);
                    }
                    JsonSerializer serializer = new JsonSerializer();
                    using (var writter = new StreamWriter(JSON_FILEPATH_EXPORT))
                    {
                        using (var writer = new JsonTextWriter(writter))
                        {
                            serializer.Serialize(writter, records);
                        }
                    }
                }
            }
        }
        public void RetriveEntriesFromDB()
        {
            Connection();
            SqlCommand command = new SqlCommand("spGetAllEntries", connect);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            connect.Open();
            adapter.Fill(dataTable);
            connect.Close();
            foreach(DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["FirstName"]+", "+row["LastName"]+", "+row["Address"]+", "+row["City"]+", "+row["State"]+", "+row["EmailId"]+", "+row["ZipCode"]+", "+row["PhoneNumber"]);  
            }
        }
        public bool UpdateContactOfDB(Contact contact)
        {
            Connection();
            SqlCommand command = new SqlCommand("spUpdateContacts",connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", contact.Id);
            command.Parameters.AddWithValue("@FirstName", contact.FirstName);
            command.Parameters.AddWithValue("@City", contact.City);
            command.Parameters.AddWithValue("@ZipCode", contact.ZipCode);
            connect.Open();
            int result = command.ExecuteNonQuery();
            connect.Close();
            if(result >= 1)
            {
                Console.WriteLine("Contacts updated successfully");
                return true;
            }

            else
            {
                Console.WriteLine("Could not update");
                return false;
            }
        }
        public void GetContactsFromDate(string query)
        {
            Connection();
            SqlCommand command = new SqlCommand(query, connect);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            connect.Open();
            adapter.Fill(table);
            connect.Close();
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine(row["FirstName"] + ", " + row["LastName"] + ", " + row["Address"] + ", " + row["City"] + ", " + row["State"] + ", " + row["EmailId"] + ", " + row["ZipCode"] + ", " + row["PhoneNumber"]);
            }
        }
        public void GetContactsByCity(string query)
        {
            Connection();
            SqlCommand command = new SqlCommand(query, connect);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            connect.Open();
            adapter.Fill(table);
            connect.Close();
            foreach(DataRow row in table.Rows)
            {
                Console.WriteLine(row["City"]+" "+row["cityCount"]);
            }
        }
        public void AddNewContact(Contact contact)
        {
            Connection();
            SqlCommand command = new SqlCommand("spAddContact", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", contact.Id);
            command.Parameters.AddWithValue("@FirstName", contact.FirstName);
            command.Parameters.AddWithValue("@LastName", contact.LastName);
            command.Parameters.AddWithValue("@Address", contact.Address);
            command.Parameters.AddWithValue("@City", contact.City);
            command.Parameters.AddWithValue("@State", contact.State);
            command.Parameters.AddWithValue("@EmailId", contact.EmailId);
            command.Parameters.AddWithValue("@ZipCode", contact.ZipCode);
            command.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
            connect.Open();
            var result = command.ExecuteNonQuery();
            connect.Close();
            if(result >= 1)
            {
                Console.WriteLine("Contact Details addded successfully");
            }
            else
            {
                Console.WriteLine("Could not add");
            }
        }
    }
}
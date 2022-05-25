﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBook
    {
        List<Contact> addressBook = new List<Contact>();
        Dictionary<string,List<Contact>> dictionary = new Dictionary<string,List<Contact>>();
        public AddressBook()
        {
            Contact address1 = new Contact()
            {
                FirstName = "Arpan",
                LastName = "Suji",
                Address = "Jaldhaka",
                City = "Darjeeling",
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
                City = "Darjeeling",
                State = "West Bengal",
                ZipCode = 734003,
                PhoneNumber = 25646789,
                EmailId ="abc@gmail.com",
            };
            addressBook.Add(address1);
            addressBook.Add(address2);
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
            Dictionary<string, string> personWithCity = new Dictionary<string, string>();
            //Console.WriteLine("Person\tCity");
            //Console.WriteLine();
            personWithCity.Add("Arpan", "Darjeeling");
            personWithCity.Add("Ravi", "Kolkata");
            personWithCity.Add("Raju", "Siliguri");
            personWithCity.Add("Subham", "Malda");
            personWithCity.Add("Samir", "Hyderabad");
            personWithCity.Add("Ritesh", "Kolkata");
            foreach (var data in personWithCity)
            {
                //Console.WriteLine(data.Key+"\t"+ data.Value);
                if (city.Contains(data.Value))
                {
                    Console.WriteLine("The persons in the city are:" + data.Key + " ");
                }
            }
        }
        public void ViewPersonByState(string state)
        {
            Dictionary<string, string> personWithState = new Dictionary<string, string>();
            //Console.WriteLine("Person\tState");
            //Console.WriteLine();
            personWithState.Add("Arpan", "West Bengal");
            personWithState.Add("Ravi", "Jharkhand");
            personWithState.Add("Raju", "Telengana");
            personWithState.Add("Subham", "Maharastra");
            personWithState.Add("Samir", "West Bengal");
            personWithState.Add("Ritesh", "Telengana");
            foreach (var data in personWithState)
            {
                //Console.WriteLine(data.Key+"\t"+ data.Value);
                if (state.Contains(data.Value))
                {
                    Console.WriteLine("The persons in the State are:" + data.Key);
                }
            }
        }
    }
}

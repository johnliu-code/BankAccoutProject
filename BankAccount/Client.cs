using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;
using System.Globalization;

namespace BankAccount
{
    class Client
    {
        public string firstName;
        public string lastName;
        public string email;
        public string phone;
        public string address;
        public DateTime birthDate;

        public Client(string _firstname, string _lastname, string _email, string _phone, string _address, DateTime _birthdate)
        {
            firstName = _firstname;
            lastName = _lastname;
            email = _email;
            phone = _phone;
            address = _address;
            birthDate = _birthdate;
        }

        public Client(string _firstname, string _lastname)
        {
            firstName = _firstname;
            lastName = _lastname;
        }

        public Client (string _email, string _phone, string _address, DateTime _birthdate)
        {
            email = _email;
            phone = _phone;
            address = _address;
            birthDate = _birthdate;
        }

        public Client()  {  }

        //Getters and Setters
        public string GetFirstName() { return firstName; }
        public string GetLastName() { return lastName; }
        public string GetEmail() { return email; }
        public string GetPhone() { return phone; }
        public string GetAddress() { return address; }
        public DateTime GetBirthDate() { return birthDate; }

        public void SetFirstName (string _firstname) { firstName = _firstname; }
        public void SetLastName (string _lastname) { lastName = _lastname; }
        public void SetEmial (string _email) { email = _email; }
        public void SetPhone (string _phone) { phone = _phone; }
        public void SetAddress (string _address) { address = _address; }
        public void SetBirthDate (DateTime _birthdate) { birthDate = _birthdate; }

        //Method create Client
        public void CreateClient (Client client)
        {
            WriteLine("Your First Name? ");
            string firstname = ReadLine();
            client.SetFirstName(firstname);

            WriteLine("Your Lasst Name? ");
            string lastname = ReadLine();
            client.SetLastName(lastname);

            WriteLine("Your Email? ");
            string email = ReadLine();
            client.SetEmial(email);

            WriteLine("Your Phone Number? ");
            string phone = ReadLine();
            client.SetPhone(phone);

            WriteLine("Your Address? Street number Street Name, City, Province, Post Code");
            string address = ReadLine();
            client.SetAddress(address);

            WriteLine("Your Date of Birth? yyyy-mm-dd");
            var cultureInfo = new CultureInfo("en-EN");
            string inputDate = ReadLine();
            string formatDate = "yyyy-mm-dd";
            DateTime birthdate = DateTime.ParseExact(inputDate, formatDate, cultureInfo);
            client.SetBirthDate(birthdate);
        }

        //Method display Client
        public void DisplayClient (Client client)
        {
            WriteLine($"Client First Name: {client.GetFirstName()}");
            WriteLine($"Client Last Name: {client.GetLastName()}");
            WriteLine($"Client Email: {client.GetEmail()}");
            WriteLine($"Client Phone Number: {client.GetPhone()}");
            WriteLine($"Client Address: {client.GetAddress()}");
            WriteLine($"Client Birth Date: {client.GetBirthDate().ToShortDateString()}");
        }

        //Method update Client
        public void UpdateClient(Client client)
        {
            WriteLine($"Please entre New First Name: ");
            string firstname = ReadLine();
            client.SetFirstName(firstname);

            WriteLine($"Please entre New Last Name: ");
            string lastname = ReadLine();
            client.SetLastName(lastname);

            WriteLine($"Please entre New Email: ");
            string email = ReadLine();
            client.SetEmial(email);

            WriteLine($"Please entre New Phone Number: +1-000-000-0000 ");
            string phone = ReadLine();
            client.SetPhone(phone);

            WriteLine($"Please entre New Address: 000 XXX Street, XXX city, XX province, XXX 1X1");
            string address = ReadLine();
            client.SetAddress(address);

            WriteLine($"Please entre New Birth Date: yyyy-mm-dd");
            var cultureInfo = new CultureInfo("en-EN");
            string inputDate = ReadLine();
            string formatDate = "yyyy-mm-dd";
            DateTime birthdate = DateTime.ParseExact(inputDate, formatDate, cultureInfo);
            client.SetBirthDate(birthdate);
        }
    }

}

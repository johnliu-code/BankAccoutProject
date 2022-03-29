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
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string address;
        private string birthDate;
        private double clientId = 0;

       // private Account account;

        List<Client> listClients = new List<Client>();

        public Client(string _firstname, string _lastname, string _email, string _phone, string _address, string _birthdate, double _clientId)
        {
            firstName = _firstname;
            lastName = _lastname;
            email = _email;
            phone = _phone;
            address = _address;
            birthDate = _birthdate;
            clientId = _clientId;
        }

        public Client(string _firstname, string _lastname)
        {
            firstName = _firstname;
            lastName = _lastname;
        }

        public Client (string _email, string _phone, string _address, string _birthdate)
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
        public string GetBirthDate() { return birthDate; }
        public double GetClientId() { return clientId; }

        public void SetFirstName (string _firstname) { firstName = _firstname; }
        public void SetLastName (string _lastname) { lastName = _lastname; }
        public void SetEmial (string _email) { email = _email; }
        public void SetPhone (string _phone) { phone = _phone; }
        public void SetAddress (string _address) { address = _address; }
        public void SetBirthDate (string _birthdate) { birthDate = _birthdate; }
        public void SetClientId(double _clientId) { clientId = _clientId; }

        //Method create Client
        public void CreateClient (Client client)
        {
           // client = new Client();

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
            string birthdate = ReadLine();
            client.SetBirthDate(birthdate);

            //Add client info to the List
            listClients.Add(client);
            WriteLine(listClients.Count);
        }

        //Method display Client
        public void DisplayClient (Client client)
        {
            WriteLine($"Client First Name: {client.GetFirstName()}");
            WriteLine($"Client Last Name: {client.GetLastName()}");
            WriteLine($"Client Email: {client.GetEmail()}");
            WriteLine($"Client Phone Number: {client.GetPhone()}");
            WriteLine($"Client Address: {client.GetAddress()}");
            WriteLine($"Client Birth Date: {client.GetBirthDate()}");
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
            string birthdate = ReadLine();
            client.SetBirthDate(birthdate);
        }

        //Delete Client
        public void deleteClient (Client client)
        {

            WriteLine("Please entre Client Email you want to delete:  ");
            string emailDel = ReadLine();

            WriteLine(listClients.Count);
            for (int i = 0; i < listClients.Count; i++)
            {
                    WriteLine(emailDel);
                    WriteLine(listClients[i].GetEmail());
                if (listClients[i].GetEmail() == emailDel)
                {
                    client = listClients[i];
                    listClients.Remove(client);
                }
            }
            WriteLine(listClients.Count);
        }
    }

}

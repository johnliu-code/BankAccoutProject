using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace BankAccount
{
    class Account
    {
        private Client client;

        private double accountNumber;
        private string password;

        private DateTime openDate;
        private bool accoutActivated = true;
        private bool userLogined = false;

        List<Client> listClients = new List<Client>();
        List<Account> listAccounts = new List<Account>();

        MethodLab myMethod = new MethodLab();

        //Constructor
        public Account(Client _client, double _accountNumber, string _password,  DateTime _openDate)
        {
            client = _client;
            accountNumber = _accountNumber;
            password = _password;
            openDate = _openDate;
        }

        public Account(Client _client, double _accountNumber, string _password)
        {
            client = _client;
            accountNumber = _accountNumber;
            password = _password;
        }

        public Account(double _accountNumber, string _password)
        {
            accountNumber = _accountNumber;
            password = _password;
        }


        public Account () {}

        //Getter and Setters
        public Client GetClientInfo () { return client; }
        public double GetAccountNumber() { return accountNumber; }
        public string GetPassWord() { return password; }     
        public DateTime GetOpenDate() { return openDate; }
        public bool GetUserLogined() { return userLogined; }
        public bool GetAccoutActivated() { return accoutActivated; }

        public void setClient (Client _client) { client = _client; }
        public void setAccountNumber(double _accountNumber) { accountNumber = _accountNumber; }
        public void setPassWord(string _password) { password = _password; }
        public void setOpenDate(DateTime _openDate) { openDate = _openDate; }
        public void setUserLogined(bool _userLogined) { userLogined = _userLogined; }
        public void setAccoutActivated(bool _accoutActivated) { accoutActivated = _accoutActivated; }


        //Method create Acccount (Set Client Acoount number and password)
        public Account CreateAccount(List<Account> listAccounts, Client client)
        {
            //Add client info to the List
            client = client.CreateClient(client);

            var randomNumber = new Random();
            accountNumber = randomNumber.Next(10000000, 99999999);          //Generate radom Bank Account Number

            client.SetClientId(accountNumber);
            listClients.Add(client);
            WriteLine($"Total Client: {listClients.Count}");

            WriteLine($"Your Bank Account Number is : {accountNumber}; \nPlease take a note to keep your Bank Account Number safelly, and entre your PassWord:");
            password = ReadLine();
            openDate = DateTime.Now;

            Account account = new Account();                                //Create Account and set initial values
            account.setClient(client);
            account.setAccountNumber(accountNumber);
            account.setPassWord(password);
            account.setOpenDate(openDate);
            account.setAccoutActivated(true);
            listAccounts.Add(account);

            WriteLine($"Client Name: {client.GetFirstName()}, {client.GetLastName()}; Account Number: {account.GetAccountNumber()}; Open Date: {account.GetOpenDate().ToString()}");

            WriteLine("Your Banck Account successfully created! Enjoy our Bank Services!!!");
            WriteLine($"Total account: {listAccounts.Count}");
            return account;
        }


        //Method update Acccount password
        public void changePassWord (Account account)
        {
            if (!userLogined)
            {
                account = userLogin(client, account);
            }
            else
            {
                WriteLine($"You are going to change the Password for this Account Number: {account.GetAccountNumber()}, please entre your new Password: ");
                string newPassword = ReadLine();
                account.setPassWord(newPassword);
            }

            WriteLine($"Your Account {account.GetAccountNumber()} Password has been updated!!");
        }

        //Client user login
        public Account userLogin (Client client, Account account)
        {
            if (account.GetAccountNumber() == 0)
            {
                WriteLine($"Your don't have an Account yet, please open one !!");
            } else
            {
                string messaage = "Please insert your Bank Card or Entre your Bank Account Number for Login: ";
                double inputValue = 0;
                accountNumber = myMethod.validDouble(inputValue, messaage);

                WriteLine(account.accountNumber);
                WriteLine(accountNumber);
                for (int i = 0; i < listAccounts.Count; i++)
                {
                    WriteLine(listAccounts[i].GetAccountNumber());
                    WriteLine(account.GetAccountNumber());
                }

                if (account.GetAccountNumber() == accountNumber)
                {
                    WriteLine("Please entre your Password: ");
                    password = ReadLine();

                    if (password == account.GetPassWord())
                    {
                        //Get to match client
                        for (int i = 0; i < listClients.Count; i++)
                        {
                            if (listClients[i].GetClientId() == accountNumber)
                                client = listClients[i];
                        }

                        for (int j = 0; j < listAccounts.Count; j++)
                        {
                            if (listAccounts[j].GetAccountNumber() == accountNumber)
                                account = listAccounts[j];
                        }

                        if (accoutActivated)
                        {
                            userLogined = true;
                            account.setUserLogined(userLogined);
                            WriteLine($"Client: {client.GetFirstName()} {client.GetLastName()}, has already Logined into Account: {account.GetAccountNumber()}");
                        }
                        else
                        {
                            WriteLine("You don't have account or the account has been closed, please open your account!!");
                        }

                    }
                    else
                    {
                        WriteLine("Invalid Password for this Account, Please try again!!");
                        return userLogin(client, account);
                    }
                }
                else
                {
                    WriteLine("Invalid Account Number, Please try again!!");
                    return userLogin(client, account);
                }
            }

            return account;
        }

        //Close Account
        public void closeAccount (Account account)
        {
            WriteLine($"Are you sure want to Close your Account : {account.GetAccountNumber()}? Y/N");
            string answer = ReadLine().ToUpper();

            if (answer == "Y")
            {
                account.setAccoutActivated(false);
            }
        }
    }
}

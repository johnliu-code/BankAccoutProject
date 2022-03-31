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
        private bool accoutActivated = false;
        private bool userLogined = false;

       // List<Client> listClients = new List<Client>();
      //  List<Account> listAccounts = new List<Account>();

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
        public Account CreateAccount(Account account, Client client)
        {
            //Add client info to the List
            client = client.CreateClient(client);

            var randomNumber = new Random();
            accountNumber = randomNumber.Next(10000000, 99999999);          //Generate radom Bank Account Number

            client.SetClientId(accountNumber);

            WriteLine($"Your Bank Account Number is : {accountNumber}; \nPlease take a note to keep your Bank Account Number safelly, and entre your PassWord:");
            password = ReadLine();
            openDate = DateTime.Now;

            account = new Account();                                //Create Account and set initial values
            account.setClient(client);
            account.setAccountNumber(accountNumber);
            account.setPassWord(password);
            account.setOpenDate(openDate);
            account.setAccoutActivated(true);

            WriteLine($"Client Name: {client.GetFirstName()}, {client.GetLastName()}; Account Number: {account.GetAccountNumber()}; Open Date: {account.GetOpenDate().ToString()}");
            WriteLine("Your Banck Account successfully created! Enjoy our Bank Services!!!");
           
            return account;
        }


        //Method update Acccount password
        public void changePassWord (Account account)
        {
            if (!userLogined)
            {
                userLogin(account);
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
        public Account userLogin(Account account)
        {
            if (!account.GetAccoutActivated())
            {
                WriteLine($"Your don't have an Account yet, please open one !!");
            } else
            {
                double recentClientAccountNum = account.GetAccountNumber();
                string recentAccountPassword = account.GetPassWord();

                string messaage = "Please insert your Bank Card or Entre your Bank Account Number for Login: ";
                double inputValue = 0;
                accountNumber = myMethod.validDouble(inputValue, messaage);

                WriteLine("Please entre your Password: ");
                password = ReadLine();

                //Get to match client

                if (recentClientAccountNum == accountNumber && recentAccountPassword == password)
                {
                    if (account.GetAccoutActivated() == true)
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
                    WriteLine("Invalid Account Number or Password, Please try again!!");
                }
            }

            return account;
        }

        //Close Account
        public void closeAccount (Account account)
        {
            string answer = "Y";
            string message = $"Are you sure want to Close your Account : {account.GetAccountNumber()}? Y/N";
            answer = myMethod.validYorN(answer, message);

            if (answer == "Y")
            {
                account.setAccoutActivated(false);
            }
        }
    }
}

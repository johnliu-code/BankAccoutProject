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
        private bool userLogined = false;

        List<Account> listAccounts = new List<Account>();

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

        public void setClient (Client _client) { client = _client; }
        public void setAccountNumber(double _accountNumber) { accountNumber = _accountNumber; }
        public void setPassWord(string _password) { password = _password; }
        public void setOpenDate(DateTime _openDate) { openDate = _openDate; }
        public void setUserLogined(bool _userLogined) { userLogined = _userLogined; }


        //Method create Acccount (Set Client Acoount number and password)
        public void CreateAccount (Client client)
        {
            var randomNumber = new Random();
            accountNumber = randomNumber.Next(10000000, 99999999);          //Generate radom Bank Account Number
            client.SetClientId(accountNumber);

            WriteLine($"Your Bank Account Number is : {accountNumber}; \nPlease take a note to keep your Bank Account Number safelly, and entre your PassWord:");
            password = ReadLine();
            openDate = DateTime.Now;

            Account account = new Account();                                //Create Account and set initial values
            account.setAccountNumber(accountNumber);
            account.setPassWord(password);
            account.setOpenDate(openDate);

            WriteLine($"Client Name: {client.GetFirstName()}, {client.GetLastName()}; Account Number: {account.GetAccountNumber()}; Open Date: {account.GetOpenDate().ToString()}");
            listAccounts.Add(account);
            WriteLine(listAccounts.Count);

            WriteLine("Your Banck Account successfully created! Enjoy our Bank Services!!!");
        }

        //Find account with user info
        public void dispalyAccountInfo(Account account)
        {
            for (int i = 0; i <= listAccounts.Count; i++)
            {
                if (account.GetAccountNumber() == listAccounts[i].GetAccountNumber())
                    WriteLine($"Account Number: {listAccounts[i].GetAccountNumber()}");
                else
                    WriteLine($"Account: {account.GetAccountNumber()} is not exisits!!");
            } 
        }

        //Delete account from list
        public void deleteAccountList (Account account)
        {
            WriteLine("Please entre Account Number you want to delete:  ");
            double accountnumber = ToDouble(ReadLine());

            for (int i = 0; i < listAccounts.Count; i++)
            {
                if ( listAccounts[i].GetAccountNumber() == accountnumber)
                {
                    account = listAccounts[i];
                    listAccounts.Remove(account);
                }
 
            }
            WriteLine(listAccounts.Count);
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
            WriteLine("Please insert your Bank Card or Entre your Bank Account Number: ");
            accountNumber = System.Convert.ToDouble(ReadLine());

            if (accountNumber == account.GetAccountNumber())
            {
                WriteLine("Please entre your Password: ");
                password = ReadLine();

                if (password == account.GetPassWord())
                {
                    WriteLine($"Welcome {client.GetFirstName()} {client.GetLastName()}!! You have already successfully login to your Bank Account, the Account Number is : {account.GetAccountNumber()}");
                    userLogined = true;
                    account.setUserLogined(userLogined);
                } else
                {
                    WriteLine("Invalid Password for this Account, Please try again!!");
                    return userLogin(client, account);
                }
            } else
            {
                WriteLine("Invalid Account Number, Please try again!!");
                return userLogin(client, account);
            }
            return account;
        }
    }
}

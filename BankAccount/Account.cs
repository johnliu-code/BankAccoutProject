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
        private DateTime closeDate;
        private bool accountActived = false;
        private bool userLogined = false;

        List<Account> listAccounts = new List<Account>();

        //Constructor
        public Account(Client _client, double _accountNumber, string _password,  DateTime _openDate, bool _accountActived)
        {
            client = _client;
            accountNumber = _accountNumber;
            password = _password;
            openDate = _openDate;
            accountActived = _accountActived;
        }

        public Account(Client _client, double _accountNumber, string _password, bool _accountActived)
        {
            client = _client;
            accountNumber = _accountNumber;
            password = _password;
            accountActived = _accountActived;
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
        public DateTime GetCloseDate() { return closeDate; }
        public bool GetActivedStatus() { return accountActived; }
        public bool GetUserLogined() { return userLogined; }

        public void setClient (Client _client) { client = _client; }
        public void setAccountNumber(double _accountNumber) { accountNumber = _accountNumber; }
        public void setPassWord(string _password) { password = _password; }
        public void setOpenDate(DateTime _openDate) { openDate = _openDate; }
        public void setCloseDate(DateTime _closeDate) { closeDate = _closeDate; }
        public void setActived(bool _accountActived) { accountActived = _accountActived; }
        public void setUserLogined(bool _userLogined) { userLogined = _userLogined; }


        //Method create Acccount (Set Client Acoount number and password)
        public void CreateAccount (Client client)
        {
            client.CreateClient(client);
            client.DisplayClient(client);

            var randomNumber = new Random();
            accountNumber = randomNumber.Next(10000000, 99999999);          //Generate radom Bank Account Number

            WriteLine($"Your Bank Account Number is : {accountNumber}; \nPlease take a note to keep your Bank Account Number safelly, and entre your PassWord:");
            password = ReadLine();
            accountActived = true;
            openDate = DateTime.Now;

            Account account = new Account();                                //Create Account and set initial values
            account.setAccountNumber(accountNumber);
            account.setPassWord(password);
            account.setOpenDate(openDate);
            account.setActived(accountActived);

            WriteLine($"Client Name: {client.GetFirstName()}, {client.GetLastName()}; Account Number: {account.GetAccountNumber()}; Open Date: {account.GetOpenDate().ToString()}");

            if (accountActived)
            {
                WriteLine("Your Banck Account successfully created! Enjoy our Bank Services!!!");
            } else
            {
                WriteLine("Your Bank Account Faild to create! Please check the request information and try it again!");
            }

        }

        //Method to create a list for all of accouts of users
        public void addAccounts(Account account)
        {
            listAccounts.Add(account);
            WriteLine(listAccounts.Count);
        }

        //Find account with user info
        public Account findAccount(Account account, List<Account> listaccounts)
        {
            for (int i = 0; i <= listaccounts.Count; i++)
            {
                if (account.GetAccountNumber() == listaccounts[i].GetAccountNumber())
                    account = listaccounts[i];
                else
                    WriteLine($"Account: {account.GetAccountNumber()} is not exisits!!");
            } 
            return account;
        }

        //Delete account from list
        public void deleteAccountList (Account account, List<Account> listaccounts)
        {
            WriteLine("Please entre Account Number you want to delete:  ");
            double accountnumber = ToDouble(ReadLine());

            for (int i = 0; i <= listaccounts.Count; i++)
            {
                if (accountnumber == listaccounts[i].GetAccountNumber())

                    listaccounts.Remove(account);
                else
                    WriteLine($"Account: {account.GetAccountNumber()} is not exisits!!");
            }
        }

        //Method close Acccount
        public void CloseAccount (Client client, Account account)
        {
            //Verify Client and Account Number and Password to make sure it is the right Client and Account
            if (!userLogined)
            {
                account = userLogin(client, account);
            } else
            {
                WriteLine($"Are you sure you want to close this Account? Account Number: {account.GetAccountNumber()}, with Client Name: {client.GetFirstName()} {client.GetFirstName()}. Y/N? ");
                string answer = ReadLine().ToUpper();

                if (answer == "Y")
                    account.setActived(false);
                account.setCloseDate(DateTime.Now);
            }

            WriteLine($"Your Account {account.GetAccountNumber()} has been Closed at {account.GetCloseDate()}");
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

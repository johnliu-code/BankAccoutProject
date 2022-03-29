using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Globalization;
using static System.Convert;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bank account project for practice class in C#
            Client client = new Client();
            Account account = new Account();
            AccountTransit transit = new AccountTransit();

            List<Client> listClients = new List<Client>();
            List<Account> listaccounts = new List<Account>();
            List<AccountTransit> listTransits = new List<AccountTransit>();

            //Client 1
            client.CreateClient(client);
            client.DisplayClient(client);
            account.CreateAccount(client);
            ReadLine();

            transit.depositMoney(account, transit);
            ReadLine();
            transit.depositMoney(account, transit);
            ReadLine();
            transit.depositMoney(account, transit);
            ReadLine();

            transit.withdrawlMoney(account, transit);
            ReadLine();
            transit.withdrawlMoney(account, transit);
            ReadLine();
            transit.withdrawlMoney(account, transit);
            ReadLine();

            //Client 2

            client.CreateClient(client);
            client.DisplayClient(client);
            account.CreateAccount(client);
            ReadLine();

            //Client 3

            client.CreateClient(client);
            client.DisplayClient(client);
            account.CreateAccount(client);
            ReadLine();


            //History and statements
            transit.accountStatements(account, transit);
            ReadLine();
            transit.accountHistory(account, transit);
            ReadLine();

            transit.accountStatements(account, transit);
            ReadLine();
            transit.accountHistory(account, transit);
            ReadLine();

            //Test results
            for (int i = 0; i < listClients.Count; i++)
            {
                WriteLine($"first name: {listClients[i].GetFirstName()}");
            }

            for (int j = 0; j < listaccounts.Count; j++)
            {
                WriteLine($"first name: {listaccounts[j].GetAccountNumber()}");
            }


            for (int k = 0; k < listTransits.Count; k++)
            {
                WriteLine($"first name: {listTransits[k].GetBalance()}");
            }

            //Delete account
            client.deleteClient(client);
            ReadLine();
            account.deleteAccountList(account);
            ReadLine();
            transit.deleteRecords(account, transit);
            ReadLine();




            // CreateClient(client);
            // DisplayClient(client);

            // client.CreateClient(client);

            //Menu to Open or Close a ccount, Withdrawl Deposit money, check balance, history, etc.

        }
    }
}

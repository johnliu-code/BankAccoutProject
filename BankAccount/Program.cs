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


            client.CreateClient(client);
            client.DisplayClient(client);
            account.CreateAccount(client);
            ReadLine();

            client.CreateClient(client);
            client.DisplayClient(client);
            account.CreateAccount(client);
            ReadLine();

            client.CreateClient(client);
            client.DisplayClient(client);
            account.CreateAccount(client);
            ReadLine();

            client.deleteClient(client);
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


            transit.accountStatements(account, transit);
            ReadLine();

            transit.accountHistory(account, transit);
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

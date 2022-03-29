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
            List<Account> listaccounts = new List<Account>();
            List<AccountTransit> listTransits = new List<AccountTransit>();

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


            transit.accountStatements(account, transit);
            ReadLine();


            // CreateClient(client);
            // DisplayClient(client);

            // client.CreateClient(client);

            //Menu to Open or Close a ccount, Withdrawl Deposit money, check balance, history, etc.

        }
    }
}

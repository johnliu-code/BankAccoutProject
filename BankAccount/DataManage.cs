using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace BankAccount
{
    class DataManage
    {
        Client client = new Client();
        Account account = new Account();
        AccountTransit transit = new AccountTransit();

        List<Client> listClients = new List<Client>();
        List<Account> listAccounts = new List<Account>();
        List<AccountTransit> listTransits = new List<AccountTransit>();

        MethodLab myMethod = new MethodLab();

 

        //Delete account from list
        public void deleteAccountFromList(List<Account> listAccounts, Account account)
        {
            if (account.GetUserLogined())
            {
                for (int i = 0; i < listAccounts.Count; i++)
                {
                    if (listAccounts[i].GetAccountNumber() == account.GetAccountNumber())
                    {
                        account = listAccounts[i];
                        listAccounts.Remove(account);
                    }
                    else
                    {
                        WriteLine($"Account : {account.GetAccountNumber()} not found!!");
                    }
                }
                WriteLine(listAccounts.Count);

            }
            else
            {
                WriteLine("Please Login your account first!!");
                account.userLogin(account);
            }
        }

        //Delete client form clients list
        public void deleteCientFromList(Account account)
        {
            for (int i = 0; i < listClients.Count; i++)
            {
                if (listClients[i].GetClientId() == client.GetClientId())
                    client = listClients[i];
                listClients.Remove(client);
            }
            WriteLine(listClients.Count);
        }

        //Delete transits records from list
        public void deleteTransitsFromList(Account account)
        {
            for (int j = 0; j < listTransits.Count; j++)                          // remove transits records
            {
                if (listTransits[j].GetAccountId() == listAccounts[j].GetAccountNumber())
                    transit = listTransits[j];
                listTransits.Remove(transit);
            }
        }

        //Delete records
        public void deleteRecords(Account account, AccountTransit transit)
        {
            WriteLine($"Make sure you want to delete your Account: {account.GetAccountNumber()}? Y/N");
            string answer = ReadLine().ToUpper();
            if (account.GetAccountNumber() == transit.GetAccountId() && answer == "Y")
            {
                listTransits.Clear();
                WriteLine(listTransits.Count);
            }
        }

    }
}

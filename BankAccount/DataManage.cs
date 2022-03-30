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

        //Main menu
        public void mainMenu()
        {
            string backTomain = "Y";

            while (backTomain == "Y")
            {
                string message = "Please choose your Menu option: 1. Open Account; 2. Login Account; 3. Quit";
                int inputValue = 0;
                int mainMenuOption = myMethod.validInt(inputValue, message);
                switch (mainMenuOption)
                {
                    case 1:
                        account = account.CreateAccount(listAccounts, client);              //Creat Account set up client information
                        break;

                    case 2:
                        account = account.userLogin(client, account);                       //Login and start to deposit money

                        if (account.GetUserLogined() == true && account.GetAccoutActivated() == true)
                        {
                            subMenu();
                        }
                        else
                        {
                            WriteLine("Please Login your account first!!");
                        }
                        break;

                    case 3:
                        break;

                    default:
                        WriteLine("Please entre a int number between 1 to 3 !");
                        break;
                }

                if (mainMenuOption != 3)
                {
                    WriteLine("Back to Main Menu? Y/N");
                    backTomain = ReadLine().ToUpper();
                }
            }           
        }

        // Sub Menu when Cient login
        public void subMenu()
        {
            string backToAccountMenu = "Y";

            while (backToAccountMenu == "Y")
            {
                string message = "Please choose your Menu option: 1. Deposit; 2. Withdrawl; 3. History; 4. Statements; 5. Close Account; 6. LogOut and Quit";
                int inputValue = 0;
                int subMenuOption = myMethod.validInt(inputValue, message);
                switch (subMenuOption)
                {
                    case 1:
                        transit.depositMoney(account, transit);
                        break;

                    case 2:
                        transit.withdrawlMoney(account, transit);
                        break;

                    case 3:
                        transit.accountHistory(account, transit);
                        break;

                    case 4:
                        transit.accountStatements(account, transit);
                        break;

                    case 5:
                        account.closeAccount(account);
                        account.setUserLogined(false);
                        break;

                    case 6:
                        account.setUserLogined(false);
                        break;
                    default:
                        WriteLine("Please entre a int number between 1 to 6 !");
                        break;
                }

                if (subMenuOption != 6)
                {
                    WriteLine("Back to Account Menu? Y/N");
                    backToAccountMenu = ReadLine().ToUpper();
                }
            }
        }

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
                account = account.userLogin(client, account);
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

    }
}

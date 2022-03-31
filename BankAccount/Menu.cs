using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace BankAccount
{
    class Menu
    {
        // Menu and submenus
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
                string message = "Please choose your Menu option: 1. Open Account; 2. Login Account.";
                int inputValue = 0;
                int mainMenuOption = myMethod.validInt(inputValue, message);
                switch (mainMenuOption)
                {
                    case 1:
                        account = account.CreateAccount(account, client);              //Creat Account set up client information
                        break;

                    case 2:
                        account = account.userLogin(account);                       //Login and start to deposit money

                        if (account.GetUserLogined() == true && account.GetAccoutActivated() == true)
                        {
                            subMenu();
                        }
                        else
                        {
                            WriteLine("Please Login your account first!!");
                        }
                        break;

                    default:
                        WriteLine("Please entre a int number between 1 to 2 !");
                        break;
                }
                WriteLine("Back to Main Menu? Y/N");
                backTomain = ReadLine().ToUpper();
            }
        }

        // Sub Menu when Cient login
        public void subMenu()
        {
            string backToAccountMenu = "Y";

            while (backToAccountMenu == "Y")
            {
                string message = "Please choose your Menu option: 1. Deposit; 2. Withdrawl; 3. History; 4. Statements; 5. Update Account";
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
                        updateAccountMenu();
                        break;

                    default:
                        WriteLine("Please entre a int number between 1 to 6 !");
                        break;
                }

                WriteLine("Back to Account Menu? Y/N");
                backToAccountMenu = ReadLine().ToUpper();
            }
        }

        //Menu to update client account information
        public void updateAccountMenu()
        {
            string backToUpdateMenu = "Y";

            while (backToUpdateMenu == "Y")
            {
                string message = "Please choose your Menu option: 1. Update Client Info; 2. Change Password; 3. Close Account";
                int inputValue = 0;
                int subMenuOption = myMethod.validInt(inputValue, message);
                switch (subMenuOption)
                {
                    case 1:
                        client.UpdateClient(client);
                        break;

                    case 2:
                        account.changePassWord(account);
                        break;

                    case 3:
                        account.closeAccount(account);
                        account.setUserLogined(false);
                        break;

                    default:
                        WriteLine("Please entre a int number between 1 to 6 !");
                        break;
                }

                WriteLine ("Back to Update Menu? Y/N");
                backToUpdateMenu = ReadLine().ToUpper();
            }
        }
    }
}

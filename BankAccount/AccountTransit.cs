using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace BankAccount
{
    class AccountTransit
    {
        //Oprate accounts data
        private Client client;
        private Account account;

        private double accountId;
        private double balance = 0;
        private double withdrawl = 0;
        private double deposit = 0;
        private DateTime transDate;

        private bool transStatusActived = false;

       List<AccountTransit> listTransits = new List<AccountTransit>();

        public AccountTransit (Account _account, double _accountid, double _balance, double _withdrawl, double _deposit, DateTime _transDate)
        {
            account = _account;
            accountId = _accountid;
            balance = _balance;
            withdrawl = _withdrawl;
            deposit = _deposit;
            transDate = _transDate;
        }

        public AccountTransit() {}

        public double GetAccountId() { return accountId; }
        public double GetBalance() { return balance; }
        public double GetWithdrawl() { return withdrawl; }
        public double GetDeposit() { return deposit; }
        public DateTime GetTransitDate() { return transDate; }

        public void setAccountId(double _accountid) { accountId = _accountid; }
        public void setBlance(double _balance) { balance = _balance; }
        public void setWithdrawl(double _withdrawl) { withdrawl = _withdrawl; }
        public void setDeposit(double _deposit) { deposit = _deposit; }
        public void setTransitionDate(DateTime _transDate) { transDate = _transDate; }

        //Method deposit money to Acccount
        public void depositMoney(Account account, AccountTransit transit)
        {
            WriteLine($"Insert or input amount of money you want deposit to this Account Number: {account.GetAccountNumber()}");

            string inputValue = ReadLine();
            deposit = ToDouble(inputValue);
            withdrawl = 0;
            transDate = DateTime.Now;
            balance = balance + deposit - withdrawl;

            transit = new AccountTransit();
            transit.setDeposit(deposit);
            transit.setBlance(balance);
            transit.setWithdrawl(withdrawl);
            transit.setTransitionDate(transDate);

            dispalyTransit(transit);

         //   List<AccountTransit> listTransits = new List<AccountTransit>();
            listTransits.Add(transit);
            WriteLine(listTransits.Count);

        }

        //Method withdrawl money from Acccount
        public void withdrawlMoney(Account account, AccountTransit transit)
        {
            WriteLine($"Please entre amount of money you want withdrawl from this Account Number: {account.GetAccountNumber()}");

            string inputValue = ReadLine();
            withdrawl = ToDouble(inputValue);
            deposit = 0;
            transDate = DateTime.Now;
            balance = balance + deposit - withdrawl;

            transit = new AccountTransit();
            transit.setDeposit(deposit);
            transit.setBlance(balance);
            transit.setWithdrawl(withdrawl);
            transit.setTransitionDate(transDate);

            dispalyTransit(transit);
            WriteLine("Confirm to submit this deposit? Y/N");
              string ans = ReadLine().ToUpper();
              if (ans == "Y")
            {
                listTransits.Add(transit);
            }
            for (int i = 0; i < listTransits.Count; i++)
            {
                WriteLine(listTransits[i].GetBalance());
            }
        }

        //Method to check Acccount status 

        //Method to print Acccount history

        //Display transit record
        public void dispalyTransit (AccountTransit transit)
        {
   
            WriteLine($"Tranist time: {transit.GetTransitDate(),-10} Deposit: {transit.GetDeposit(),-8} Withdrawl: {transit.GetWithdrawl(),-8} Balance: {transit.GetBalance(),-8}");
        } 

    }
}

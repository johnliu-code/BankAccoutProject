using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;
using System.Globalization;

namespace BankAccount
{
    class AccountTransit
    {
        //All of account transitions data
        private Account account;

        private double accountId;
        private double balance = 0;
        private double withdrawl = 0;
        private double deposit = 0;
        private DateTime transDate;

        private bool transStatusActived = false;

        List<AccountTransit> listTransits = new List<AccountTransit>();

        public AccountTransit (double _accountid, double _balance, double _withdrawl, double _deposit, DateTime _transDate)
        {
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
            accountId = account.GetAccountNumber();

            WriteLine($"Insert or input amount of money you want deposit to this Account Number: {account.GetAccountNumber()}");
            string inputValue = ReadLine();
            deposit = ToDouble(inputValue);
            withdrawl = 0;
            transDate = DateTime.Now;
            balance = balance + deposit - withdrawl;

            transit = new AccountTransit();
            transit.setAccountId(accountId);
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
            accountId = account.GetAccountNumber();

            WriteLine($"Please entre amount of money you want withdrawl from this Account Number: {account.GetAccountNumber()}");
            string inputValue = ReadLine();
            withdrawl = ToDouble(inputValue);
            deposit = 0;
            transDate = DateTime.Now;
            balance = balance + deposit - withdrawl;

            transit = new AccountTransit();
            transit.setAccountId(accountId);
            transit.setDeposit(deposit);
            transit.setBlance(balance);
            transit.setWithdrawl(withdrawl);
            transit.setTransitionDate(transDate);

            dispalyTransit(transit);

            listTransits.Add(transit);
            WriteLine(listTransits.Count);
        }

        //Method to check Acccount status 
        public void accountStatements (Account account, AccountTransit transit)
        {
            for (int i = 0; i < listTransits.Count; i++)
            {
                WriteLine($"Transit time: {listTransits[i].GetTransitDate()};    Deposit: {listTransits[i].GetDeposit()};   Withdrawl: {listTransits[i].GetWithdrawl()};   Balance: {listTransits[i].GetBalance()}");
            }
        }

        //Method to print Acccount history
        public void accountHistory (Account account, AccountTransit transit)
        {
            WriteLine("Please entre history start date yyyy-mm-dd: ");
            var cultureInfo = new CultureInfo("es-ES");
            string inputDate = ReadLine();
            string formatDate = "yyyy-mm-dd";
            DateTime startDate = DateTime.ParseExact(inputDate, formatDate, cultureInfo);
   
            WriteLine("Please entre history end date yyyy-mm-dd: ");
            string inputDate2 = ReadLine();
            DateTime endDate = DateTime.ParseExact(inputDate2, formatDate, cultureInfo);

            for (int i = 0; i < listTransits.Count; i++)
            {
                if (listTransits[i].GetTransitDate() >= startDate)
                WriteLine($"Transit time: {listTransits[i].GetTransitDate()};    Deposit: {listTransits[i].GetDeposit()};   Withdrawl: {listTransits[i].GetWithdrawl()};   Balance: {listTransits[i].GetBalance()}");
            }
        }

        //Delete records
        public void deleteRecords (Account account, AccountTransit transit)
        {
            if (account.GetAccountNumber() == transit.GetAccountId())
            {
                listTransits.Clear();
                WriteLine(listTransits.Count);
            }
        }

        //Display transit record
        public void dispalyTransit (AccountTransit transit)
        {
   
            WriteLine($"Account ID: {transit.GetAccountId(), -10} Tranist time: {transit.GetTransitDate(),-12} Deposit: {transit.GetDeposit(),-8} Withdrawl: {transit.GetWithdrawl(),-8} Balance: {transit.GetBalance(),-8}");
        } 

    }
}

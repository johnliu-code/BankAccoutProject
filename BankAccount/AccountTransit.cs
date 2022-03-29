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
        MethodLab myMethod = new MethodLab();

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

            string message = $"Insert or input amount of money you want deposit to this Account Number: {account.GetAccountNumber()}";
            double inputValue = 0;
            deposit = myMethod.validDouble(inputValue, message);
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

            string message = $"Please entre amount of money you want withdrawl from this Account Number: {account.GetAccountNumber()}";
            double inputValue = 0;
            withdrawl = myMethod.validDouble(inputValue, message);
            deposit = 0;
            transDate = DateTime.Now;
            if (withdrawl <= balance)
                balance = balance + deposit - withdrawl;
            else
                WriteLine($"Your withdrawl value is over the Balance: {balance}! please try again!!");

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
            DateTime inputDateTime = DateTime.Today;
            string formatDateTime = "yyyy-MM-dd";

            string message = "Please entre history start date yyyy-mm-dd: ";
            DateTime startDate = myMethod.validDateTimeInput(inputDateTime, message, formatDateTime);
   
            string message2 = "Please entre history end date yyyy-mm-dd: ";
            DateTime endDate = myMethod.validDateTimeInput(inputDateTime, message2, formatDateTime);

            for (int i = 0; i < listTransits.Count; i++)
            {
                if (listTransits[i].GetTransitDate() >= startDate && listTransits[i].GetTransitDate() <= endDate)
                {
                    WriteLine($"Transit time: {listTransits[i].GetTransitDate()};    Deposit: {listTransits[i].GetDeposit()};   Withdrawl: {listTransits[i].GetWithdrawl()};   Balance: {listTransits[i].GetBalance()}");
                } else
                {
                    WriteLine($"Did not find results in this time priod: {startDate} to {endDate}");
                }              
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

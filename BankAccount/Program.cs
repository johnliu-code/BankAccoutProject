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

            MethodLab myMethod = new MethodLab();

            DataManage dataManage = new DataManage();

            dataManage.mainMenu();

        }
    }
}

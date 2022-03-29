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
    class MethodLab
    {
        //Methods for reusing
        public MethodLab() { }

        //Validate double number inpunt
        public double validDouble(double inputDouble, string message)
        {
            try
            {
                WriteLine(message);
                inputDouble = ToDouble(ReadLine());
            }
            catch (Exception)
            {
                WriteLine($"Please entre a valid Double number!!!");
                return validDouble(inputDouble, message);
            }
            return inputDouble;
        }

        //Validate int number input
        public int validInt(int inputInt, string message)
        {
            try
            {
                WriteLine(message);
                inputInt = ToInt32(ReadLine());
            }
            catch (Exception)
            {
                WriteLine($"Please entre a valid Int number!!!");
                return validInt(inputInt, message);
            }
            return inputInt;
        }

        //Validate DateTime input value
        public DateTime validDateTimeInput(DateTime inputDateTime, string message, string formatDateTime)
        {
            try
            {
                WriteLine(message);
                var cultureInfo = new CultureInfo("es-ES");
                string inputDate = ReadLine();
                inputDateTime = DateTime.ParseExact(inputDate, formatDateTime, cultureInfo);
            }
            catch (Exception)
            {
                WriteLine($"Please entre a valid Date Time following the format: {formatDateTime} !!!");
                return validDateTimeInput(inputDateTime, message, formatDateTime);
            }
            return inputDateTime;
        }
    }
}

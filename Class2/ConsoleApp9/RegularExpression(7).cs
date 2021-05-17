using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp9
{
    class RegularExpression_7_
    {
        static void FindText123(string s)
        {
            string pattern = "текст123";
            Regex reg = new Regex(pattern);
            int count = 0;
            foreach (Match match in reg.Matches(s))
            {
                count++;

            }
            Console.WriteLine($"{count} occurrence(s) of substring \"{pattern}\" were/was found in string \"{s}\"");
        }
        static string PasswordValdation7b()
        {
            string password = Console.ReadLine();
            Regex reg = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$");
            while (!reg.IsMatch(password))
            {
                Console.WriteLine("Try again!");
                password = Console.ReadLine();
            }
            Console.WriteLine("You password is suittable");
            return password;
        }
        static string PasswordValdation7c()
        {
            string password = Console.ReadLine();
            Regex reg = new Regex(@"^\d{3}-\d{3}$");
            while (!reg.IsMatch(password))
            {
                Console.WriteLine("Try again!");
                password = Console.ReadLine();
            }
            Console.WriteLine("You password is suittable");
            return password;
        }

        static string PasswordValdation7d()
        {
            string password = Console.ReadLine();
            string pattern = @"^\+\d{3}-\d{2}-\d{3}-\d{2}-\d{2}$";
            Regex reg = new Regex(pattern);
            Console.WriteLine(reg.IsMatch(password));
            while (!reg.IsMatch(password))
            {
                Console.WriteLine(reg.IsMatch(password));
                Console.WriteLine("Try again!");
                password = Console.ReadLine();
            }
            Console.WriteLine("You password is suittable");
            return password;
        }

        static void PasswordValdation7e()
        {
            try
            {
                string password = Console.ReadLine();
                string originalNumber = @"\+\d{3}-\d{2}-\d{3}-\d{2}-\d{2}";
                string numberReplacedWithSymbols = "+XXX-XX-XXX-XX-XX";
                Console.WriteLine(Regex.Replace(password, originalNumber, numberReplacedWithSymbols));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception \"{ex.Message}\" has occured in PasswordValdation7e method");

            }

        }
    }
}

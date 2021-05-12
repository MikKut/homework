using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
{
    new Customer(1, "Tawana Shope", new DateTime(2017, 7, 15), 15.8),
    new Customer(2, "Danny Wemple", new DateTime(2016, 2, 3), 88.54),
    new Customer(3, "Margert Journey", new DateTime(2017, 11, 19), 0.5),
    new Customer(4, "Tyler Gonzalez", new DateTime(2017, 5, 14), 184.65),
    new Customer(5, "Melissa Demaio", new DateTime(2016, 9, 24), 241.33),
    new Customer(6, "Cornelius Clemens", new DateTime(2016, 4, 2), 99.4),
    new Customer(7, "Silvia Stefano", new DateTime(2017, 7, 15), 40),
    new Customer(8, "Margrett Yocum", new DateTime(2017, 12, 7), 62.2),
    new Customer(9, "Clifford Schauer", new DateTime(2017, 6, 29), 89.47),
    new Customer(10, "Norris Ringdahl", new DateTime(2017, 1, 30), 13.22),
    new Customer(11, "Delora Brownfield", new DateTime(2011, 10, 11), 0),
    new Customer(12, "Sparkle Vanzile", new DateTime(2017, 7, 15), 12.76),
    new Customer(13, "Lucina Engh", new DateTime(2017, 3, 8), 19.7),
    new Customer(14, "Myrna Suther", new DateTime(2017, 8, 31), 13.9),
    new Customer(15, "Fidel Querry", new DateTime(2016, 5, 17), 77.88),
    new Customer(16, "Adelle Elfrink", new DateTime(2017, 11, 6), 183.16),
    new Customer(17, "Valentine Liverman", new DateTime(2017, 1, 18), 13.6),
    new Customer(18, "Ivory Castile", new DateTime(2016, 4, 21), 36.8),
    new Customer(19, "Florencio Messenger", new DateTime(2017, 10, 2), 36.8),
    new Customer(20, "Anna Ledesma", new DateTime(2017, 12, 29), 0.8)
};



            FindFirstCustomer(customers);
            Console.WriteLine(GetAvaregeBalance(customers));
            SortByID(customers);
            SortByTimeInOneMonth(customers);
            SortByChosedProperty(customers, "Name", true);
            AddComas(customers);

        }

        static void FindFirstCustomer(List<Customer> customers)
        {
            var firstCustomersDate= customers.Select(x=>x.RegistrationDate).Min<DateTime>();
            foreach (Customer cust in customers)
            {
                if (cust.RegistrationDate == firstCustomersDate)
                {
                    Console.WriteLine(cust.Name);
                    break;
                }
            
            }
           
        }
        static double GetAvaregeBalance(List<Customer> customers)
        {
            double totaltBalance = 0;

            for (int i = 0; i < customers.Count; i++)
            {

                totaltBalance += customers[i].Balance;

            }
            return totaltBalance / customers.Count;

        }
        static void SortByDate(List<Customer> list, DateTime startWith, DateTime to)
        {
            var sortedUsers = from customer in list 
                              where (customer.RegistrationDate > startWith && customer.RegistrationDate < to) 
                              select customer;

            Console.WriteLine("By Date");

            foreach (Customer cust in sortedUsers)
            {

                Console.WriteLine(cust);

            }
            
        }
        static void SortByID(List<Customer> list)
        {
            var sortedUsers = from customer in list orderby customer.Id descending select customer;

            Console.WriteLine("By ID");

            foreach (Customer cust in sortedUsers)
            {

                Console.WriteLine(cust);

            }
           
        }
        static void SortByName(List<Customer> list, string namePart)
        {
            var sortedUsers = from customer in list where customer.ToString().StartsWith(namePart.ToUpper())
                              orderby customer.Name descending select customer;
           
            Console.WriteLine("By name");

            foreach (Customer cust in sortedUsers)
            {
               string res = cust.ToString();

                res = res.Substring(0, 1).ToUpper() + res.Substring(1, res.Length - 1).ToLower();

                Console.WriteLine(res);
            }

        }
        static void SortByTimeInOneMonth(List<Customer> customers)
        {

            var sortedUsers = customers.OrderBy(x => x.RegistrationDate.Month).ThenBy(x => x.Name).GroupBy(x => x.RegistrationDate.Month);

            foreach (var cust in sortedUsers)
            {
                foreach (var custom in cust)
                {

                    Console.WriteLine($"{custom.Name} - {custom.RegistrationDate.Month}");

                }

                Console.WriteLine();
            }

        }

        static void SortByChosedProperty(List<Customer> customers, string property, bool isDescending)
        {
            if (!isDescending)
            {
                var sortedUsers = customers.OrderBy(x => typeof(Customer).GetProperty(property).GetValue(x, null));

                foreach (Customer cust in sortedUsers)
                {
                    Console.WriteLine(cust.Name);

                }
            }

            else
            {

                var sortedUsers = customers.OrderByDescending(x => typeof(Customer).GetProperty(property).GetValue(x, null));

                foreach (Customer cust in sortedUsers)
                {
                    Console.WriteLine(cust.Name);

                }
            }        
        }

        static void AddComas(List<Customer> customers)
        {
            
            customers.ToArray();

            var str = string.Join(",", customers.Select(x => x.Name) );

            Console.WriteLine(str);           
        }
    }

// definition of Customer:
        public class Customer
        {
            public long Id { get; set; }

            public string Name { get; set; }

            public DateTime RegistrationDate { get; set; }

            public double Balance { get; set; }

            public Customer(long id, string name, DateTime registrationDate, double balance)
            {
                this.Id = id;
                this.Name = name;
                this.RegistrationDate = registrationDate;
                this.Balance = balance;
            }

        }
    
}

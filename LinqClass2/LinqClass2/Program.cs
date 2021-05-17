using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LinqClass2
{
    class Program:Art
    {
        static void Main(string[] args)
        {
            WithdrawAllRange10to50();
            WithdrawAllRange10to50DivisibleBy3();
            PrintLinq10times();
            PrintIfContainsA("aaa; abb; ccc; dap");
            PrintQuantityOfA("aaa; xabbx; abb; ccc; dap");
            FindTheLongest("aaa; xabbx; abb; ccc; dap");
            ReverseTheLowest("aaa; xabbx; abb; ccc; dap");
            HasStrngePattern("aaa; xabbx; abb; ccc; dap; aabbbb");
            DoLastTask("aaa; aasbb; xabbx; abb; ccc; dap");
            DisplayNamesOfArtists();
            DisplayArticlesAndFilmsByTheAuthors("Basov", "Martin Scorsese");
            DisplayQuantityOfCharactersInAllAuthorsName();
            PrintFilmsWithActor(new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10) });
            SortByNames();
            SortByPages();
            PrintTotalSumOfInt();
            GetDictionary();
            Console.ReadKey();
        }

        static void WithdrawAllRange10to50()
        {
            Enumerable.Range(10, 39).ToList().ForEach(x => Console.Write($"{x},"));
            Console.WriteLine(50);
        }
        static void WithdrawAllRange10to50DivisibleBy3()
        {
            var list = Enumerable.Range(10, 40).ToList();
            var result = list.Where(x => (x / 3) * 3 == x).Select(x => x);
            foreach (int el in result)
            {

                Console.WriteLine(el);

            }
            Console.WriteLine(50);
        }

        static void PrintLinq10times()
        {
            Enumerable.Range(10, 10).ToList().ForEach(x => Console.WriteLine($"Linq"));
        }

        static void PrintIfContainsA(string initialString)
        {
            var res =  initialString.Split("; ").ToList<string>().Where(x => x.Contains('a')).Select(x => x);
            string d = String.Join(" ", res);          
            Console.WriteLine($"{d}");            
        }

        static void PrintQuantityOfA(string initialString)
        {
            initialString.Split("; ").ToList<string>().ForEach(x => Console.WriteLine($"{x} - {x.Count(x => x == 'a')},"));
          
        }

        static void CheckForExistanceOfAWord(string initialString)
        {

            Console.WriteLine(initialString.Contains("abb"));

        }

        static void FindTheLongest(string initialString)
        {

            Console.WriteLine(initialString.Split("; ").OrderByDescending(n => n.Length).First());
        
        }

        static void FindAvarageLength(string initialString)
        {

            Console.WriteLine(initialString.Split("; ").Average(n => n.Length));

        }
        static void ReverseTheLowest(string initialString)
        {
            var st = initialString.Split("; ").OrderByDescending(n => n.Length).Last().Select((c, index) => new { c, index })
                                         .OrderByDescending(x => x.index)
                                         .Select(x => x.c)
                                         .ToArray();
            Console.WriteLine(st);

        }
        static void HasStrngePattern(string initialString)
        {
            Regex reg = new Regex(@"^aa[b]+$");
            var st = initialString.Split("; ").Where(x => reg.IsMatch(x)).Select(x => x);
            if (st.Count() ==  0)
            {
                Console.WriteLine(false);
            }
            else
            {
                Console.WriteLine(true);
            }
        }
        static void DoLastTask(string initialString)
        {
            Regex reg = new Regex(@"\w*[b][b]$");
            string res = initialString.Split("; ").Where(x => reg.IsMatch(x)).Skip(2).LastOrDefault();
            Console.WriteLine( res == null? "The string does not contain at least 3 word ends with \"bb\"": res );
        
        }

    }
}

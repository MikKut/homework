using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqClass2
{
    public class Art
    {
        abstract class ArtObject
        {
            public string Author { get; set; }
            public string Name { get; set; }
            public int Year { get; set; }
        }

        class Film : ArtObject
        {

            public int Length { get; set; }
            public IEnumerable<Actor> Actors { get; set; }
        }

       public class Actor
        {
            public string Name { get; set; }
            public DateTime Birthdate { get; set; }
        }

        class Article : ArtObject
        {
            public int Pages { get; set; }
        }


        static List<object> data = new List<object>
        {
                "Hello",
                new Article { Author = "Hilgendorf", Name = "Punitive law and criminal law doctrine.", Pages = 44 },
                new List<int> {45, 9, 8, 3},
                new string[] {"Hello inside array"},
                new Film { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
                    new Actor { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                    new Actor { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                    new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
                }},
                new Film { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
                    new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                    new Actor { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
                }},
                new Article { Author = "Basov", Name="Classification and content of restrictive administrative measures applied in the case of emergency", Pages = 35},
                "Leonardo DiCaprio"
        };

        public static void DisplayNamesOfArtists()
        {
            Console.WriteLine("Names of all the actors");
            data.Where(x => x is Actor).Select(x => (Actor)x).ToList().ForEach(x => { Console.WriteLine(x.Name); });
        }
        public static void DisplayQuantityOfBornInAugust()
        {
            Console.WriteLine("They were born in August:");
            Console.WriteLine(data.Where(x => x is Actor).Select(x => (Actor)x).Where(x => x.Birthdate.Month == 8).ToList().Count());

        }

        public static void DisplayTwoTheOldestActors()
        {
            Console.WriteLine("The oldest ones:");
            data.Where(x => x is Actor).Select(x => (Actor)x).OrderByDescending(x => x).Take(2).ToList().ForEach(x => { Console.WriteLine(x.Name); });

        }
        public static void DisplayQuantityOfArticlesPerAuthor()
        {
            Console.WriteLine("The quantity of articles per person:");
            data.Where(x => x is Article).Select(x => (Article)x).GroupBy(x => x.Author).Select(x => new
            {
                author = x.Key,
                articles = x.Count(),
            }).ToList().ForEach(x => { Console.WriteLine($"{x.author} - {x.articles}"); });


        }
        public static void DisplayArticlesAndFilmsByTheAuthors(string articleAuthor, string filmAuthor)
        {
            Console.WriteLine("Articles of:");
            data.Where(x => x is Article).Select(x => (Article)x).Where(x => x.Author == articleAuthor).GroupBy(x => x.Author).Select(x => new
            {
                articles = String.Join(",", x.Select(x => x.Name))
            }).ToList().ForEach(x => { Console.WriteLine($"{articleAuthor}: {x.articles}"); });

            Console.WriteLine("Films of:");
            data.Where(x => x is Film).Select(x => (Film)x).Where(x => x.Author == filmAuthor).GroupBy(x => x.Author).Select(x => new
            {
                films = String.Join(",", x.Select(x => x.Name))
            }).ToList().ForEach(x => { Console.WriteLine($"{filmAuthor}: {x.films}"); });
        }
        public static void DisplayQuantityOfCharactersInAllAuthorsName()
        {
            string s = "";
            data.Where(x => x is Article).Select(x => (Article)x).ToList().ForEach(x => { s = String.Concat(x.Author, s); });
            Console.WriteLine($"Quantity of characters: ");
            Console.WriteLine(s.ToCharArray().Distinct().Count());

        }
        public static void SortByPages()
        {
            Console.WriteLine("Sort by pages:");
            data.Where(x => x is Article).Select(x => (Article)x).OrderBy(x => x.Pages).ToList().ForEach(x => { Console.WriteLine($"{x.Author} - {x.Name} -{x.Pages}"); });
        }
        public static void SortByNames()
        {
            Console.WriteLine("Sort by names:");
            data.Where(x => x is Article).Select(x => (Article)x).OrderBy(x => x.Author).ToList().ForEach(x => { Console.WriteLine($"{x.Author} - {x.Name} - {x.Pages}"); });
        }
        public static void PrintFilmsWithActor(Actor actor)
        {

            Console.WriteLine($"Fims of {actor.Name}:");
            data.Where(x => x is Film).Select(x => (Film)x).Where(x => x.Actors.Contains(actor)).ToList().ForEach(x => { Console.Write($"{x.Name} "); });

        }

        public static void PrintTotalSumOfInt()
        {
            
            int sum = 0;
            data.Where(x => x is int).Select(x => (int)x).ToList().ForEach(x => { sum += x; });
            data.Where(x => x is Article).Select(x => (Article)x).ToList().ForEach(x => { sum += x.Pages; });
            Console.WriteLine($"total int:{sum}");
        }
        public static Dictionary<string, string> GetDictionary()
        {
            var allDictEnteries = new Dictionary<string, string>();
            data.Where(x => x is Article).Select(x => (Article)x).GroupBy(x => x.Author).Select(x => new
            {
                articles = String.Join(",", x.Select(x => x.Name)),
                author = x.Key
            }) .ToList().ForEach(x => { allDictEnteries.Add(x.author, x.articles); });
            return allDictEnteries;
        }
    }
}

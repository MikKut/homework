using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
namespace OOP
{
    class ReportFiller
    {

        public static void FillTextFile(string str, TextFiles textFiles)
        {
            textFiles.Name = Searcher.SearchName(str); textFiles.Extension = Searcher.SearchExtension(str);
            textFiles.Size = ConvertAllToBytes(Searcher.SearchSize(str)); textFiles.Content = Searcher.SearchContent(str);

        }
        public static void FillImageFile(string str, ImageFiles imageFiles)
        {
            imageFiles.Name = Searcher.SearchName(str); imageFiles.Extension = Searcher.SearchExtension(str);
            imageFiles.Size = ConvertAllToBytes(Searcher.SearchSize(str)); imageFiles.Resolution = Searcher.SearchResolution(str);

        }
        public static void FillMovieFile(string str, MovieFiles movieFiles)
        {
            movieFiles.Name = Searcher.SearchName(str); movieFiles.Extension = Searcher.SearchExtension(str);
            movieFiles.Size = ConvertAllToBytes(Searcher.SearchSize(str)); movieFiles.Resolution = Searcher.SearchResolution(str);

        }
        public static string ConvertAllToBytes(string image)
        {

            Regex re = new Regex(@"(\d+)([a-zA-Z]+)");
            Match result = re.Match(image);

            string format = result.Groups[2].Value;
            string numbers = (result.Groups[1].Value);
            int number = int.Parse(numbers);

            int res = format switch
            {
                "B" => number,
                "KB" => number = number * 1000,
                "GB" => number = number * 1000000000,
                "MB" => number = number * 100000,
                _ => throw new Exception("Unknow size format")

            };
            return Convert.ToString(res + "B");
        }

    }
}

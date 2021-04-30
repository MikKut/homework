using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace OOP
{
    class ReportCreator
    {


        static List<TextFiles> textFilesList = new List<TextFiles>();
        static List<MovieFiles> movieFilesList = new List<MovieFiles>();
        static List<ImageFiles> imageFilesList = new List<ImageFiles>();
        public static void FormFinalReport(string inputStr)
        {

            string[] strings = Regex.Split(inputStr, Environment.NewLine);
            foreach (string str in strings)
            {

                if (str.StartsWith("Text:"))
                {
                    TextFiles textFiles = new TextFiles();
                    ReportFiller.FillTextFile(str, textFiles);
                    textFilesList.Add(textFiles); continue;
                }
                else if (str.StartsWith("Movie:"))
                {
                    MovieFiles movieFiles = new MovieFiles();
                    ReportFiller.FillMovieFile(str, movieFiles);
                    movieFilesList.Add(movieFiles); continue;
                }
                else if (str.StartsWith("Image:"))
                {
                    ImageFiles imageFiles = new ImageFiles();
                    ReportFiller.FillImageFile(str, imageFiles);
                    imageFilesList.Add(imageFiles); continue;

                }




            }
            ConstructTextReport(textFilesList);
            ConstructImageReport(imageFilesList);
            ConstructMovieReport(movieFilesList);

        }
        public static List<TextFiles> SortBySizes(List<TextFiles> textFilesList)
        {
            List<TextFiles> SortedList = textFilesList.OrderBy(list => list.Size).ToList();
            return SortedList;
        }
        public static List<MovieFiles> SortBySizes(List<MovieFiles> textFilesList)
        {
            List<MovieFiles> SortedList = textFilesList.OrderBy(list => list.Size).ToList();
            return SortedList;
        }
        public static List<ImageFiles> SortBySizes(List<ImageFiles> textFilesList)
        {
            List<ImageFiles> SortedList = textFilesList.OrderBy(list => list.Size).ToList();
            return SortedList;
        }


        public static void ConstructTextReport(List<TextFiles> lists)
        {

            foreach (TextFiles list in SortBySizes(lists))
            {
                list.PrintAllInfo();

            }

        }
        public static void ConstructImageReport(List<ImageFiles> lists)
        {

            foreach (ImageFiles list in SortBySizes(lists))
            {
                list.PrintAllInfo();

            }

        }
        public static void ConstructMovieReport(List<MovieFiles> lists)
        {

            foreach (MovieFiles list in SortBySizes(lists))
            {
                list.PrintAllInfo();

            }

        }
        
       
        
    }
    
}

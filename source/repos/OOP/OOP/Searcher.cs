using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace OOP
{
    
    class Searcher
    {
        public static string SearchName(string str)
        {
            
            string nameWithBracketAndColon = @":.*\(";
            string bracketAndColon = @":|\(";
            var temp = Regex.Match(str, nameWithBracketAndColon);
            string val = temp.Value;
            val = new Regex(bracketAndColon).Replace(val, "");
            return val;
        }
        public static string SearchExtension(string str)
        {

            string extensionWithPointAndColon = @"\..+\(";
            string pointAndColon = @"\.|\(";
            var temp = Regex.Match(str, extensionWithPointAndColon);
            string val = temp.Value;
            val = new Regex(pointAndColon).Replace(val, "");
            return val;
        }
        public static string SearchSize(string str)
        {

            string sizeWithPoints = @"\(.+\)";
            string points = @"\(|\)";
            var temp = Regex.Match(str, sizeWithPoints);
            string val = temp.Value;
            val = new Regex(points).Replace(val, "");
            return val;
        }
        public static string SearchContent(string str)
        {

            string sizeWithSemicolon = @"\;.*";
            string semicolon = @"\;";
            var temp = Regex.Match(str, sizeWithSemicolon);
            string val = temp.Value;
            val = new Regex(semicolon).Replace(val, "");
            return val;
        }
        public static string SearchResolution(string str)
        {

            string nameWithBracketAndColon = @":.*\(";
            string bracketAndColon = @":|\(";
            var temp = Regex.Match(str, nameWithBracketAndColon);
            string val = temp.Value;
            val = new Regex(bracketAndColon).Replace(val, "");
            return val;
        }

    }
    

}

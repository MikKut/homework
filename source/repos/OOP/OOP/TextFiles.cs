using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OOP
{
    public class TextFiles : Files, IContent
    {
        
        public string Content { get; set; }     
        public override void PrintAllInfo()
        {
            string textInfo = $"\n\t{Name}\n\t\tExtension: {Extension}\n\t\tSize: {Size}\n\t\tContent: \"{Content}\"";
           
             Console.WriteLine($"Text:{textInfo}");

           

        }

    }
}

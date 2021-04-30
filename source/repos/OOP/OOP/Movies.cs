using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OOP
{
    public class MovieFiles : Files, IResolution, ILength
    {
       

        public string Resolution { get; set; }
        public string Length { get; set; }
       
       

        public override void PrintAllInfo()
        {
            string movieInfo = $"\n\t{Name}\n\t\tExtension: {Extension}\n\t\tSize: {Size}\n\t\tResolution: {Resolution}\n\t\tLength: {Length}";
            
                Console.WriteLine($"Movies:{movieInfo}");
            
            
        
        }
    }
}

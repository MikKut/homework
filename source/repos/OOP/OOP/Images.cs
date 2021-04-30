using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OOP
{
    public class ImageFiles : Files, IResolution
    {
    
        public string Resolution { get; set; }
       
      
        public override void PrintAllInfo()
        {
            string imagesInfo = $"\n\t{Name}\n\t\tExtension: {Extension}\n\t\tSize: {Size}\n\t\tResolution: {Resolution}";
            
                Console.WriteLine($"Images:{imagesInfo}");

            

        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OOP
{
   
   public abstract class Files : IExtension, ISize, IName
    {
     public string Type { get; set; }

     public string Name { get; set; }

     public string Extension { get; set; }

     public string Size { get; set; }

     protected static int counterOfTheFiles = 0;
        public abstract void PrintAllInfo();
        

    }
   
  
   
}

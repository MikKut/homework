using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace Task2
{
    public class PersonsDataHendler
    {
       public static string[] ParseToPersonsFields()
        {
             string str = Console.ReadLine();

            string[] namesArr = str.Split(",");

            return namesArr;

        }     
        
    }

}

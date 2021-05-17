using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Task2
{
    class Writer
    {       
        public static void DisplayPersonsByTheFields(List<Person> list)
        {
           string[] fields = PersonsDataHendler.ParseToPersonsFields();

            foreach (Person human in list)
            {
                using (var streamWriter = new StreamWriter("Person.CSV", true, Encoding.Unicode))
                {
                    for (var i = 0; i < fields.Length; i++)
                    {
                        streamWriter.Write($@"{fields[i]} - ""{human.GetTheProperty(fields[i])}"" ");
                    }
                    streamWriter.WriteLine();
                }
                

            }
        }
    }
}

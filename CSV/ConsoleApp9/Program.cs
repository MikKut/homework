using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        /*2.Дана коллекция сущностей Person. Написать консольное приложение, которое будет генерировать текстовый файл в формате CSV, по 
    веденным названиям полей класса Person. Название полей вводить в консоль через запятую. 
    Сгенерированный файл должен открываться в любом текстовом редакторе корректно.
P.S. стоит обратить внимание на экранирование строк.
*/
        static void Main(string[] args)
        {
            List<Person> crew = new List<Person>();
            crew.Add(new Person("Adam", "Cristopher", "Smith"));
            crew.Add(new Person("Jack", "Mikle", "Smith"));
            crew.Add(new Person("Piter", "Andre", "Piterson"));
            Writer.DisplayPersonsByTheFields(crew);

        }      

    }
}
  

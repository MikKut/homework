using System;

namespace _12
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, minNum = 0, a = (Convert.ToInt32(Console.ReadLine()));
           int prev = 0;


            while (a != 0)
            {
                i = a % 10;
                if (i<prev)
                {
                    minNum = i;              
                }
                
                a = (a - (a%10))/10;
                prev = i;
            
            
            }
            Console.WriteLine(minNum);
            
        }
    }
}

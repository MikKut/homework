using System;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
  
        }

        static void ReadBothExponentialAndSimpleNumbers(string stringNumber)
        {
            try
            {
                decimal decimalNumber = decimal.Parse(stringNumber, NumberStyles.AllowExponent | NumberStyles.Float, CultureInfo.InvariantCulture);
                Console.WriteLine(decimalNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception \"{ex.Message}\" has occured in ReadBothExponentialAndSimpleNumbers method");
            }
        }
        static void FindNubers(string digitsAndLetters)
        {
            try
            {

                string withoutLetters = "";
                for (int i = 0; i < digitsAndLetters.Length; i++)
                {
                    if (Char.IsDigit(withoutLetters[i]))
                        withoutLetters += digitsAndLetters[i];
                }
                Console.WriteLine(withoutLetters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception \"{ex.Message}\" has occured in FindNubers method");
            }
        }
        static void ConvertDivisonResultToTwoDigitsAfterComa(int first, int second)
        {
            try
            {
                double result = first / second;
                String.Format("{0:0.00}", result);    
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception \"{ex.Message}\" has occured in ConvertDivisonResultToTwoDigitsAfterComa method");

            }

        }
        static void GetCurrentTimeInISO8601()
        {
            Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"));
       
        }
        static void ParseToDateTime(string stringDate)
        {
            try
            {

                DateTime dt = DateTime.ParseExact(stringDate, "yyyy dd-MM", CultureInfo.InvariantCulture);
                Console.WriteLine(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception \"{ex.Message}\" has occured in ParseToDateTime method");

            }
        }

        static void SumOfNumbersWithComaBetweenThem(string st)
        {
            try
            {

                int[] numbers = Array.ConvertAll(st.Split(","), Int32.Parse);
                int res = 0;
                foreach (int number in numbers)
                {
                    res += number;

                }
                Console.WriteLine(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception \"{ex.Message}\" has occured in SumOfNumbersWithComaBetweenThem method");
            }
        
        }


        static string[] SwitchFirstCharactersToUpperCase(string[] strArr)
        {
            try
            {
                string[] result = new string[strArr.Length];
                int i = 0;
                foreach (string st in strArr)
                {
                    string[] newStr = st.Split(" ");

                    TextInfo te = CultureInfo.CurrentCulture.TextInfo;

                    result[i] += te.ToTitleCase(st);


                    i++;
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception \"{ex.Message}\" has occured in SwitchFirstCharactersToUpperCase method");
                throw new Exception();
            }

        }
        public static void DecodeStringFromBase64(string password)
        {
            try
            {
                Console.WriteLine(System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(password)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception \"{ex.Message}\" has occured in DecodeStringFromBase64 method");
            }
        }

    }
    
}

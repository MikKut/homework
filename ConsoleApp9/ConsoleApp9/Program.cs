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
        static void FindNubers(string digitsAndLetters)
        {
            string withoutLetters = "";
            for (int i = 0; i < digitsAndLetters.Length; i++)
            {
                if (Char.IsDigit(withoutLetters[i]))
                    withoutLetters += digitsAndLetters[i];
            }
            Console.WriteLine(withoutLetters);
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
                Console.WriteLine(ex.Message);

            }

        }
        static void GetCurrentTimeInISO8601()
        {
            Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"));
       
        }
        static void ParseToDateTime(string stringDate)
        {          
            var year = new char[4];
            var day = new char[2];
            var month = new char[2];
            var charArray = stringDate.ToCharArray();
            for (int i = 0; i<4; i++)
            {
                year[i] = charArray[i];
            }
            for (int i = 5, j = 0; i < 7; i++, j++)
            {
                month[j] = charArray[i];
            }
            for (int i = 8, j = 0; i < 10; j++, i++)
            {

                day[j] = charArray[i];
            }
            int intYear = int.Parse(year), intMonth = int.Parse(month), intDay = int.Parse(day);
            DateTime dateInFormatDateTime = new DateTime(intYear, intMonth, intDay);

        }

        static void SumOfNumbersWithComaBetweenThem(string st)
        {
            int[] numbers = Array.ConvertAll(st.Split(","), Int32.Parse);
            int res = 0;
            foreach (int number in numbers)
            {
                res += number;
            
            }
            Console.WriteLine(res);
        
        }

        static void FindText123(string s)
        {
            Regex reg = new Regex("текст123");
            foreach (Match match in reg.Matches(s))
            {
                Console.WriteLine(match.ToString());

            }

        }
        static string[] ToUpperCase(string[] strArr)
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
        public static void EncodeStringFromBase64(string password)
        {
            try
            {
                Console.WriteLine(System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(password)));
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

    }
}

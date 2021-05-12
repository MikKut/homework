using System.Reflection;

namespace Task2
{
    public class Person
    {
        public Person(string fn, string secn, string surn)
        {
            this.FirstName = fn;
            this.SecondName = secn;
            this.Surname = surn;
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname {  get; set; }

        public string GetTheProperty(string name)
        {

            return this.GetType().GetProperty(name).GetValue(this, null).ToString();
        }

    }
}

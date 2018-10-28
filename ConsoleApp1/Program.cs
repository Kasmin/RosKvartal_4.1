using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<People> people = new List<People>(5);
            people.Add(new People() { Name = "Иван", Age = 31, Sex = "Male", Balance = 400 });
            people.Add(new People() { Name = "Женя", Age = 24, Sex = "Male", Balance = 24000 });
            people.Add(new People() { Name = "Даша", Age = 22, Sex = "Female", Balance = 570 });
            people.Add(new People() { Name = "Лёша", Age = 25, Sex = "Male", Balance = 14570 });
            people.Add(new People() { Name = "Соня", Age = 27, Sex = "Female", Balance = 4570 });

            string line = "----------------";

            FindOlder(people);
            FindRicher(people);
            Console.WriteLine(line);
            FindBalance(people, 4000);
            Console.WriteLine(line);
            OrderBy(people, "Age");
            Console.WriteLine(line);
            OrderBy(people, "Sex");
            Console.WriteLine(line);
            OrderBy(people, "Balance");
            Console.ReadLine();
        }

        static void FindOlder(List<People> pp)
        {
            People oldMan = pp.OrderByDescending(n => n.Age).FirstOrDefault();

            Console.WriteLine("Самый старший: " + oldMan.Name + " - " + oldMan.Age);
        }
        static void FindRicher(List<People> pp)
        {
            People richMan = pp.OrderByDescending(n => n.Balance).FirstOrDefault();

            Console.WriteLine("Самый богатый: " + richMan.Name + " - " + richMan.Balance);
        }
        static string FindRicherAndOlder(List<People> pp)
        {
            var richMan = pp.OrderByDescending(n => n.Balance).FirstOrDefault();

            return richMan.Name;
        }
        static void FindBalance(List<People> pp, int bb)
        {
            List<People> blancedPeople = pp.Where(n => n.Balance > bb).Select(n => n).ToList();

            foreach (People i in blancedPeople)
            {
                Console.WriteLine("Богаче 4000: " + i.Name + " - " + i.Balance);
            }
        }
        static void OrderBy(List<People> pp, string typeSort)
        {
            var propertyInfo = typeof(People).GetProperty(typeSort);
            List<People> orderBy = pp.OrderBy(n => propertyInfo.GetValue(n, null)).ToList();
            Console.WriteLine("Sort by " + typeSort + ":");
            foreach(People i in orderBy)
            {
                Console.WriteLine(i.Name + " - " + propertyInfo.GetValue(i, null));
            }
        }
    }

    class People
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public int Balance { get; set; }
    }
}

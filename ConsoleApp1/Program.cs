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

            People oldMan = FindOlder(people);
            People richMan = FindRicher(people);
            List<People> balancedPeople = FindBalance(people, 4000); 

            Console.WriteLine("Самый старший: " + oldMan.Name + " - " + oldMan.Age);
            Console.WriteLine("Самый богатый: " + richMan.Name + " - " + richMan.Balance);

            foreach(People i in balancedPeople)
            {
                Console.WriteLine("Богаче 4000: " + i.Name + " - " + i.Balance);
            }

            Console.ReadLine();
        }

        static People FindOlder(List<People> pp)
        {
            People oldMan = pp.OrderByDescending(n => n.Age).FirstOrDefault();

            return oldMan;
        }
        static People FindRicher(List<People> pp)
        {
            People richMan = pp.OrderByDescending(n => n.Balance).FirstOrDefault();

            return richMan;
        }
        static string FindRicherAndOlder(List<People> pp)
        {
            var richMan = pp.OrderByDescending(n => n.Balance).FirstOrDefault();

            return richMan.Name;
        }
        static List<People> FindBalance(List<People> pp, int bb)
        {
            List<People> blancedPeople = pp.Where(n => n.Balance > bb).Select(n => n).ToList();

            return blancedPeople;
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

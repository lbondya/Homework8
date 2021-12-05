using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1 //Boldina Alevtina

#region Task1
    /*1. С помощью рефлексии выведите все свойства структуры DateTime.*/
#endregion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(DateTime);
            foreach (var prop in t.GetProperties())
                Console.WriteLine(prop.Name);
            Console.ReadKey();
        }
    }
}

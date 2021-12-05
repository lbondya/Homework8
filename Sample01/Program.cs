using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sample01
{

    public class Sample
    {
        public int MyProperty
        {
            get; set;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


            Sample sample = new Sample();
            sample.MyProperty = 12;

            Sample sample2 = new Sample();
            sample2.MyProperty = 54;


            Type type01 = typeof(Sample);
            Type type02 = sample.GetType();


            PropertyInfo propertyInfo = type01.GetProperty("MyProperty");
            if (propertyInfo != null && propertyInfo.CanRead)
            {
                object val = propertyInfo.GetValue(sample);
                Console.WriteLine($"Sample -> MyProperty -> {val}");
            }

            if (propertyInfo != null && propertyInfo.CanWrite)
            {
                propertyInfo.SetValue(sample, 15);

            }

            if (propertyInfo != null && propertyInfo.CanRead)
            {
                object val = propertyInfo.GetValue(sample);
                Console.WriteLine($"Sample -> MyProperty -> {val}");
            }



            Console.ReadKey();

        }
    }
}

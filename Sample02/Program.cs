using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sample02
{
    class Program
    {

        public static Person LoadPersonFromXml(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            var person = (Person)xmlSerializer.Deserialize(fileStream);
            fileStream.Close();

            return person;
        }

        public static void SavePersonToXml(Person person, string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fileStream, person);
            }  
        }

        static void Main(string[] args)
        {

            Person person =  LoadPersonFromXml(AppDomain.CurrentDomain.BaseDirectory + "Person.xml");

            Console.WriteLine($"{person.Name} {person.Name} {person.SecondName} {person.Age}");

            person.Age = 35;
            person.Name = "Станислав";

            SavePersonToXml(person, AppDomain.CurrentDomain.BaseDirectory + "Person.new.xml");

            Console.ReadKey();
        }
    }
}

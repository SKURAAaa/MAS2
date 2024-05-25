using System;
using System.Linq;

namespace ZooManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo("City Zoo");
            Console.WriteLine($"Created Zoo: {zoo.Name}");

            zoo.AddEnclosure("Lion Enclosure");
            zoo.AddEnclosure("Tiger Enclosure");

            Enclosure lionEnclosure = zoo.GetEnclosureByName("Lion Enclosure");
            Enclosure tigerEnclosure = zoo.GetEnclosureByName("Tiger Enclosure");

            Console.WriteLine($"Added Enclosures: {string.Join(", ", zoo.GetEnclosures().Select(e => e.Name))}");

            Keeper john = new Keeper("John");
            Keeper jane = new Keeper("Jane");

            Animal lion = new Animal("Lion", lionEnclosure);
            Animal tiger = new Animal("Tiger", tigerEnclosure);

            lionEnclosure.AddAnimal(lion);
            tigerEnclosure.AddAnimal(tiger);

            john.AddAnimal(lion);
            jane.AddAnimal(tiger);

            Console.WriteLine($"Animals in Lion Enclosure: {string.Join(", ", lionEnclosure.GetAnimals().Select(a => a.Name))}");
            Console.WriteLine($"Animals in Tiger Enclosure: {string.Join(", ", tigerEnclosure.GetAnimals().Select(a => a.Name))}");

            Console.WriteLine($"Keeper of Lion: {lion.GetKeeper().Name}");
            Console.WriteLine($"Keeper of Tiger: {tiger.GetKeeper().Name}");

            lion.AddMedicalRecord(new MedicalRecord { Date = DateTime.Now, Details = "Checkup" });
            Console.WriteLine($"Medical Records for Lion: {lion.GetMedicalRecords().Count}");
        }
    }
}
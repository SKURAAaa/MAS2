using System;

namespace ZooManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo("City Zoo");

            Enclosure lionEnclosure = new Enclosure("Lion Enclosure");
            Enclosure tigerEnclosure = new Enclosure("Tiger Enclosure");

            zoo.AddEnclosure(lionEnclosure);
            zoo.AddEnclosure(tigerEnclosure);

            Keeper john = new Keeper("John");
            Keeper jane = new Keeper("Jane");

            zoo.AddKeeper(john);
            zoo.AddKeeper(jane);

            Animal lion = new Animal("Lion", 5);
            Animal tiger = new Animal("Tiger", 3);

            lion.SetEnclosure(lionEnclosure);
            tiger.SetEnclosure(tigerEnclosure);

            lion.SetKeeper(john);
            tiger.SetKeeper(jane);

            MedicalRecord lionRecord = new MedicalRecord
            {
                Details = "Healthy",
                Date = DateTime.Now
            };
            lion.AddMedicalRecord(lionRecord);

            MedicalRecord tigerRecord = new MedicalRecord
            {
                Details = "Injured",
                Date = DateTime.Now
            };
            tiger.AddMedicalRecord(tigerRecord);

            // Weryfikacja poprawności działania
            Console.WriteLine($"{lion.Name} is in {lion.GetEnclosure().Name} with keeper {lion.GetKeeper().Name}");
            Console.WriteLine($"{tiger.Name} is in {tiger.GetEnclosure().Name} with keeper {tiger.GetKeeper().Name}");

            foreach (var record in lion.GetMedicalRecords())
            {
                Console.WriteLine($"{lion.Name} record: {record.Details} on {record.Date}");
            }

            foreach (var record in tiger.GetMedicalRecords())
            {
                Console.WriteLine($"{tiger.Name} record: {record.Details} on {record.Date}");
            }

            // Weryfikacja asocjacji kwalifikowanej
            Animal qualifiedLion = lionEnclosure.GetAnimalByName("Lion");
            Console.WriteLine($"Qualified Lion: {qualifiedLion?.Name ?? "Not found"}");
        }
    }
}

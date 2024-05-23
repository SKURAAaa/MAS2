using System;
using System.Collections.Generic;

namespace ZooManagement
{
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        private Enclosure _enclosure; // Zwykła asocjacja 1-*
        private Keeper _keeper; // Zwykła asocjacja 1-*
        private List<MedicalRecord> _medicalRecords; // Asocjacja z atrybutem

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
            _medicalRecords = new List<MedicalRecord>();
        }

        // Zwykła asocjacja 1-* z automatycznym tworzeniem połączenia zwrotnego
        public Enclosure GetEnclosure()
        {
            return _enclosure;
        }

        public void SetEnclosure(Enclosure enclosure)
        {
            if (_enclosure == enclosure) return;

            if (_enclosure != null)
            {
                _enclosure.RemoveAnimal(this); // Usunięcie połączenia zwrotnego
            }

            _enclosure = enclosure;

            if (enclosure != null)
            {
                enclosure.AddAnimal(this); // Tworzenie połączenia zwrotnego
            }
        }

        // Zwykła asocjacja 1-* z automatycznym tworzeniem połączenia zwrotnego
        public Keeper GetKeeper()
        {
            return _keeper;
        }

        public void SetKeeper(Keeper keeper)
        {
            if (_keeper == keeper) return;

            if (_keeper != null)
            {
                _keeper.RemoveAnimal(this); // Usunięcie połączenia zwrotnego
            }

            _keeper = keeper;

            if (keeper != null)
            {
                keeper.AddAnimal(this); // Tworzenie połączenia zwrotnego
            }
        }

        // Asocjacja z atrybutem (MedicalRecord)
        public void AddMedicalRecord(MedicalRecord record)
        {
            if (!_medicalRecords.Contains(record))
            {
                _medicalRecords.Add(record);
                record.Animal = this; // Tworzenie połączenia zwrotnego
            }
        }

        public void RemoveMedicalRecord(MedicalRecord record)
        {
            if (_medicalRecords.Contains(record))
            {
                _medicalRecords.Remove(record);
                if (record.Animal == this)
                {
                    record.Animal = null; // Usunięcie połączenia zwrotnego
                }
            }
        }

        public IReadOnlyList<MedicalRecord> GetMedicalRecords()
        {
            return _medicalRecords.AsReadOnly();
        }
    }

    public class MedicalRecord
    {
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public Animal Animal { get; set; } // Asocjacja z atrybutem
    }
}

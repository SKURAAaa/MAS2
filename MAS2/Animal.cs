using System;
using System.Collections.Generic;

namespace ZooManagement
{
    public class Animal
    {
        public string Name { get; set; }
        public Keeper Keeper { get; private set; } // Zwykła asocjacja 1-1
        public Enclosure Enclosure { get; private set; } // Zwykła asocjacja 1-1

        private List<MedicalRecord> _medicalRecords; // Asocjacja z atrybutem

        public Animal(string name, Enclosure enclosure)
        {
            Name = name;
            SetEnclosure(enclosure);
            _medicalRecords = new List<MedicalRecord>();
        }

        public void SetKeeper(Keeper keeper)
        {
            Keeper = keeper;
        }

        public Keeper GetKeeper()
        {
            return Keeper;
        }

        public void SetEnclosure(Enclosure enclosure)
        {
            Enclosure = enclosure;
        }

        public Enclosure GetEnclosure()
        {
            return Enclosure;
        }

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
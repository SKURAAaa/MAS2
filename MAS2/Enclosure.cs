using System;
using System.Collections.Generic;
using System.Linq;

namespace ZooManagement
{
    public class Enclosure
    {
        public string Name { get; set; }
        public Zoo Zoo { get; private set; } // Kompozycja 1-1
        private List<Animal> _animals; // Zwykła asocjacja 1-*

        public Enclosure(string name, Zoo zoo)
        {
            Name = name;
            SetZoo(zoo); // Ustawienie Zoo jako właściciela
            _animals = new List<Animal>();
        }

        public void SetZoo(Zoo zoo)
        {
            Zoo = zoo;
        }

        public IReadOnlyList<Animal> GetAnimals()
        {
            return _animals.AsReadOnly();
        }

        // Zwykła asocjacja 1-* z automatycznym tworzeniem połączenia zwrotnego
        public void AddAnimal(Animal animal)
        {
            if (!_animals.Contains(animal))
            {
                _animals.Add(animal);
                animal.SetEnclosure(this); // Tworzenie połączenia zwrotnego
            }
        }

        public void RemoveAnimal(Animal animal)
        {
            if (_animals.Contains(animal))
            {
                _animals.Remove(animal);
                if (animal.GetEnclosure() == this)
                {
                    animal.SetEnclosure(null); // Usunięcie połączenia zwrotnego
                }
            }
        }

        // Asocjacja kwalifikowana (szukanie zwierzęcia po nazwie)
        public Animal GetAnimalByName(string name)
        {
            return _animals.FirstOrDefault(a => a.Name == name);
        }
    }
}
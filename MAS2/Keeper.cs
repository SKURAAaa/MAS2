using System;
using System.Collections.Generic;

namespace ZooManagement
{
    public class Keeper
    {
        public string Name { get; set; }
        private List<Animal> _animals; // Zwykła asocjacja 1-*

        public Keeper(string name)
        {
            Name = name;
            _animals = new List<Animal>();
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
                animal.SetKeeper(this); // Tworzenie połączenia zwrotnego
            }
        }

        public void RemoveAnimal(Animal animal)
        {
            if (_animals.Contains(animal))
            {
                _animals.Remove(animal);
                if (animal.GetKeeper() == this)
                {
                    animal.SetKeeper(null); // Usunięcie połączenia zwrotnego
                }
            }
        }
    }
}
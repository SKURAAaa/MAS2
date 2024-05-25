using System;
using System.Collections.Generic;
using System.Linq;

namespace ZooManagement
{
    public class Zoo
    {
        public string Name { get; set; }
        private List<Enclosure> _enclosures; // Kompozycja 1-*

        public Zoo(string name)
        {
            Name = name;
            _enclosures = new List<Enclosure>();
        }

        public IReadOnlyList<Enclosure> GetEnclosures()
        {
            return _enclosures.AsReadOnly();
        }

        public void AddEnclosure(string enclosureName)
        {
            var enclosure = new Enclosure(enclosureName, this); // Tworzenie nowego obiektu Enclosure, który jest częścią Zoo
            _enclosures.Add(enclosure);
        }

        public void RemoveEnclosure(Enclosure enclosure)
        {
            if (_enclosures.Contains(enclosure))
            {
                _enclosures.Remove(enclosure);
                enclosure.SetZoo(null); // Usunięcie połączenia zwrotnego
            }
        }

        public Enclosure GetEnclosureByName(string name)
        {
            return _enclosures.FirstOrDefault(e => e.Name == name);
        }
    }
}
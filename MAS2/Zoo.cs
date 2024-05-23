using System;
using System.Collections.Generic;

namespace ZooManagement
{
    public class Zoo
    {
        public string Name { get; set; }
        private List<Enclosure> _enclosures; // Kompozycja 1-*
        private List<Keeper> _keepers; // Kompozycja 1-*

        public Zoo(string name)
        {
            Name = name;
            _enclosures = new List<Enclosure>();
            _keepers = new List<Keeper>();
        }

        public IReadOnlyList<Enclosure> GetEnclosures()
        {
            return _enclosures.AsReadOnly();
        }

        // Kompozycja 1-* z automatycznym tworzeniem połączenia zwrotnego
        public void AddEnclosure(Enclosure enclosure)
        {
            if (!_enclosures.Contains(enclosure))
            {
                _enclosures.Add(enclosure);
            }
        }

        public void RemoveEnclosure(Enclosure enclosure)
        {
            if (_enclosures.Contains(enclosure))
            {
                _enclosures.Remove(enclosure);
            }
        }

        public IReadOnlyList<Keeper> GetKeepers()
        {
            return _keepers.AsReadOnly();
        }

        // Kompozycja 1-* z automatycznym tworzeniem połączenia zwrotnego
        public void AddKeeper(Keeper keeper)
        {
            if (!_keepers.Contains(keeper))
            {
                _keepers.Add(keeper);
            }
        }

        public void RemoveKeeper(Keeper keeper)
        {
            if (_keepers.Contains(keeper))
            {
                _keepers.Remove(keeper);
            }
        }
    }
}
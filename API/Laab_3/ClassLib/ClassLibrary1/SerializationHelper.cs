using System;

namespace ClassLibrary1
{
    public class SerializationHelper
    {
        string pathToLibrary;
        Pokedex pokedex;

        object serializationLock = new object();

        public Pokedex Pokedex
        {
            set
            {
                pokedex = value;
                Save();
            }
            get
            {
                return pokedex;
            }
        }

        public SerializationHelper(string pathToLibrary)
        {
            this.pathToLibrary = pathToLibrary;
            Load();
        }

        public void Add(Pokemon pokemon)
        {
            pokedex.Pokemon.Add(pokemon);
            Save();
        }

        public void Load()
        {
            lock (serializationLock)
            {
                var json = File.ReadAllText(pathToLibrary);
                pokedex = JsonConvert.DeserializeObject<Pokedex>(json);
            }
        }

        public void Save()
        {
            lock (serializationLock)
            {
                var json = JsonConvert.SerializeObject(pokedex, Formatting.Indented);
                File.WriteAllText(pathToLibrary, json);
            }
        }
    }
}

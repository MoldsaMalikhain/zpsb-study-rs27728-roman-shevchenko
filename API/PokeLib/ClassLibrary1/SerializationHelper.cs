using PokeLib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeLib
{
    public class SerializationHelper
    {
        string pathToLibrary;

        Pokedex pokedex;

        object sr_Lock = new object();

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
            lock (sr_Lock)
            {
                var json = File.ReadAllText(pathToLibrary);
                pokedex = JsonConvert.DeserializeObject<Pokedex>(json);
            }
        }

        public void Save()
        {
            lock (sr_Lock)
            {
                var json = JsonConvert.SerializeObject(pokedex, Formatting.Indented);
                File.WriteAllText(pathToLibrary, json);
            }
        }

    }
}

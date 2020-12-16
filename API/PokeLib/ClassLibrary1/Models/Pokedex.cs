using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PokeLib.Models
{
    public class Pokedex
    {
        [XmlArray("Pokedex")]
        [XmlArrayItem("Pokemon")]
        public List<Pokemon> Pokemon { get; set; } = new List<Pokemon>();
    }
}

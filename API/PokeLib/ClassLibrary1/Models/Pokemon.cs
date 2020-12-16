using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PokeLib.Models
{
    [XmlType(TypeName = "Pokemon")]
    public class Pokemon
    {
        public class Create
        {
            public int dex { get; set; }

            public String name { get; set; }

            public double height { get; set; }

            public double weight { get; set; }

        }

        [XmlAttribute("dex")]
        public int dex { get; set; }

        public string id { get; set; }

        [XmlAttribute("name")]
        public String name { get; set; }

        public double height { get; set; }

        public double weight { get; set; }

        public Family family { get; set; }

        public Stats stats { get; set; }


        [XmlArray("types")]
        [XmlArrayItem("type")]
        public List<Type> types { get; set; }

        [XmlArray("attacks")]
        [XmlArrayItem("attack")]
        public List<Attack> attacks { get; set; } = new List<Attack>();

        [XmlArray("forms")]
        [XmlArrayItem("form")]
        public List<Form> forms { get; set; } = new List<Form>();
    }
}

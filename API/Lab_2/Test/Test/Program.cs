using System;
using System.IO;
using System.Xml.Serialization;

namespace DataAutomization
{
    [Serializable]
    [XmlRoot(ElementName = "test", Namespace = "")]
    public class FuckYouAll
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("resource_path")]
        public string Resource_Path { get; set; }

        [XmlElement("date")]
        public string Date { get; set; }

        [XmlElement("time")]
        public string Time { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Program T = new Program();
            T.DeserializeObject("Pokedex.xml");
        }
        private void DeserializeObject(string fileName)
        {
            Console.WriteLine("Reading w/ stream");
            XmlSerializer serializer = new XmlSerializer(typeof(Pokedex));

            Pokedex i;

            using(Stream reader = new FileStream(fileName, FileMode.Open))
            {
                i = (Pokedex)serializer.Deserialize(reader);
            }
            Console.WriteLine("Get Pokemon amount : {0}",i.Pokemon.Count);
            foreach (var item in i.Pokemon.ToArray())
            {
                Console.WriteLine("List Objects : {0}", item);
            }
        }

    }

}

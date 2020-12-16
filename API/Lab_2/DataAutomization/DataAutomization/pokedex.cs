using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Serialization;

namespace DataAutomization
{
    public class Attack
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Form
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Family
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Stats
    {
        public int baseAttack { get; set; }
        public int baseDefense { get; set; }
        public int baseStamina { get; set; }
    }

    public class Type
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class EvolutionItem
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class CostToEvolve
    {
        public EvolutionItem evolutionItem { get; set; }
    }


    public class FutureBranch
    {
        public string name { get; set; }
        public string id { get; set; }

        [XmlArray("futureBranches")]
        [XmlArrayItem("futureBranch")]
        public List<FutureBranch> futureBranches { get; set; }
        [XmlElement("evolutionCondition")]
        public CostToEvolve costToEvolve { get; set; }
    }

    public class PastBranch
    {
        public string name { get; set; }
        public string id { get; set; }
        public PastBranch pastBranch { get; set; }
        [XmlElement("evolutionCondition")]
        public CostToEvolve costToEvolve { get; set; }
    }

    public class Evolution
    {
        [XmlArray("futureBranches")]
        [XmlArrayItem("futureBranch")]
        public List<FutureBranch> futureBranches { get; set; }
        public PastBranch pastBranch { get; set; }
        [XmlElement("evolutionCondition")]
        public CostToEvolve costToEvolve { get; set; }
    }

    [XmlType(TypeName = "Pokemon")]
    public class Pokemon
    {
        [XmlAttribute("dex")]
        public int dex { get; set; }

        public string id { get; set; }

        [XmlAttribute("name")]
        public String name { get; set; }

        public double height { get; set; }

        public double weight { get; set; }

        [XmlArray("attacks")]
        [XmlArrayItem("attack")]
        public List<Attack> attacks { get; set; }

        public Family family { get; set; }
        public Stats stats { get; set; }

        [XmlArray("types")]
        [XmlArrayItem("type")]
        public List<Type> types { get; set; }

        public Evolution evolution { get; set; }

        [XmlArray("forms")]
        [XmlArrayItem("form")]
        public List<Form> forms { get; set; }
    }
    //--------------------------------------------first for deserialization--------------------------------------------------------------------
    [Serializable]
    public class Pokedex
    {
        [XmlArray("Pokedex")]
        [XmlArrayItem("Pokemon")]
        public List<Pokemon> Pokemon { get; set; }
    }
    [Serializable]
    public class RootObject
    {
        public Pokedex Pokedex { get; set; }
    }

}

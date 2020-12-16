using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DataAutomization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int counter = 0;

            XmlSerializer formatter = new XmlSerializer(typeof(Pokedex));
            Newtonsoft.Json.JsonSerializer sr = new Newtonsoft.Json.JsonSerializer();

            sr.Converters.Add(new JavaScriptDateTimeConverter());
            sr.NullValueHandling = NullValueHandling.Ignore;


            using (FileStream fs = new FileStream("Pokedex.xml", FileMode.OpenOrCreate))
            {
                Pokedex dex = (Pokedex)formatter.Deserialize(fs);
                Console.WriteLine("Deserialized");
                for (int i = 0; i < 25; i++)
                {
                    Console.WriteLine("Name: {0}", dex.Pokemon[i].name);
                }
                using (StreamWriter stream = new StreamWriter("Pokedex.json"))
                using (JsonWriter writer = new JsonTextWriter(stream))
                {
                    sr.Serialize(writer, dex);
                }


                for (int i = 0; i < dex.Pokemon.Count; i++)
                {
                    if (dex.Pokemon[i].weight > 20)
                    {
                        counter++;
                    }
                }
                Console.WriteLine("Count pokemons >20 weight: {0}", counter);
                counter = 0;



                for (int i = 0; i < dex.Pokemon.Count; i++)
                {
                    if (dex.Pokemon[i].height > 0.3)
                    {
                        counter++;
                    }
                }
                Console.WriteLine("Count pokemons >0.3 height: {0}", counter);



                string attackInf = "Error";
                int attack = 0;
                for (int i = 0; i < dex.Pokemon.Count; i++)
                {
                    for (int j = 0; j < dex.Pokemon.Count; j++)
                    {
                        if (dex.Pokemon[i].stats.baseAttack > dex.Pokemon[j].stats.baseAttack)
                        {
                            attackInf = dex.Pokemon[i].name;
                            attack = dex.Pokemon[i].stats.baseAttack;
                        }
                    }
                }
                Console.WriteLine("Pokemon with best base attack: {0} with attack: {1}", attackInf, attack);


                int b_Attack = 0, b_Defence = 0, b_Stamina = 0;
                for (int i = 0; i < dex.Pokemon.Count; i++)
                {
                    b_Attack += dex.Pokemon[i].stats.baseAttack;
                    b_Defence += dex.Pokemon[i].stats.baseDefense;
                    b_Stamina += dex.Pokemon[i].stats.baseStamina;
                }
                int m_Attack = b_Attack / dex.Pokemon.Count, m_Defenca = b_Defence / dex.Pokemon.Count, m_Stamina = b_Stamina / dex.Pokemon.Count;
                Console.WriteLine("Average values of Base Attack: {0} Base Defence: {1} Base Stamina: {2}", m_Attack, m_Defenca, m_Stamina);


                counter = 0;
                for (int i = 0; i < dex.Pokemon.Count; i++)
                {
                    if (dex.Pokemon[i].types.Count == 2)
                    {
                        counter++;
                    }
                }
                Console.WriteLine("Count pokemons with more than 2 types: {0}", counter);


                counter = 0;
                File.WriteAllText("Types.json", string.Empty);
                for (int i = 0; i < dex.Pokemon.Count; i++)
                {
                    if (dex.Pokemon[i].forms.Count >= 2)
                    {
                        counter++;
                        using (StreamWriter sw = new StreamWriter("Types.json", true))
                        using (JsonWriter writer = new JsonTextWriter(sw))
                        {
                            sr.Serialize(writer, dex.Pokemon[i]);
                        }
                    }
                }
                Console.WriteLine("Count pokemons with more than 2 forms: {0}, exported to Types.json", counter);


                counter = 0;
                File.WriteAllText("Water_Bite.json", string.Empty);
                for (int i = 0; i < dex.Pokemon.Count; i++)
                {
                    for (int j = 0; j < dex.Pokemon[i].types.Count; j++)
                    {
                        if (dex.Pokemon[i].types[j].name == "Water")
                        {
                            for (int g = 0; g < dex.Pokemon[i].attacks.Count; g++)
                            {
                                if (dex.Pokemon[i].attacks[g].name == "Bite Fast")
                                {
                                    counter++;
                                    using (StreamWriter sw = new StreamWriter("Water_Bite.json", true))
                                    using (JsonWriter writer = new JsonTextWriter(sw))
                                    {
                                        sr.Serialize(writer, dex.Pokemon[i]);
                                    }
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("Pokemons with water type and attack Bite Fast exported to Water_Bite.json\t Counter : {0}", counter);


                File.WriteAllText("No_Evolutions.json", string.Empty);
                counter = 0;
                for (int i = 0; i < dex.Pokemon.Count; i++)
                {
                    if (dex.Pokemon[i].evolution.futureBranches.Count == 0)
                    {
                        counter++;
                        using (StreamWriter sw = new StreamWriter("No_Evolutions.json", true))
                        using (JsonWriter writer = new JsonTextWriter(sw))
                        {
                            sr.Serialize(writer, dex.Pokemon[i]);
                        }
                    }
                }
                Console.WriteLine("Pokemons without evolution exported to No_Evolutions.json\t\t\t Counter : {0}", counter);


                counter = 0;
            }
            Console.ReadLine();
        }
    }
}




////Person sr = new Person("Testus", 20, new Company("Microsoft"));
////Person sr1 = new Person("Bilius", 24, new Company("Apple"));
////Person[] people = new Person[] { sr, sr1 };
////Console.WriteLine("Объект создан");

////XmlSerializer formatter = new XmlSerializer(typeof(Person[]));

////using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate)) 
////{
////    formatter.Serialize(fs, people);
////    Console.WriteLine("Объект сериализорован");
////}

////using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
////{
////    Person[] newp = (Person[])formatter.Deserialize(fs);

////    Console.WriteLine("Объект десериализован");
////    foreach (Person p in newp)
////    {
////        Console.WriteLine($"Имя: {p.Name} --- Возвраст: {p.Age} --- Клмпания: {p.Company.Name}");

////    }
////}
//Console.ReadLine();
//}

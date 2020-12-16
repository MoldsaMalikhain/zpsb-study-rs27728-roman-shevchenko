using PokeLib;
using PokeLib.Controllers;
using PokeLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonLib
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializationHelper     help             = new SerializationHelper("Pokedex.json");
            FormController          f_Controller     = new FormController(help);
            PokemonController       p_Controller     = new PokemonController(help);
            AttackController        a_Controller     = new AttackController(help);

            var Mulboss = p_Controller.CreatePokemon("Mulboss", new Pokemon.Create()
            {
                dex = -2,
                height = 4,
                weight = 300,
                name = "Mulboss",
            });
            a_Controller.CreateAttack("my_attack1", "Mega Punch", Mulboss);
            a_Controller.CreateAttack("my_attack2", "Earthquake", Mulboss);
            f_Controller.CreateForm("my_form1", "Earth", Mulboss);

            var Flash = p_Controller.CreatePokemon("Flash", new Pokemon.Create()
            {
                dex = 5,
                height = 0.3,
                weight = 2,
                name = "Flash",
            });
            a_Controller.CreateAttack("my_attack1", "Fast Bite", Flash);
            a_Controller.CreateAttack("my_attack2", "Blitz", Flash);
            f_Controller.CreateForm("my_form1", "Electric ", Flash);

            var Shrike = p_Controller.CreatePokemon("Shrike", new Pokemon.Create()
            {
                dex = 5,
                height = 0.3,
                weight = 1.5,
                name = "Shrike",
            });
            a_Controller.CreateAttack("my_attack1", "Fast Bite", Shrike);
            a_Controller.CreateAttack("my_attack2", "Slice", Shrike);
            f_Controller.CreateForm("my_form1", "Animal ", Shrike);
        }
    }
}

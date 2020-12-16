using PokeLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeLib.Controllers
{
    public class PokemonController : Controller
    {
        public PokemonController(SerializationHelper sr_helper) : base(sr_helper)
        {
        }

        public Pokemon CreatePokemon(string id, Pokemon.Create create)
        {
            var pokemon = new Pokemon()
            {
                id = id,
                name = create.name,
                dex = create.dex,
                height = create.height,
                weight = create.weight,
            };

            sr_helper.Add(pokemon);

            return pokemon;
        }

        public List<Pokemon> GetAllPokemons()
        {
            return sr_helper.Pokedex.Pokemon;
        }

        public Pokemon GetPokemon(string id)
        {
            return sr_helper.Pokedex.Pokemon.FirstOrDefault(x => x.id == id) ?? throw new Exception("Pokemon with given ID was not found.");
        }

        public void DeletePokemon(string id)
        {
            var pokemon = sr_helper.Pokedex.Pokemon.FirstOrDefault(x => x.id == id);
            if (pokemon == null)
            {
                throw new Exception("Attack with given ID was not found.");
            }
            sr_helper.Pokedex.Pokemon.RemoveAll(x => x.id == id);
            sr_helper.Save();
        }

    }
}

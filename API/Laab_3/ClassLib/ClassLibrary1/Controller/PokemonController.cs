using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Controller
{
    class PokemonController : Controller
    {
        public PokemonController(SerializationHelper serializationHelper) : base(serializationHelper)
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

            serializationHelper.Add(pokemon);

            return pokemon;
        }

        public List<Pokemon> GetAllPokemons()
        {
            return serializationHelper.Pokedex.Pokemon;
        }

        public Pokemon GetPokemon(string id)
        {
            return serializationHelper.Pokedex.Pokemon.FirstOrDefault(x => x.id == id) ?? throw new Exception("Pokemon with given ID was not found.");
        }

        public void DeletePokemon(string id)
        {
            var pokemon = serializationHelper.Pokedex.Pokemon.FirstOrDefault(x => x.id == id);
            if (pokemon == null)
            {
                throw new Exception("Attack with given ID was not found.");
            }
            serializationHelper.Pokedex.Pokemon.RemoveAll(x => x.id == id);
            serializationHelper.Save();
        }
    }
}

using PokeLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeLib.Controllers
{
    public class AttackController : Controller
    {
        public AttackController(SerializationHelper sr_helper) : base(sr_helper)
        {
        }

        public Attack GetAttack(string id)
        {
            foreach(var pokemon in sr_helper.Pokedex.Pokemon)
            {
                foreach(var attack in pokemon.attacks)
                {
                    if (attack.id.Equals(id))
                    {
                        return attack;
                    }
                }
            }
            throw new Exception("Attack with given ID was not found.");
        }

        public List<Attack> GetAttacks()
        {
            Dictionary<string, Attack> attacks = new Dictionary<string, Attack>();
            foreach (var pokemon in sr_helper.Pokedex.Pokemon)
            {
                foreach (var attack in pokemon.attacks)
                {
                    attacks.Add(attack.id, attack);
                }
            }
            return attacks.Select(x => x.Value).ToList();
        }

        public Attack CreateAttack(string id, string name)
        {
            Attack attack = new Attack()
            {
                id = id,
                name = name
            };
            return attack;
        }

        public Attack CreateAttack(string id, string name, Pokemon pokemon)
        {
            Attack attack = new Attack()
            {
                id = id,
                name = name
            };

            pokemon.attacks.Add(attack);
            sr_helper.Save();

            return attack;
        }

        public void DeleteAttack(string id, Pokemon pokemon)
        {
            var attack = pokemon.attacks.FirstOrDefault(x => x.id == id);
            if(attack == null)
            {
                throw new Exception("Attack with given ID was not found.");
            }
            pokemon.attacks.RemoveAll(x => x.id == id);
            sr_helper.Save();
        }

    }
}

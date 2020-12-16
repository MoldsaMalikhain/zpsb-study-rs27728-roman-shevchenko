using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Controller
{
    class AttackController : Controller
    {
        public AttackController(SerializationHelper serializationHelper) : base(serializationHelper)
        {
        }

        public Attack GetAttack(string id)
        {
            foreach (var pokemon in serializationHelper.Pokedex.Pokemon)
            {
                foreach (var attack in pokemon.attacks)
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
            foreach (var pokemon in serializationHelper.Pokedex.Pokemon)
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
            serializationHelper.Save();

            return attack;
        }

        public void DeleteAttack(string id, Pokemon pokemon)
        {
            var attack = pokemon.attacks.FirstOrDefault(x => x.id == id);
            if (attack == null)
            {
                throw new Exception("Attack with given ID was not found.");
            }
            pokemon.attacks.RemoveAll(x => x.id == id);
            serializationHelper.Save();
        }

    }
}
}

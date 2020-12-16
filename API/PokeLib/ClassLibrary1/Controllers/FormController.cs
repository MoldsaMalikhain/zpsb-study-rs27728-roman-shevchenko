using PokeLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeLib.Controllers
{
    public class FormController : Controller
    {
        public FormController(SerializationHelper sr_helper) : base(sr_helper)
        {

        }

        public Form GetForm(string id)
        {
            foreach (var pokemon in sr_helper.Pokedex.Pokemon)
            {
                foreach (var form in pokemon.forms)
                {
                    if (form.id.Equals(id))
                    {
                        return form;
                    }
                }
            }
            throw new Exception("Form with given ID was not found.");
        }

        public List<Form> GetForms()
        {
            Dictionary<string, Form> forms = new Dictionary<string, Form>();
            foreach (var pokemon in sr_helper.Pokedex.Pokemon)
            {
                foreach (var form in pokemon.forms)
                {
                    forms.Add(form.id, form);
                }
            }
            return forms.Select(x => x.Value).ToList();
        }

        public Form CreateForm(string id, string name)
        {
            Form form = new Form()
            {
                id = id,
                name = name
            };
            return form;
        }

        public Form CreateForm(string id, string name, Pokemon pokemon)
        {
            Form form = new Form()
            {
                id = id,
                name = name
            };

            pokemon.forms.Add(form);
            sr_helper.Save();

            return form;
        }

        public void DeleteForm(string id, Pokemon pokemon)
        {
            var form = pokemon.forms.FirstOrDefault(x => x.id == id);
            if (form == null)
            {
                throw new Exception("Attack with given ID was not found.");
            }
            pokemon.forms.RemoveAll(x => x.id == id);
            sr_helper.Save();
        }
    }
}

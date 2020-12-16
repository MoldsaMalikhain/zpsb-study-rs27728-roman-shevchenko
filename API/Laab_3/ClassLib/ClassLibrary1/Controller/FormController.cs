using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Controller
{
    class FormController : Controller
    {
        public FormController(SerializationHelper serializationHelper) : base(serializationHelper)
        {

        }

        public Form GetForm(string id)
        {
            foreach (var pokemon in serializationHelper.Pokedex.Pokemon)
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
            foreach (var pokemon in serializationHelper.Pokedex.Pokemon)
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
            serializationHelper.Save();

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
            serializationHelper.Save();
        }
    }
}

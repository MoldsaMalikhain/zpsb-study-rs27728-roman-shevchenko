using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeLib.Controllers
{
    public class Controller
    {
        protected SerializationHelper sr_helper;
        public Controller(SerializationHelper sr_helper)
        {
            this.sr_helper = sr_helper;
        }

    }
}

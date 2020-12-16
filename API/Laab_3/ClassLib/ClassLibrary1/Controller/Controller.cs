using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Controller
{
    class Controller
    {
        protected SerializationHelper serializationHelper;
        public Controller(SerializationHelper serializationHelper)
        {
            this.serializationHelper = serializationHelper;
        }
    }
}

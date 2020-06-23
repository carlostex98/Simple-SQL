using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto1
{
    class tabla
    {
        public string nombre;
        public tabla sig;
        public LinkedList<string> headers = new LinkedList<string>();
        public LinkedList<string> data_type = new LinkedList<string>();
        public LinkedList<string[]> content = new LinkedList<string[]>();
    }
}

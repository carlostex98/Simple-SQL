using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto1
{
    public class tabla
    {
        public string nombre;
        public tabla sig;
        public LinkedList<string> headers = new LinkedList<string>();
        public LinkedList<string> data_type = new LinkedList<string>();
        public LinkedList<string[]> content = new LinkedList<string[]>();

        public principal principal
        {
            get => default;
            set
            {
            }
        }

        public server_201700317 server_201700317
        {
            get => default;
            set
            {
            }
        }
    }
}

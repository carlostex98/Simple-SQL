using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto1
{
    public class server_201700317
    {
        tabla primero = null;
        tabla ultimo = null;

        public void new_table(String name)
        {
            if (primero==null)
            {
                tabla nuevo = new tabla();
                nuevo.nombre = name;
                primero = nuevo;
                ultimo = nuevo;
            }
            else
            {
                tabla nuevo = new tabla();
                nuevo.nombre = name;
                ultimo.sig = nuevo;
            }
        }

        public void add_header_last(string name)
        {
            ultimo.headers.AddLast(name);
        }

        public void insert_record(string name, string[] values)
        {
            tabla vista = primero;
            while (vista!=null)
            {
                if (vista.nombre.Equals(name,StringComparison.InvariantCultureIgnoreCase))
                {
                    vista.content.AddLast(values);
                }
                vista = vista.sig;
            }
        }



    }
}

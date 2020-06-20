using System;
using System.Collections.Generic;
using System.Linq;

namespace proyecto1
{
    public class listas
    {
        public LinkedList<string[]> tokens = new LinkedList<string[]>();//struct: nombre,valor,fila,columna
        public LinkedList<string[]> errores = new LinkedList<string[]>();//struct: valor,fila,columna

        public void in_token(string nombre, string valor, int ln, int cl)
        {
            string[] temp = { tokens.Count.ToString() + 1, nombre, valor, ln.ToString(), cl.ToString() };
            tokens.AddLast(temp);
        }

        public void in_error(string valor, int ln, int cl)
        {
            string[] temp = { errores.Count.ToString() + 1, valor, ln.ToString(), cl.ToString() };
            errores.AddLast(temp);
        }

        public void limpia_todo()
        {
            tokens.Clear();
            errores.Clear();
        }

        public void print_lst()
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                Console.WriteLine(tokens.ElementAt(i)[2]);
            }
            Console.WriteLine("-------------------------------------");
            for (int i = 0; i < errores.Count; i++)
            {
                Console.WriteLine(errores.ElementAt(i)[2]);
            }
        }


    }
}

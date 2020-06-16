using System.Collections.Generic;

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
    }
}

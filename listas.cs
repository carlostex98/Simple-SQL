using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace proyecto1
{
    public class listas
    {
        public LinkedList<string[]> tokens = new LinkedList<string[]>();//struct: nombre,valor,fila,columna
        public LinkedList<string[]> errores = new LinkedList<string[]>();//struct: valor,fila,columna
        private string header = "<!DOCTYPE html>\n"
            + "<html>\n"
            + "\n"
            + "<head>\n"
            + "    <meta charset=\"utf-8\">\n"
            + "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\n"
            + "    <title>Hello Bulma!</title>\n"
            + "    <link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/npm/bulma@0.9.0/css/bulma.min.css\">\n"
            + "</head>\n"
            + "\n"
            + "<body>\n"
            + "    <nav class=\"navbar is-dark\" role=\"navigation\" aria-label=\"main navigation\">\n"
            + "        <div class=\"navbar-brand\">\n"
            + "            <a class=\"navbar-item\" href=\"https://bulma.io\">\n"
            + "                <h2 class=\"is-white\">Compiladores</h2>\n"
            + "            </a>\n"
            + "            <a role=\"button\" class=\"navbar-burger\" aria-label=\"menu\" aria-expanded=\"false\">\n"
            + "                <span aria-hidden=\"true\"></span>\n"
            + "                <span aria-hidden=\"true\"></span>\n"
            + "                <span aria-hidden=\"true\"></span>\n"
            + "            </a>\n"
            + "        </div>\n"
            + "    </nav>\n"
            + "    <section class=\"is-full\">\n"
            + "        <table class=\"table is-full\">\n"
            + "            <thead>\n"
            + "                <tr>\n"
            + "                    <th><abbr>ID</abbr></th>\n" 
            + "                    <th><abbr title=\"Played\">Nombre</abbr></th>\n"
            + "                    <th><abbr title=\"Won\">Valor</abbr></th>\n"
            + "                    <th><abbr title=\"Drawn\">Linea</abbr></th>\n"
            + "                    <th><abbr title=\"Lost\">Columna</abbr></th>\n"
            + "                </tr>\n"
            + "            </thead>\n"
            + "            <tbody>";
        private string foo = "</tbody>\n"
            + "        </table>\n"
            + "    </section>\n"
            + "</body>\n"
            + "\n"
            + "</html>";


        private string header2 = "<!DOCTYPE html>\n"
            + "<html>\n"
            + "\n"
            + "<head>\n"
            + "    <meta charset=\"utf-8\">\n"
            + "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\n"
            + "    <title>Hello Bulma!</title>\n"
            + "    <link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/npm/bulma@0.9.0/css/bulma.min.css\">\n"
            + "</head>\n"
            + "\n"
            + "<body>\n"
            + "    <nav class=\"navbar is-dark\" role=\"navigation\" aria-label=\"main navigation\">\n"
            + "        <div class=\"navbar-brand\">\n"
            + "            <a class=\"navbar-item\" href=\"https://bulma.io\">\n"
            + "                <h2 class=\"is-white\">Compiladores</h2>\n"
            + "            </a>\n"
            + "            <a role=\"button\" class=\"navbar-burger\" aria-label=\"menu\" aria-expanded=\"false\">\n"
            + "                <span aria-hidden=\"true\"></span>\n"
            + "                <span aria-hidden=\"true\"></span>\n"
            + "                <span aria-hidden=\"true\"></span>\n"
            + "            </a>\n"
            + "        </div>\n"
            + "    </nav>\n"
            + "    <section class=\"is-full\">\n"
            + "        <table class=\"table is-full\">\n"
            + "            <thead>\n"
            + "                <tr>\n"
            + "                    <th><abbr>ID</abbr></th>\n"
            + "                    <th><abbr title=\"Won\">Valor</abbr></th>\n"
            + "                    <th><abbr title=\"Drawn\">Linea</abbr></th>\n"
            + "                    <th><abbr title=\"Lost\">Columna</abbr></th>\n"
            + "                </tr>\n"
            + "            </thead>\n"
            + "            <tbody>";
        

        public void in_token(string nombre, string valor, int ln, int cl)
        {
            string[] temp = { tokens.Count.ToString(), nombre, valor, ln.ToString(), cl.ToString() };
            tokens.AddLast(temp);
        }

        public void in_error(string valor, int ln, int cl)
        {
            string[] temp = { errores.Count.ToString(), valor, ln.ToString(), cl.ToString() };
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

        public void render_tokens()
        {
            Encoding ascii = Encoding.ASCII;
            StreamWriter bw;
            try
            {
                bw = new StreamWriter(new FileStream("201700317_tok.html", FileMode.Create), ascii);
                bw.WriteLine(header);
                for (int i = 0; i < tokens.Count; i++)
                {
                    bw.WriteLine("<tr>");
                    bw.WriteLine("<th>" + tokens.ElementAt(i)[0] + "</th>");
                    bw.WriteLine("<td>" + tokens.ElementAt(i)[1] + "</th>");
                    bw.WriteLine("<td>" + tokens.ElementAt(i)[2] + "</th>");
                    bw.WriteLine("<td>" + tokens.ElementAt(i)[3] + "</th>");
                    bw.WriteLine("<td>" + tokens.ElementAt(i)[4] + "</th>");
                    bw.WriteLine("</tr>");
                }
                bw.WriteLine(foo);
            }
            catch (IOException e2)
            {
                Console.WriteLine(e2.Message + "\n error.");
                return;
            }
            bw.Close();
        }

        public void render_errores()
        {
            Encoding ascii = Encoding.ASCII;
            StreamWriter bw;
            try
            {
                bw = new StreamWriter(new FileStream("201700317_err.html", FileMode.Create), ascii);
                bw.WriteLine(header2);
                for (int i = 0; i < errores.Count; i++)
                {
                    bw.WriteLine("<tr>");
                    bw.WriteLine("<th>" + errores.ElementAt(i)[0] + "</th>");
                    bw.WriteLine("<td>" + errores.ElementAt(i)[1] + "</th>");
                    bw.WriteLine("<td>" + errores.ElementAt(i)[2] + "</th>");
                    bw.WriteLine("<td>" + errores.ElementAt(i)[3] + "</th>");
                    bw.WriteLine("</tr>");
                }
                bw.WriteLine(foo);
            }
            catch (IOException e2)
            {
                Console.WriteLine(e2.Message + "\n error.");
                return;
            }
            bw.Close();
        }



    }
}

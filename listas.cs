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
            + "    <link href=\"https://fonts.googleapis.com/icon?family=Material+Icons\" rel=\"stylesheet\">\n"
            + "    <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css\">\n"
            + "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\n"
            + "</head>\n"
            + "\n"
            + "<body>\n"
            + "    <nav>\n"
            + "        <div class=\"nav-wrapper indigo darken-4\">\n"
            + "            <a href=\"#\" class=\"brand-logo center\">Compiladores</a>\n"
            + "        </div>\n"
            + "    </nav>\n"
            + "\n"
            + "    <body>\n"
            + "        <div class=\"container\">\n"
            + "            <table>\n"
            + "                <thead>\n"
            + "                    <tr>\n"
            + "                        <th>ID</th>\n"
            + "                        <th>Nombre</th>\n"
            + "                        <th>Valor</th>\n"
            + "                        <th>Linea</th>\n"
            + "                        <th>Columna</th>\n"
            + "                    </tr>\n"
            + "                </thead>\n"
            + "                <tbody>";
        private string foo = "</tbody>\n"
            + "            </table>\n"
            + "        </div>\n"
            + "    </body>\n"
            + "    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js\"></script>\n"
            + "</body>\n"
            + "\n"
            + "</html>";


        private string header2 = "<!DOCTYPE html>\n"
            + "<html>\n"
            + "\n"
            + "<head>\n"
            + "    <link href=\"https://fonts.googleapis.com/icon?family=Material+Icons\" rel=\"stylesheet\">\n"
            + "    <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css\">\n"
            + "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\n"
            + "</head>\n"
            + "\n"
            + "<body>\n"
            + "    <nav>\n"
            + "        <div class=\"nav-wrapper indigo darken-4\">\n"
            + "            <a href=\"#\" class=\"brand-logo center\">Compiladores</a>\n"
            + "        </div>\n"
            + "    </nav>\n"
            + "\n"
            + "    <body>\n"
            + "        <div class=\"container\">\n"
            + "            <table>\n"
            + "                <thead>\n"
            + "                    <tr>\n"
            + "                        <th>ID</th>\n"
            + "                        <th>Valor</th>\n"
            + "                        <th>Linea</th>\n"
            + "                        <th>Columna</th>\n"
            + "                    </tr>\n"
            + "                </thead>\n"
            + "                <tbody>";
        

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
                    bw.WriteLine("<th>" + tokens.ElementAt(i)[0] + "</td>");
                    bw.WriteLine("<td>" + tokens.ElementAt(i)[1] + "</td>");
                    bw.WriteLine("<td>" + tokens.ElementAt(i)[2] + "</td>");
                    bw.WriteLine("<td>" + tokens.ElementAt(i)[3] + "</td>");
                    bw.WriteLine("<td>" + tokens.ElementAt(i)[4] + "</td>");
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
                    bw.WriteLine("<th>" + errores.ElementAt(i)[0] + "</td>");
                    bw.WriteLine("<td>" + errores.ElementAt(i)[1] + "</td>");
                    bw.WriteLine("<td>" + errores.ElementAt(i)[2] + "</td>");
                    bw.WriteLine("<td>" + errores.ElementAt(i)[3] + "</td>");
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

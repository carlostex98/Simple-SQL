using System;
using System.IO;
using System.Linq;
using System.Text;

namespace proyecto1
{

    public class table_render
    {
        private string head = "<!DOCTYPE html>\n"
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
            + "             ";

        private string foot = " "
            + "        </div>\n"
            + "    </body>\n"
            + "    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js\"></script>\n"
            + "</body>\n"
            + "\n"
            + "</html>";

        public principal principal
        {
            get => default;
            set
            {
            }
        }

        public tabla tabla
        {
            get => default;
            set
            {
            }
        }

        public void graph_tables()
        {
            tabla vista = principal.dbms.ret_first();

            Encoding ascii = Encoding.ASCII;
            StreamWriter bw;
            try
            {
                bw = new StreamWriter(new FileStream("tablas.html", FileMode.Create), ascii);
                bw.WriteLine(head);
                while (vista != null)//for each table
                {
                    bw.WriteLine("<ul class=\"collection with-header \">");
                    bw.WriteLine("<li class=\"collection-header\">");
                    bw.WriteLine("<h4>" + vista.nombre + "</h4>");
                    bw.WriteLine("</li>");

                    for (int i = 0; i < vista.headers.Count; i++)
                    {
                        bw.WriteLine("<li class=\"collection-item\">" + vista.headers.ElementAt(i) + "<span class=\"new badge indigo darken-4\" data-badge-caption=\"\">" + vista.data_type.ElementAt(i) + "</span></li>");
                    }


                    bw.WriteLine("</ul>");

                    vista = vista.sig;
                }
                bw.WriteLine(foot);
            }
            catch (IOException e2)
            {
                Console.WriteLine(e2.Message + "\n error.");
                return;
            }
            bw.Close();



        }


        public void tablej()
        {
            tabla n = principal.dbms.ret_first();
            while (n!=null)
            {

                n = n.sig;
            }
        }


    }
}

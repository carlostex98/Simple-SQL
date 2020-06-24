using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace proyecto1
{
    public class server_201700317
    {
        private tabla primero = null;
        private tabla ultimo = null;
        private LinkedList<int> tmp = new LinkedList<int>();
        private LinkedList<string[]> tmp2 = new LinkedList<string[]>();
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
            + "            <table>";

        private string foot = "</table>\n"
            + "        </div>\n"
            + "    </body>\n"
            + "    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js\"></script>\n"
            + "</body>\n"
            + "\n"
            + "</html>";


        public void consulta_todo(string name)
        {
            Console.WriteLine("c");
            tabla vista = primero;
            while (vista != null)
            {
                if (vista.nombre.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    //render
                    //tmp2.Clear();
                    //first the headers
                    //the the results
                    Encoding ascii = Encoding.ASCII;
                    StreamWriter bw;
                    try
                    {
                        bw = new StreamWriter(new FileStream(name + ".html", FileMode.Create), ascii);
                        bw.WriteLine(head);
                        bw.WriteLine("<p class=\"flow-text\">Tabla: " + name + "</p>");
                        bw.WriteLine("<thead>");
                        bw.WriteLine("<tr>");
                        for (int i = 0; i < vista.headers.Count; i++)
                        {
                            bw.WriteLine("<th>" + vista.headers.ElementAt(i) + "</th>");
                        }
                        bw.WriteLine("</tr>");
                        bw.WriteLine("</thead>");
                        //the end
                        bw.WriteLine("<tbody>");
                        for (int i = 0; i < tmp2.Count; i++)
                        {
                            bw.WriteLine("<tr>");
                            for (int j = 0; j < tmp2.ElementAt(i).Length; j++)
                            {
                                bw.WriteLine("<td>" + tmp2.ElementAt(i)[j] + "</td>");
                            }
                            bw.WriteLine("</tr>");
                        }
                        bw.WriteLine("</tbody>");

                        bw.WriteLine(foot);
                    }
                    catch (IOException e2)
                    {
                        Console.WriteLine(e2.Message + "\n error.");
                        return;
                    }
                    bw.Close();



                    break;
                }
                vista = vista.sig;
            }
        }

        public void select_builder(string name, string[,] conditions)
        {
            tmp.Clear();
            tmp2.Clear();
            //with the selected ones
            tabla vista = primero;
            while (vista != null)
            {
                if (vista.nombre.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {

                    logic_filter(name, conditions);
                    for (int i = 0; i < vista.content.Count; i++)
                    {

                        if (tmp.Count == 0 && conditions.Length == 0)
                        {
                            //all
                            for (int j = 0; j < vista.content.Count; j++)
                            {
                                tmp2.AddLast(vista.content.ElementAt(i));
                            }
                        }
                        else
                        {
                            for (int j = 0; j < tmp.Count; j++)
                            {
                                if (i == tmp.ElementAt(j))
                                {
                                    //do something
                                    tmp2.AddLast(vista.content.ElementAt(i));
                                }
                            }
                        }


                    }

                    consulta_todo(name);
                    Process.Start(name + ".html");
                    break;
                }
                vista = vista.sig;
            }
        }


        public void new_table(String name)
        {
            if (primero == null)
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
                ultimo = nuevo;
            }
        }

        public void add_header_last(string name)
        {
            ultimo.headers.AddLast(name);
        }

        public void add_header_type_var(string name)
        {
            ultimo.data_type.AddLast(name);
        }


        public void insert_record(string name, string[] values)
        {
            tabla vista = primero;
            while (vista != null)
            {
                if (vista.nombre.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    //Console.WriteLine("rrrrr");
                    vista.content.AddLast(values);
                    break;
                }
                vista = vista.sig;
            }
        }


        public void update_record(string tabla, string[,] conditions, string[,] setter)
        {
            tabla vista = primero;
            while (vista != null)
            {
                if (vista.nombre.Equals(tabla, StringComparison.InvariantCultureIgnoreCase))
                {
                    logic_filter(tabla, conditions);
                    Console.WriteLine(tmp.Count);
                    for (int i = 0; i < vista.content.Count; i++)
                    {
                        string[] s = vista.content.ElementAt(i);

                        for (int j = 0; j < tmp.Count; j++)
                        {
                            if (i == tmp.ElementAt(j))
                            {
                                //do the update
                                //new values
                                //do replace
                                for (int k = 0; k < setter.Length / 2; k++)
                                {
                                    s[return_index_col(vista, setter[k, 0], i)] = setter[k, 1];
                                }

                            }

                        }
                        tmp2.AddLast(s);
                    }
                    vista.content.Clear();
                    for (int i = 0; i < tmp2.Count; i++)
                    {
                        vista.content.AddLast(tmp2.ElementAt(i));
                    }
                    break;

                }
                vista = vista.sig;
            }
        }


        public void delete_record(string tabla, string[,] conditions)
        {
            tmp.Clear();
            tmp2.Clear();

            //with the selected ones
            tabla vista = primero;
            while (vista != null)
            {
                if (vista.nombre.Equals(tabla, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (conditions.Length==0)
                    {
                        vista.content.Clear();
                    }
                    else
                    {
                        logic_filter(tabla, conditions);
                    }

                    for (int i = 0; i < vista.content.Count; i++)
                    {
                        for (int j = 0; j < tmp.Count; j++)
                        {
                            if (i != tmp.ElementAt(j))
                            {
                                //do something
                                tmp2.AddLast(vista.content.ElementAt(i));
                            }
                        }
                    }
                    vista.content.Clear();
                    for (int i = 0; i < tmp2.Count; i++)
                    {
                        vista.content.AddLast(tmp2.ElementAt(i));
                    }
                    break;

                }
                vista = vista.sig;
            }
        }



        private void logic_filter(string tabla, string[,] conditions)
        {
            bool t = true;

            tabla vista = primero;
            while (vista != null)
            {
                if (vista.nombre.Equals(tabla, StringComparison.InvariantCultureIgnoreCase))
                {
                    //val log
                    // id_val -0
                    // opr    -1
                    //value   -2
                    //priority-3

                    for (int i = 0; i < vista.content.Count; i++)
                    {
                        for (int j = 0; j < conditions.Length / 4; j++)
                        {
                            switch (conditions[j, 1])
                            {
                                case ">":
                                    //numeric or date
                                   
                                    if (num_val(remove_date(conditions[j, 2])))//reported
                                    {
                                        if (num_val(remove_date(ret_val_tab(vista, conditions[j, 0], i))))//requested
                                        {
                                            if (double.Parse(ret_val_tab(vista, conditions[j, 0], i)) > double.Parse(remove_date(conditions[j, 2])))
                                            {
                                                if (conditions[j, 3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    if (conditions.Length == 4)
                                                    {
                                                        t = true;
                                                    }
                                                    else
                                                    {
                                                        t = t && true;
                                                    }

                                                }
                                                else
                                                {
                                                    if (conditions.Length == 4)
                                                    {
                                                        t = true;
                                                    }
                                                    else
                                                    {
                                                        t = t || true;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (conditions[j, 3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    if (conditions.Length == 4)
                                                    {
                                                        t = false;
                                                    }
                                                    else
                                                    {
                                                        t = t && false;
                                                    }
                                                }
                                                else
                                                {
                                                    if (conditions.Length == 4)
                                                    {
                                                        t = false;
                                                    }
                                                    else
                                                    {
                                                        t = t || false;
                                                    }
                                                }
                                            }
                                        }


                                    }
                                    else
                                    {
                                        //kill this
                                        t = t && false;
                                    }

                                    break;
                                case "<":
                                    //numeric or date
                                    if (num_val(remove_date(conditions[j, 2])))//reported
                                    {
                                        if (num_val(remove_date(ret_val_tab(vista, conditions[j, 0], i))))//requested
                                        {
                                            if (double.Parse(ret_val_tab(vista, conditions[j, 0], i)) < double.Parse(remove_date(conditions[j, 2])))
                                            {
                                                if (conditions[j, 3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    if (conditions.Length == 4)
                                                    {
                                                        t = true;
                                                    }
                                                    else
                                                    {
                                                        t = t && true;
                                                    }
                                                }
                                                else
                                                {
                                                    if (conditions.Length == 4)
                                                    {
                                                        t = true;
                                                    }
                                                    else
                                                    {
                                                        t = t || true;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (conditions[j, 3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    if (conditions.Length == 4)
                                                    {
                                                        t = false;
                                                    }
                                                    else
                                                    {
                                                        t = t && false;
                                                    }
                                                }
                                                else
                                                {
                                                    if (conditions.Length == 4)
                                                    {
                                                        t = false;
                                                    }
                                                    else
                                                    {
                                                        t = t || false;
                                                    }
                                                }
                                            }
                                        }


                                    }
                                    else
                                    {
                                        //kill this
                                        t = t && false;
                                    }
                                    break;
                                case ">=":
                                    //numeric or date
                                    if (num_val(remove_date(conditions[j, 2])))//reported
                                    {
                                        if (num_val(remove_date(ret_val_tab(vista, conditions[j, 0], i))))//requested
                                        {
                                            if (double.Parse(ret_val_tab(vista, conditions[j, 0], i)) >= double.Parse(remove_date(conditions[j, 2])))
                                            {
                                                if (conditions[j, 3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    if (conditions.Length == 4)
                                                    {
                                                        t = true;
                                                    }
                                                    else
                                                    {
                                                        t = t && true;
                                                    }
                                                }
                                                else
                                                {
                                                    if (conditions.Length == 4)
                                                    {
                                                        t = true;
                                                    }
                                                    else
                                                    {
                                                        t = t || true;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (conditions[j, 3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    if (conditions.Length == 4)
                                                    {
                                                        t = false;
                                                    }
                                                    else
                                                    {
                                                        t = t && false;
                                                    }
                                                }
                                                else
                                                {
                                                    if (conditions.Length == 4)
                                                    {
                                                        t = false;
                                                    }
                                                    else
                                                    {
                                                        t = t || false;
                                                    }
                                                }
                                            }
                                        }


                                    }
                                    else
                                    {
                                        //kill this
                                        t = t && false;
                                    }
                                    break;
                                case "<=":
                                    //numeric or date

                                    //is date
                                    if (num_val(remove_date(conditions[j, 2])))//reported
                                    {
                                        if (num_val(remove_date(ret_val_tab(vista, conditions[j, 0], i))))//requested
                                        {
                                            if (double.Parse(ret_val_tab(vista, conditions[j, 0], i)) <= double.Parse(remove_date(conditions[j, 2])))
                                            {
                                                if (conditions[j, 3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    if (conditions.Length == 4)
                                                    {
                                                        t = true;
                                                    }
                                                    else
                                                    {
                                                        t = t && true;
                                                    }
                                                }
                                                else
                                                {
                                                    if (conditions.Length == 4)
                                                    {
                                                        t = true;
                                                    }
                                                    else
                                                    {
                                                        t = t || true;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (conditions[j, 3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    if (conditions.Length == 4)
                                                    {
                                                        t = false;
                                                    }
                                                    else
                                                    {
                                                        t = t && false;
                                                    }
                                                }
                                                else
                                                {
                                                    if (conditions.Length == 4)
                                                    {
                                                        t = false;
                                                    }
                                                    else
                                                    {
                                                        t = t || false;
                                                    }
                                                }
                                            }
                                        }


                                    }
                                    else
                                    {
                                        //kill this
                                        t = t && false;
                                    }

                                    break;
                                case "=":
                                    //string 
                                    Console.WriteLine(conditions[j, 2]);
                                    Console.WriteLine(ret_val_tab(vista, conditions[j, 0], i));
                                    if (conditions[j, 2].Equals(ret_val_tab(vista, conditions[j, 0], i), StringComparison.InvariantCultureIgnoreCase))
                                    {

                                        //means true
                                        if (conditions[j, 3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                        {
                                            if (conditions.Length == 4)
                                            {
                                                t = true;
                                            }
                                            else
                                            {
                                                t = t && true;
                                            }
                                        }
                                        else
                                        {
                                            if (conditions.Length == 4)
                                            {
                                                t = true;
                                            }
                                            else
                                            {
                                                t = t || true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (conditions[j, 3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                        {
                                            if (conditions.Length == 4)
                                            {
                                                t = false;
                                            }
                                            else
                                            {
                                                t = t && false;
                                            }
                                        }
                                        else
                                        {
                                            if (conditions.Length == 4)
                                            {
                                                t = false;
                                            }
                                            else
                                            {
                                                t = t && false;
                                            }
                                        }
                                    }
                                    break;
                                case "!=":
                                    //string 
                                    if (!conditions[j, 2].Equals(ret_val_tab(vista, conditions[j, 0], i), StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        //means true
                                        if (conditions[j, 3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                        {
                                            if (conditions.Length == 4)
                                            {
                                                t = true;
                                            }
                                            else
                                            {
                                                t = t && true;
                                            }
                                        }
                                        else
                                        {
                                            if (conditions.Length == 4)
                                            {
                                                t = true;
                                            }
                                            else
                                            {
                                                t = t || true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (conditions[j, 3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                        {
                                            if (conditions.Length == 4)
                                            {
                                                t = false;
                                            }
                                            else
                                            {
                                                t = t && false;
                                            }
                                        }
                                        else
                                        {
                                            if (conditions.Length == 4)
                                            {
                                                t = false;
                                            }
                                            else
                                            {
                                                t = t || false;
                                            }
                                        }
                                    }
                                    break;

                            }
                        }
                        if (t)
                        {
                            tmp.AddLast(i);
                        }
                    }
                    break;
                }
                vista = vista.sig;
            }
        }

        string ret_val_tab(tabla tmp, string col_header, int index)
        {
            String h = "";
            for (int i = 0; i < tmp.headers.Count; i++)
            {

                if (tmp.headers.ElementAt(i).Equals(col_header, StringComparison.InvariantCultureIgnoreCase))
                {
                    h = tmp.content.ElementAt(index)[i];
                    break;
                }
            }

            return h;
        }

        int return_index_col(tabla tmp, string col_header, int index)
        {
            int h = 0;
            for (int i = 0; i < tmp.headers.Count; i++)
            {
                if (tmp.headers.ElementAt(i).Equals(col_header, StringComparison.InvariantCultureIgnoreCase))
                {
                    h = i;
                    break;
                }
            }
            return h;
        }

        bool num_val(string dta)
        {
            bool s = false;
            //if has one or zero points
            int c = 0;
            for (int i = 0; i < dta.Length; i++)
            {
                if (dta[i] == '.')
                {
                    c++;
                }
            }
            if (c == 0 || c == 1)
            {
                s = true;
                
                for (int i = 0; i < dta.Length; i++)
                {
                    if (!(char.IsDigit(dta[i]) || dta[i] == '.'))
                    {
                        s = false;
                        break;
                    }
                }
            }
            else
            {
                s = false;
            }


            return s;
        }


        string remove_date(string dta)
        {
            //is pure digit
            string f = "";
            for (int i = 0; i < dta.Length; i++)
            {
                if (dta[i] != '/')
                {
                    f += dta[i];
                }
            }
            return f;
        }

        public tabla ret_first()
        {
            return primero;
        }

    }
}

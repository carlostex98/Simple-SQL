using System;
using System.Collections.Generic;
using System.Linq;

namespace proyecto1
{
    public class server_201700317
    {
        tabla primero = null;
        tabla ultimo = null;
        private LinkedList<int> tmp = new LinkedList<int>();
        private LinkedList<string[]> tmp2 = new LinkedList<string[]>();

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
                    vista.content.AddLast(values);
                    break;
                }
                vista = vista.sig;
            }
        }


        public void update_record(string tabla, string[][] conditions, string[][] setter)
        {
            tabla vista = primero;
            while (vista != null)
            {
                if (vista.nombre.Equals(tabla, StringComparison.InvariantCultureIgnoreCase))
                {
                    logic_filter(tabla, conditions);
                    for (int i = 0; i < vista.content.Count; i++)
                    {
                        string[] s = new string[vista.content.ElementAt(i).Length];
                        s = vista.content.ElementAt(i);
                        for (int j = 0; j < tmp.Count; j++)
                        {
                            if (i == tmp.ElementAt(j))
                            {
                                //do the update
                                //new values
                                //do replace
                                for (int k = 0; k < setter.Length; k++)
                                {
                                    s[return_index_col(vista, setter[k][0], i)] = setter[k][1];
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


        public void delete_record(string tabla, string[][] conditions)
        {
            tmp.Clear();
            tmp2.Clear();
            
            //with the selected ones
            tabla vista = primero;
            while (vista != null)
            {
                if (vista.nombre.Equals(tabla, StringComparison.InvariantCultureIgnoreCase))
                {
                    logic_filter(tabla, conditions);
                    for (int i = 0; i < vista.content.Count; i++)
                    {
                        for (int j = 0; j < tmp.Count; j++)
                        {
                            if (i!=tmp.ElementAt(j))
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



        private void logic_filter(string tabla, string[][] conditions)
        {
            bool t = true;
            bool f = false;
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
                        for (int j = 0; j < conditions.Length; j++)
                        {
                            switch (conditions[j][1])
                            {
                                case ">":
                                    //numeric or date
                                    if (num_val(remove_date(conditions[j][2])))//reported
                                    {
                                        if (num_val(remove_date(ret_val_tab(vista, conditions[j][0], i))))//requested
                                        {
                                            if (double.Parse(ret_val_tab(vista, conditions[j][0], i)) > double.Parse(remove_date(conditions[j][2])))
                                            {
                                                if (conditions[j][3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    t = t && true;
                                                }
                                                else
                                                {
                                                    t = t || true;
                                                }
                                            }
                                            else
                                            {
                                                if (conditions[j][3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    t = t && false;
                                                }
                                                else
                                                {
                                                    t = t || false;
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
                                    if (num_val(remove_date(conditions[j][2])))//reported
                                    {
                                        if (num_val(remove_date(ret_val_tab(vista, conditions[j][0], i))))//requested
                                        {
                                            if (double.Parse(ret_val_tab(vista, conditions[j][0], i)) < double.Parse(remove_date(conditions[j][2])))
                                            {
                                                if (conditions[j][3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    t = t && true;
                                                }
                                                else
                                                {
                                                    t = t || true;
                                                }
                                            }
                                            else
                                            {
                                                if (conditions[j][3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    t = t && false;
                                                }
                                                else
                                                {
                                                    t = t || false;
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
                                    if (num_val(remove_date(conditions[j][2])))//reported
                                    {
                                        if (num_val(remove_date(ret_val_tab(vista, conditions[j][0], i))))//requested
                                        {
                                            if (double.Parse(ret_val_tab(vista, conditions[j][0], i)) >= double.Parse(remove_date(conditions[j][2])))
                                            {
                                                if (conditions[j][3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    t = t && true;
                                                }
                                                else
                                                {
                                                    t = t || true;
                                                }
                                            }
                                            else
                                            {
                                                if (conditions[j][3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    t = t && false;
                                                }
                                                else
                                                {
                                                    t = t || false;
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
                                    if (num_val(remove_date(conditions[j][2])))//reported
                                    {
                                        if (num_val(remove_date(ret_val_tab(vista, conditions[j][0], i))))//requested
                                        {
                                            if (double.Parse(ret_val_tab(vista, conditions[j][0], i)) <= double.Parse(remove_date(conditions[j][2])))
                                            {
                                                if (conditions[j][3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    t = t && true;
                                                }
                                                else
                                                {
                                                    t = t || true;
                                                }
                                            }
                                            else
                                            {
                                                if (conditions[j][3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    t = t && false;
                                                }
                                                else
                                                {
                                                    t = t || false;
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
                                    if (conditions[j][i].Equals(ret_val_tab(vista, conditions[j][0], i), StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        //means true
                                        if (conditions[j][3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                        {
                                            t = t && true;
                                        }
                                        else
                                        {
                                            t = t || true;
                                        }
                                    }
                                    else
                                    {
                                        if (conditions[j][3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                        {
                                            t = t && false;
                                        }
                                        else
                                        {
                                            t = t || false;
                                        }
                                    }
                                    break;
                                case "!=":
                                    //string 
                                    if (!conditions[j][i].Equals(ret_val_tab(vista, conditions[j][0], i), StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        //means true
                                        if (conditions[j][3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                        {
                                            t = t && true;
                                        }
                                        else
                                        {
                                            t = t || true;
                                        }
                                    }
                                    else
                                    {
                                        if (conditions[j][3].Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                                        {
                                            t = t && false;
                                        }
                                        else
                                        {
                                            t = t || false;
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
                    if (!char.IsDigit(dta[i]) || dta[i] != '.')
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

    }
}

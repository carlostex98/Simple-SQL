using System.Collections.Generic;
using System.Linq;

namespace proyecto1
{
    class sintactico_201700317
    {
        LinkedList<string> nodos = new LinkedList<string>();
        LinkedList<string> rels = new LinkedList<string>();
        string[] resv = { "ENTERO", "CADENA", "FLOTANTE", "FECHA" };
        string[] var_cont = { "IDENTIFICADOR", "FECHA", "ENTERO", "DECIMAL", "CADENA" };
        string t1 = "";
        string t2 = "";
        string t3 = "";

        int p1 = 0; //nodos padre numero
        int p2 = 0;
        int p3 = 0;

        bool s = true;
        int x = 0;
        int n = 0;


        void clean_all()
        {
            s = true;
            x = 0;
            nodos.Clear();
            rels.Clear();
        }

        public void start_x()
        {
            clean_all();

            if (!is_same("EOF"))
            {
                main_x();
            }


        }

        void main_x()
        {
            //this correspond to the base lang start
            if (is_same("crear"))
            {
                next_t();
                //TABLA ID ( ID TYPE ++ );
                if (is_same("tabla"))
                {
                    next_t();

                }
                else
                {
                    s = false;
                }

                if (s && is_type("identificador"))
                {
                    //get id
                    nodos.AddLast("e" + n.ToString() + "[label=\"TABLA - " + ret_curr()[2] + " \"];\n");
                    rels.AddLast("ex0 -> e" + n.ToString() + "; \n");
                    p1 = n;
                    n++;
                    next_t();
                }
                else
                {
                    s = false;
                }

                if (s && is_same("("))
                {
                    next_t();
                }
                else
                {
                    s = false;
                }
                //ID type_var
                tab_vars();

                if (s && is_same(")"))
                {
                    next_t();
                }
                else
                {
                    s = false;
                }

                if (s && is_same(";"))
                {
                    next_t();
                }
                else
                {
                    s = false;
                }

                s = true;
                if (!is_same("EOF"))
                {
                    main_x();
                }


            }
            else if (is_same("insertar"))
            {
                next_t();
                if (is_same("en"))
                {
                    next_t();

                }
                else
                {
                    s = false;
                }

                if (s && is_type("identificador"))
                {
                    //get id
                    nodos.AddLast("e" + n.ToString() + "[label=\"INSERTAR EN TABLA - " + ret_curr()[2] + " \"];\n");
                    rels.AddLast("ex0 -> e" + n.ToString() + "; \n");
                    p1 = n;
                    n++;
                    next_t();
                }
                else
                {
                    s = false;
                }

                if (s && is_same("valores"))
                {
                    next_t();
                }
                else
                {
                    s = false;
                }

                if (s && is_same("("))
                {
                    next_t();
                }
                else
                {
                    s = false;
                }
                //ID type_var
                //new node valores
                if (s)
                {
                    nodos.AddLast("e" + n.ToString() + "[label=\"VALORES TABLA \"];\n");
                    rels.AddLast("e" + p1.ToString() + " -> e" + n.ToString() + "; \n");
                    p1 = n;
                    n++;
                }


                insert_vars();

                if (s && is_same(")"))
                {
                    next_t();
                }
                else
                {
                    s = false;
                }

                if (s && is_same(";"))
                {
                    next_t();
                }
                else
                {
                    s = false;
                }

                s = true;
                if (!is_same("EOF"))
                {
                    main_x();
                }

            }
            else if (is_same("eliminar"))
            {
                next_t();
                //DE ID DONDE LOGIC_EXPR --rr;
                if (is_same("de"))
                {
                    next_t();
                }
                else
                {
                    s = false;
                }
                if (s && is_type("identificador"))
                {
                    //node name
                    nodos.AddLast("e" + n.ToString() + "[label=\"ELIMINAR EN TABLA - " + ret_curr()[2] + " \"];\n");
                    rels.AddLast("ex0 -> e" + n.ToString() + "; \n");
                    p1 = n;
                    n++;

                    next_t();
                }
                else
                {
                    s = false;
                }

                if (s && is_same("donde"))
                {
                    //create node logic cond
                    nodos.AddLast("e" + n.ToString() + "[label=\"CONDICIONAL \"];\n");
                    rels.AddLast("e" + p1.ToString() + " -> e" + n.ToString() + "; \n");
                    p1 = n;
                    n++;

                    next_t();
                    logic_expr_del();

                }//if not contains donde we expect ';'


                if (s && is_same(";"))
                {
                    next_t();
                }
                else
                {
                    s = false;
                }
                if (!is_same("EOF"))
                {
                    main_x();
                }
                s = true;

            }
            else if (is_same("actualizar"))
            {
                next_t();
            }
            else if (is_same("seleccionar"))
            {
                next_t();
                //* DE VAL_ARR DONDE LOGIC_XPR||JOIN_EXPR;
            }
            else
            {
                //error
                //PANIC MODE
            }

        }

        void logic_expr_del()
        {
            //ID SYM_COM VAR_VALUE (Y || 0   THIS);
            if (s && is_type("identificador"))
            {
                next_t();
                t2 = ret_curr()[2];

            }
            else
            {
                s = false;
            }

            if (s && is_comp())
            {
                next_t();
            }
            else
            {
                s = false;
            }
            //var value
            if (s && is_content_var())
            {
                nodos.AddLast("e" + n.ToString() + "[label=\" " + t2 + " " + t1 + " " + ret_curr()[2] + " \"];\n");
                //rels.AddLast("e" + p1.ToString() + " -> e" + n.ToString() + "; \n");
                n++;

                next_t();
                ex_logic();
            }
            else
            {
                s = false;
            }

        }

        void ex_logic()
        {
            // Y | O | EMPTY
            if (is_same("y"))
            {

            }
            else if (is_same("o"))
            {

            }
            else
            {

            }
        }


        void tab_vars()
        {
            // id type
            if (s && is_type("identificador"))
            {
                //get id
                t1 = ret_curr()[2];
                next_t();
            }
            else
            {
                s = false;
            }

            if (s && is_var_type())
            {
                nodos.AddLast("e" + n.ToString() + "[label=\" " + t1 + "- " + ret_curr()[2] + " \"];\n");
                rels.AddLast("e" + p1.ToString() + " -> e" + n.ToString() + "; \n");
                n++;

                next_t();
                v2();
            }
            else
            {
                s = false;
            }
        }

        void v2()
        {
            //COMA OR DIE
            if (s && is_same(","))
            {
                next_t();
                tab_vars();
            }
            else
            {
                //stop
                //this means the end of this part
            }
        }

        void insert_vars()
        {

            if (s && is_content_var())
            {
                nodos.AddLast("e" + n.ToString() + "[label=\" " + ret_curr()[2] + " \"];\n");
                rels.AddLast("e" + p1.ToString() + " -> e" + n.ToString() + "; \n");
                n++;

                next_t();
                v4();
            }
            else
            {
                s = false;
            }
        }

        void v4()
        {
            if (s && is_same(","))
            {
                next_t();
                insert_vars();
            }
            else
            {
                //stop
                //this means the end of this part
            }
        }




        string[] ret_curr()
        {
            return principal.lst.tokens.ElementAt(x);
        }

        void next_t()
        {
            x++;
        }

        bool is_same(string z)
        {
            return ret_curr()[2].ToUpper().Equals(z.ToUpper());
        }

        bool is_type(string z)
        {
            return ret_curr()[1].ToUpper().Equals(z.ToUpper());
        }

        bool is_var_type()
        {
            return resv.Contains(ret_curr()[2].ToUpper());
        }

        bool is_content_var()
        {
            return var_cont.Contains(ret_curr()[2].ToUpper());
        }

        bool is_comp()
        {
            bool nd = false;
            if (is_same(">"))
            {
                nd = true;
                //we espect = or empty
                t1 = ">";
                next_t();
                if (is_same("="))
                {
                    t1 = ">=";
                    next_t();
                }
                else
                {
                    //not
                }
            }
            else if (is_same("<"))
            {
                nd = true;
                t1 = "<";
                next_t();
                if (is_same("="))
                {
                    t1 = "<=";
                    next_t();
                }
                else
                {
                    //not
                }
            }
            else if (is_same("="))
            {
                next_t();
                if (is_same("="))
                {
                    t1 = "==";
                    nd = true;
                    next_t();
                }
                else
                {
                    //not
                    //error
                }
            }
            else if (is_same("!"))
            {
                next_t();
                if (is_same("="))
                {
                    t1 = "!=";
                    nd = true;
                    next_t();
                }
                else
                {
                    //not
                    //error
                }
            }

            return nd;
        }

    }
}

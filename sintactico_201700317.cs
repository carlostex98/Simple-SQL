using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace proyecto1
{
    public class sintactico_201700317
    {
        LinkedList<string> nodos = new LinkedList<string>();
        LinkedList<string> rels = new LinkedList<string>();

        LinkedList<string> tmp1 = new LinkedList<string>();

        string[] resv = { "ENTERO", "CADENA", "FLOTANTE", "FECHA" };
        string[] var_cont = { "IDENTIFICADOR", "FECHA", "ENTERO", "DECIMAL", "CADENA", "IDENTIFICADOR 2" };
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
            ast();

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
                    error_panic();
                }

                if (s && is_type("identificador"))
                {
                    //get id
                    nodos.AddLast("e" + n.ToString() + "[label=\"TABLA - " + ret_curr()[2] + " \"];\n");
                    rels.AddLast("ex0 -> e" + n.ToString() + "; \n");
                    p1 = n;
                    n++;
                    principal.dbms.new_table(ret_curr()[2]);
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
                    error_panic();
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
                    error_panic();
                }

                if (s && is_same(";"))
                {
                    next_t();
                }
                else
                {
                    s = false;
                    error_panic();
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
                    error_panic();
                }

                if (s && is_type("identificador"))
                {
                    //get id
                    t1 = ret_curr()[2];
                    nodos.AddLast("e" + n.ToString() + "[label=\"INSERTAR EN TABLA - " + ret_curr()[2] + " \"];\n");
                    rels.AddLast("ex0 -> e" + n.ToString() + "; \n");
                    p1 = n;
                    n++;
                    next_t();
                }
                else
                {
                    s = false;
                    error_panic();
                }

                if (s && is_same("valores"))
                {
                    next_t();
                }
                else
                {
                    s = false;
                    error_panic();
                }

                if (s && is_same("("))
                {
                    next_t();
                }
                else
                {
                    s = false;
                    error_panic();
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
                    error_panic();
                }

                if (s && is_same(";"))
                {
                    next_t();
                }
                else
                {
                    s = false;
                    error_panic();
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
                    error_panic();
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
                    error_panic();
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
                    error_panic();
                }
                s = true;
                if (!is_same("EOF"))
                {
                    main_x();
                }


            }
            else if (is_same("actualizar"))
            {
                next_t();
                //ID ESTABLECER (LIST) DONDE LOGIC_EXP? ;

                if (s && is_type("identificador"))
                {
                    //node name
                    nodos.AddLast("e" + n.ToString() + "[label=\"ACTUALIZAR TABLA - " + ret_curr()[2] + " \"];\n");
                    rels.AddLast("ex0 -> e" + n.ToString() + "; \n");
                    p1 = n;
                    p2 = p1;
                    n++;

                    next_t();
                }
                else
                {
                    s = false;
                    error_panic();
                }

                if (s && is_same("establecer"))
                {
                    next_t();
                }
                else
                {
                    s = false;
                    error_panic();
                }
                if (s && is_same("("))
                {
                    nodos.AddLast("e" + n.ToString() + "[label=\"SETERS \"];\n");
                    rels.AddLast("e" + p1.ToString() + " -> e" + n.ToString() + "; \n");
                    p1 = n;
                    n++;

                    next_t();
                    //run the list of seters
                    lst_seters();
                }
                else
                {
                    s = false;
                    error_panic();
                }

                if (s && is_same(")"))
                {
                    next_t();
                }
                else
                {
                    s = false;
                    error_panic();
                }


                if (s && is_same("donde"))
                {
                    //create node logic cond
                    p1 = p2;
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
                    error_panic();
                }
                s = true;
                if (!is_same("EOF"))
                {
                    main_x();
                }


            }
            else if (is_same("seleccionar"))
            {
                next_t();
                nodos.AddLast("e" + n.ToString() + "[label=\"SELECCIONAR \"];\n");
                rels.AddLast("ex0 -> e" + n.ToString() + "; \n");
                p1 = n;
                n++;
                //* DE VAL_ARR DONDE LOGIC_XPR||JOIN_EXPR;
                nodos.AddLast("e" + n.ToString() + "[label=\"COLUMNAS\"];\n");
                rels.AddLast("e" + p1.ToString() + " -> e" + n.ToString() + "; \n");
                p2 = n;
                n++;
                if (is_same("*"))
                {
                    //this include all the table headers
                    nodos.AddLast("e" + n.ToString() + "[label=\"*\"];\n");
                    rels.AddLast("e" + p2.ToString() + " -> e" + n.ToString() + "; \n");
                    n++;
                    next_t();
                }
                else
                {
                    lst_camp_table();
                }

                if (s && is_same("de"))
                {
                    //this include all the table headers
                    nodos.AddLast("e" + n.ToString() + "[label=\"TABLAS\"];\n");
                    rels.AddLast("e" + p1.ToString() + " -> e" + n.ToString() + "; \n");
                    p2 = n;
                    n++;


                    next_t();
                    //call table array
                    table_array();
                }
                else
                {
                    s = false;
                    error_panic();
                }

                if (s && is_same("donde"))
                {
                    nodos.AddLast("e" + n.ToString() + "[label=\"CONDICIONAL \"];\n");
                    rels.AddLast("e" + p1.ToString() + " -> e" + n.ToString() + "; \n");
                    p1 = n;
                    n++;

                    next_t();
                    logic_expr_del();
                }//without else

                if (is_same(";"))
                {
                    //end of line

                }
                else
                {
                    s = false;
                    error_panic();
                }
                s = true;
                if (!is_same("EOF"))
                {
                    main_x();
                }


            }
            else
            {
                //error
                //PANIC MODE
                error_panic();
            }

        }

        void table_array()
        {
            //ID, ID, ID, ID....
            if (is_type("identificador"))
            {
                nodos.AddLast("e" + n.ToString() + "[label=\" " + ret_curr()[2] + " \"];\n");
                rels.AddLast("e" + p2.ToString() + " -> e" + n.ToString() + "; \n");
                n++;
                next_t();
                coma_table();
            }
            else
            {
                s = false;
                error_panic();
            }
        }

        void coma_table()
        {
            if (is_same(","))
            {
                next_t();
                table_array();
            }
            else
            {
                //return to home
            }
        }


        void lst_camp_table()
        {
            if (is_type("identificador"))
            {
                t1 = ret_curr()[2];
                next_t();
                if (is_same("como"))
                {
                    next_t();
                    //we look for id
                    if (is_type("identificador"))
                    {
                        nodos.AddLast("e" + n.ToString() + "[label=\" " + t1 + "->" + ret_curr()[2] + " \"];\n");
                        rels.AddLast("e" + p2.ToString() + " -> e" + n.ToString() + "; \n");
                        n++;
                        next_t();
                        nxt_tab();
                    }
                    else
                    {
                        s = false;
                        error_panic();
                    }
                }
                else
                {
                    //without alias
                    nodos.AddLast("e" + n.ToString() + "[label=\" " + t1 + " \"];\n");
                    rels.AddLast("e" + p2.ToString() + " -> e" + n.ToString() + "; \n");
                    n++;
                    nxt_tab();
                }
            }
            else if (is_type("identificador 2"))
            {
                t1 = ret_curr()[2];
                next_t();
                if (is_same("como"))
                {
                    if (is_type("identificador"))
                    {
                        nodos.AddLast("e" + n.ToString() + "[label=\" " + t1 + "->" + ret_curr()[2] + " \"];\n");
                        rels.AddLast("e" + p2.ToString() + " -> e" + n.ToString() + "; \n");
                        n++;
                        next_t();
                        nxt_tab();
                    }
                    else
                    {
                        s = false;
                    }
                }
                else
                {
                    //without alias
                    nodos.AddLast("e" + n.ToString() + "[label=\" " + ret_curr()[2] + " \"];\n");
                    rels.AddLast("e" + p2.ToString() + " -> e" + n.ToString() + "; \n");
                    n++;
                    nxt_tab();
                }
            }
            else
            {
                s = false;
                //error
                error_panic();
            }
        }

        void nxt_tab()
        {
            if (is_same(","))
            {
                nxt_tab();
                lst_camp_table();
            }
            else
            {
                //return to home
            }
        }

        void lst_seters()
        {
            //ID = VALUE 
            if (is_type("identificador"))
            {
                t1 = ret_curr()[2];
                next_t();

            }
            else
            {
                s = false;
                error_panic();
            }

            if (s && is_same("="))
            {
                next_t();
            }
            else
            {
                s = false;
                error_panic();
            }

            if (s && is_content_var())
            {
                nodos.AddLast("e" + n.ToString() + "[label=\" " + t1 + " -> " + ret_curr()[2] + " \"];\n");
                rels.AddLast("e" + p1.ToString() + " -> e" + n.ToString() + "; \n");
                n++;
                next_t();
                ex_lst();
            }
            else
            {
                Console.WriteLine("y");
                s = false;
                error_panic();
            }
        }

        void ex_lst()
        {
            if (is_same(","))
            {
                next_t();
                lst_seters();
            }
            else
            {
                //return to regular
            }
        }

        void logic_expr_del()
        {
            //ID SYM_COM VAR_VALUE (Y || 0   THIS);
            if (s && is_type("identificador"))
            {
                t2 = ret_curr()[2];
                next_t();
            }
            else
            {
                s = false;
                error_panic();
            }

            if (s && is_comp())
            {
                //next_t();
                //dont need next
            }
            else
            {
                s = false;
                error_panic();
            }
            //var value
            if (s && is_content_var())
            {
                nodos.AddLast("e" + n.ToString() + "[label=\" " + t2 + " " + t1 + " " + ret_curr()[2] + " \"];\n");
                //rels.AddLast("e" + p1.ToString() + " -> e" + n.ToString() + "; \n");
                p2 = n;
                n++;
                next_t();
                ex_logic();
            }
            else
            {
                s = false;
                error_panic();
            }

        }

        void ex_logic()
        {
            // Y | O | EMPTY
            if (is_same("y"))
            {
                nodos.AddLast("e" + n.ToString() + "[label=\" Y \"];\n");
                rels.AddLast("e" + p1.ToString() + " -> e" + n.ToString() + "; \n");
                rels.AddLast("e" + n.ToString() + " -> e" + p2.ToString() + "; \n");
                p1 = n;
                n++;
                next_t();
                logic_expr_del();
            }
            else if (is_same("o"))
            {
                nodos.AddLast("e" + n.ToString() + "[label=\" Y \"];\n");
                rels.AddLast("e" + p1.ToString() + " -> e" + n.ToString() + "; \n");
                rels.AddLast("e" + n.ToString() + " -> e" + p2.ToString() + "; \n");
                p1 = n;
                n++;
                next_t();
                logic_expr_del();
            }
            else
            {
                //end of derivation
                rels.AddLast("e" + p1.ToString() + " -> e" + p2.ToString() + "; \n");

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
                principal.dbms.add_header_last(ret_curr()[2]);
            }
            else
            {
                s = false;
                error_panic();
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
                error_panic();
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
                tmp1.AddLast(ret_curr()[2]);
                nodos.AddLast("e" + n.ToString() + "[label=\" " + ret_curr()[2] + " \"];\n");
                rels.AddLast("e" + p1.ToString() + " -> e" + n.ToString() + "; \n");
                n++;

                next_t();
                v4();
            }
            else
            {
                s = false;
                error_panic();
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
                string[] z = new string[tmp1.Count];
                for (int i = 0; i < tmp1.Count; i++)
                {
                    z[i] = tmp1.ElementAt(i);
                }
                tmp1.Clear();
                principal.dbms.insert_record(t1,z);
            }
        }




        string[] ret_curr()
        {
            return principal.lst.tokens.ElementAt(x);
        }

        void next_t()
        {
            x++;
            if (x == principal.lst.tokens.Count)
            {
                x--;
            }
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
            return var_cont.Contains(ret_curr()[1].ToUpper());
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
                t1 = "=";
                nd = true;
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

        void error_panic()
        {
            //manage
            //run until ';' or 'EOF'
            Console.WriteLine(ret_curr()[2]);
            while (!ret_curr()[2].Equals(";"))
            {
                next_t();
                Console.WriteLine("siu");
                if (ret_curr()[2].Equals("EOF"))
                {
                    break;
                }

            }
            //if ok -> ; or EOF
            next_t();

        }

        public void ast()
        {
            Encoding ascii = Encoding.ASCII;
            StreamWriter bw;
            String file_name = "ast.dot";
            try
            {
                bw = new StreamWriter(new FileStream(file_name, FileMode.Create), ascii);
                bw.WriteLine("digraph D {");
                bw.WriteLine("node [shape=box];");
                bw.WriteLine("ex0 [label=\" MAIN PROGRAM \"];");
                for (int i = 0; i < nodos.Count; i++)
                {
                    bw.WriteLine(nodos.ElementAt(i));
                }
                for (int i = 0; i < rels.Count; i++)
                {
                    bw.WriteLine(rels.ElementAt(i));
                }
                bw.WriteLine("}");


                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine("dot " + file_name + " -Tpng -o ast.png");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());


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

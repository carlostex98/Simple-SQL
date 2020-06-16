using System.Linq;

namespace proyecto1
{
    class lexer_201700317
    {
        string[] res = { };//reservadas
        string[] sim = { };// simbolos
        string f = "";
        int ln = 1;
        int cl = 1;
        public void analizador(string data)
        {
            char c = ' ';
            char v = ' ';
            int e = 0;
            for (int i = 0; i < data.Length; i++)
            {
                cl++;
                c = data[i];

                if (i + 1 < data.Length)
                {
                    v = data[i + 1];
                }

                switch (e)
                {
                    case 0:
                        //initial state
                        if (c == '-' && v == '-')
                        {
                            //one line coment
                            e = 1;
                        }
                        else if (c == '/' && v == '*')
                        {
                            //multiline
                            e = 2;
                        }
                        else if (char.IsDigit(c))
                        {
                            //number digit or float
                            e = 3;
                        }
                        else if (char.IsLetter(c) || c == '_')
                        {
                            //id
                            e = 4;
                        }
                        else if (c == '\"')
                        {
                            //string
                            e = 5;
                        }
                        else if (c == '\'')
                        {
                            //date
                            e = 6;
                        }
                        else if (c == ' ' || c == '\t' || c == '\n')
                        {
                            //carret changer
                            //nothing state
                            cl = 1;
                            ln++;
                        }
                        else if (check_symbol(char.ToString(c)))
                        {
                            //is symbol
                        }
                        else
                        {
                            //error jaja
                        }
                        break;
                    case 1:
                        if (c == '\n')
                        {
                            //end state
                            e = 0;
                        }
                        break;
                    case 2:
                        if (c == '*' && v == '/')
                        {
                            //end state
                            e = 0;
                            i++;
                        }
                        break;
                    case 3:
                        //number validator
                        if (char.IsDigit(c))
                        {
                            f += c;
                        }
                        else if (c == '.')
                        {
                            //decimal
                            e = 20;
                            f += c;
                        }
                        else
                        {
                            //end state
                            principal.lst.in_token("Entero", f, ln, cl);
                            f = "";
                            e = 0;
                            i--;
                        }

                        break;
                    case 4:
                        if (char.IsLetterOrDigit(c) || c == '_')
                        {
                            //id
                            f += c;
                        }
                        else
                        {
                            //end state
                            if (check_reserved(f))
                            {
                                principal.lst.in_token("Reservada", f, ln, cl);
                            }
                            else
                            {
                                principal.lst.in_token("Identificador", f, ln, cl);
                            }
                            
                            f = "";
                            e = 0;
                            f = "";
                        }
                        break;
                    case 5:
                        if (c == '\"')
                        {
                            principal.lst.in_token("Cadena", f, ln, cl);
                            f = "";
                            e = 0;
                        }
                        else
                        {
                            f += c;
                        }
                        break;
                    case 6:
                        if (c == '\'')
                        {
                            principal.lst.in_token("Fecha", f, ln, cl);
                            f = "";
                            e = 0;
                        }
                        else
                        {
                            f += c;
                        }
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 20:
                        if (char.IsDigit(c))
                        {
                            f += c;
                        }
                        else
                        {
                            //end state
                            principal.lst.in_token("Decimal", f, ln, cl);
                            f = "";
                            i--;
                        }
                        break;
                }
            }

        }

        bool check_reserved(string word)
        {

            if (res.Contains(word))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        bool check_symbol(string word)
        {

            if (sim.Contains(word))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}

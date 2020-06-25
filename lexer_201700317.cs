using System.Linq;

namespace proyecto1
{
    public class lexer_201700317
    {
        string[] res = {"CREAR", "TABLA", "INSERTAR", "EN", "VALORES", "SELECCIONAR", "COMO", "DE", "DONDE",
                        "Y", "O", "ELIMINAR", "ACTUALIZAR", "ESTABLECER", "ENTERO", "CADENA", "FLOTANTE", "FECHA"
                        };//reservadas
        string[] sim = { ">", "<", "=", "!", "*", ",", ";", ".", "(", ")" };// simbolos
        string f = "";
        int ln = 1;
        int cl = 1;

        public principal principal
        {
            get => default;
            set
            {
            }
        }

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
                        else if (char.IsDigit(c)||c=='-')
                        {
                            //number digit or float
                            //accept negatives
                            e = 3;
                            f += c;
                        }
                        else if (char.IsLetter(c) || c == '_')
                        {
                            //id
                            e = 4;
                            f += c;
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
                            principal.lst.in_token("Symbolo", char.ToString(c), ln, cl);
                        }
                        else
                        {
                            //error jaja
                            principal.lst.in_error(c.ToString(),ln,cl);
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
                        else if (c == '.')
                        {
                            //special id
                            f += c;
                            e = 21;
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
                            i--;
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
                    case 21:
                        if (char.IsLetterOrDigit(c) || c == '_')
                        {
                            //id
                            f += c;
                        }
                        else
                        {

                            principal.lst.in_token("Identificador 2", f, ln, cl);
                            e = 0;
                            f = "";
                            i--;
                        }
                        break;
                }
            }

            principal.lst.in_token("EOF", "EOF", -1, -1);
        }

        bool check_reserved(string word)
        {

            return res.Contains(word.ToUpper());

        }
        bool check_symbol(string word)
        {

            return sim.Contains(word);

        }

    }
}

namespace proyecto1
{
    class lexer_201700317
    {
        string[] res = { };//reservadas
        string[] sim = { };// simbolos
        public void analizador(string data)
        {


            char c = ' ';
            char v = ' ';
            int e = 0;
            for (int i = 0; i < data.Length; i++)
            {
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
                            //number digit or float or date
                            e = 3;
                        }
                        else if (char.IsLetter(c) || c=='_')
                        {
                            //id
                            e = 4;
                        }
                        else if (c=='\"')
                        {
                            //cadena dob
                            e = 5;
                        }
                        else if (c == '\'')
                        {
                            //cadena simp
                            e = 6;
                        }
                        else if (c==' ' || c=='\t' || c=='\n')
                        {
                            //carret changer
                            //nothing state
                        }
                        else
                        {
                            //error jaja
                        }
                        break;
                    case 1:
                        if (c=='\n')
                        {
                            //end state
                        }
                        break;
                    case 2:
                        if (c == '*' && v == '/')
                        {
                            //end state
                        }
                        break;
                    case 3:
                        //date validator here
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                }
            }

        }
    }
}

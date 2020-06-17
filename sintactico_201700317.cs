using System.Linq;

namespace proyecto1
{
    class sintactico_201700317
    {
        bool s = true;
        int x = 0;

        void clean_all()
        {
            s = true;
            x = 0;
        }

        void start_x()
        {
            clean_all();

        }

        void main_x()
        {
            //this correspond to the base lang start
            if (is_same("crear"))
            {
                next_t();
                //ID ( ID TYPE ++ );

            }
            else if (is_same("insertar"))
            {
                next_t();
                //EN ID VALORES (VAL_ARR --rr);
            }
            else if (is_same("eliminar"))
            {
                next_t();
                //DE ID DONDE LOGIC_EXPR --rr;
            }
            else if (is_same("actualizar"))
            {
                next_t();
            }
            else if (is_same("seleccionar"))
            {
                next_t();
                //* DE VAL_ARR DONDE LOGIC_XPR;
            }
            else
            {
                //error
                //PANIC MODE
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



    }
}

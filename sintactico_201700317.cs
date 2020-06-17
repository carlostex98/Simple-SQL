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

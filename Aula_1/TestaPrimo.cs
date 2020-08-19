using System;
using System.Collections.Generic;
using System.Text;

namespace Aula_1
{
    class TestaPrimo
    {
        /// <summary>
        /// Enables the use of the function "TestaPrimo1" as a variable
        /// </summary>
        public static Func<int, bool> TestaPrimo1Del = n =>
        {
            return TestaPrimo1(n);
        };

        /// <summary>
        /// Enables the use of the function "TestaPrimo2" as a variable
        /// </summary>
        public static Func<int, bool> TestaPrimo2Del = n =>
        {
            return TestaPrimo2(n);
        };

        /// <summary>
        /// Enables the use of the function "TestaPrimo3" as a variable
        /// </summary>
        public static Func<int, bool> TestaPrimo3Del = n =>
        {
            return TestaPrimo3(n);
        };

        /// <summary>
        /// Enables the use of the function "TestaPrimo1" as a variable
        /// </summary>
        public static Func<int, bool> TestaPrimo4Del = n =>
        {
            return TestaPrimo4(n);
        };




        public static bool TestaPrimo1(int n)
        {
            bool EhPrimo = true; //em princÃ­pio, n Ã© primo
            int d = 2;
            if (n <= 1)
                EhPrimo = false;

            while (EhPrimo && d <= n / 2)
            {
                if (n % d == 0)
                    EhPrimo = false;
                d = d + 1;
            }
            return EhPrimo;
        }


        public static bool TestaPrimo2(int n)
        {

            bool EhPrimo = true; //em princÃ­pio, n Ã© primo
            int d = 2;
            int resto;
            if (n <= 1)
                EhPrimo = false;

            while (EhPrimo && d <= n / 2)
            {
                resto = n % d;
                if (resto == 0)
                    EhPrimo = false;
                d = d + 1;
            }
            return EhPrimo;
        }

        public static bool TestaPrimo3(int n)
        {

            bool EhPrimo;
            int d = 3;
            if (n <= 1 || (n != 2 && n % 2 == 0))
                EhPrimo = false;    /* nenhum numero inteiro <= 1 ou par > 2 e' primo */
            else
                EhPrimo = true;        /* o numero e' primo ate que se prove o contrario */

            while (EhPrimo && d <= n / 2)
            {
                if (n % d == 0)
                    EhPrimo = false;
                d = d + 2;        /* testar apenas Ã­mpares*/
            }
            return EhPrimo;
        }


        public static bool TestaPrimo4(int n)
        {
            bool EhPrimo; //em princÃ­pio, n Ã© primo
            int    d = 3;
            if (n <= 1 || (n != 2 && n % 6 == 1 && n % 6 == 5))
                EhPrimo = false;    /* nenhum numero inteiro <= 1 ou ~ adjacente a 6 eh primo */
            else
                EhPrimo = true;
            while (EhPrimo && d <= n / 2)
            {
                if (n % d == 0)
                    EhPrimo = false;
                d = d + 2;
            }
            return EhPrimo;
        }
    }
}

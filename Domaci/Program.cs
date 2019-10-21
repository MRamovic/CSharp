using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pocetak: ");
            int unos1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Kraj: ");
            int unos2 = int.Parse(Console.ReadLine());

            char pocetak;
            pocetak = (char)unos1;

            char kraj;
            kraj = (char)unos2;
            Console.WriteLine("Unesite broj karakera u redu: ");
            int brojK = int.Parse(Console.ReadLine());
            int i = 1;

            if (pocetak <= kraj)
            {

                for (; pocetak <= kraj; pocetak++)
                {
                    Console.Write(pocetak);
                    if ((pocetak - pocetak + i) % brojK == 0)
                    {
                        Console.WriteLine();
                    }

                    i++;
                }

            }
            else
            {
                for (; pocetak >= kraj; pocetak--)
                {
                    Console.Write(pocetak);
                    if ((pocetak - pocetak + i) % brojK == 0)
                    {
                        Console.WriteLine();
                    }

                    i++;
                }
            }
            Console.ReadKey();
        }
    }
}

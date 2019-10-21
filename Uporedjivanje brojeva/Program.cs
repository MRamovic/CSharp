using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uporedjivanje_brojeva
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Unesite vrednost za x: ");
            string unos = Console.ReadLine();
            int x = int.Parse(unos);
            Console.WriteLine("Unesite vrednost za y: ");
            unos = Console.ReadLine();
            int y = int.Parse(unos);
            Console.WriteLine("Unesite vrednost za z: ");
            unos = Console.ReadLine();
            int z = int.Parse(unos);
            Console.WriteLine($"Uneli ste brojeve x={x}, y={y}, z={z}");

            if (x == y && y == z)
            {
                Console.WriteLine($" x je jednako y, y je jednako z, sledi da je i x=z, ({x}={z})");
            }

            else if (x == y && y > z)

            {
                Console.WriteLine($"x je jednako y, y je vece od z, sledi da je i x vece od z ({x} >{z}) ");
            }

            else if (x == y && y < z)

            {
                Console.WriteLine($" x je jednako y, y je manje od z, sledi da je i x manje od z ({x}<{z})");
            }
            else if (x > y && y == z)
            {
                Console.WriteLine($" x je vece od y, y je jednako z, sledi da je i x vece od z ({x}>{z})");
            }
            else if ((x < y && y == z))
            {
                Console.WriteLine($" x je manje od y, y je jednako z, sledi da je i x manje od z ({x}<{z})");
            }
            else if (x == z && x > y)
            {
                Console.WriteLine($" x je vece od y, x je jednako z, sledi da je i z vece od y ({z}>{y})");
            }
            else if (x == z && x < y)
            {
                Console.WriteLine($" x je manje od y, x je jednako z, sledi da je i z manje od y ({z}<{y})");
            }
            else

            {
                Console.WriteLine($"Brojevi x, y i z su razliciti ");
            }


            Console.ReadKey();
        }
    }
}

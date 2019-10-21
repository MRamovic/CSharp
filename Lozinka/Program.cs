using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lozinka
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Unesite novi lozinku: ");
            string sifra = (Console.ReadLine());


            for (int brojac = 3; brojac > 0; brojac--)
            {
                Console.WriteLine("Da biste pristupili aplikaciji unesite Vasu lozinku ");
                string unos = Console.ReadLine();
                if (sifra == unos)
                {
                    Console.WriteLine("Vasa lozinka je ispravna. Dobrodosli!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Uneta lozinka nije tacna. Pokusajte ponovo. Broj preostalih pokusaja {brojac - 1}/3");
                    if (brojac == 1)
                    {
                        Console.WriteLine("Zbog Vase bezbednosti pristup aplikaciji onemogucen!");
                    }
                }

            }

            Console.ReadLine();
        }
    }
}

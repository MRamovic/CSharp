using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolatzov
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Unesite pozitivan broj: ");
            int broj = int.Parse(Console.ReadLine());
            int[] nizKolatzov=new int [0]; 

            if (broj <= 0)
            {
                Console.WriteLine("Greska! Uneli ste broj jednak 0 ili negativan broj!");
                Console.ReadKey();
                return;
            }

            int i = 0; //Brojac za indeks niza. 

            while (true)
            {
                Array.Resize(ref nizKolatzov, nizKolatzov.Length + 1); //dodajemo jedno mesto u  nizu.
                nizKolatzov[i] = broj; // Upisujemo vrednost za broj za odgovarajuci indeks i.

                if (broj % 2 == 0) //Uslov ako je paran broj. Treba podeliti sa 2.
                {
                    broj = broj / 2;
                    
                }
                else if (broj % 2 != 0) //Uslov ako je neparan. Treba pomnoziti sa 3 i dodati 1. 
                {
                    broj = broj * 3 + 1;
                    
                }
                
               

                
                i++;

                if (broj == 1) // Uslov ako  je broj = 1 ispisuje niz i izlazi iz "while (true)" petlje.
                               // Uslov broj == 1 je iz razloga sto koji god broj da unesemo, dolazimo do situacije,
                               // da ce u jednom trenutku da se dobije broj 1 i da ce da se dogodi proces ponavljanja, pa samim tim
                               // program bi radio bez prestanka.
                               // Pr. unesemo br 8 -paran => 8/2=4 - paran => 4/2=2 - paran => 2/2=1 -neparan
                               // => 1*3+1=4 -paran => 4/2=2 - paran=> 2/2=1 -neparan => 1*3+1=4, itd itd
                               // dakle 8-4-2-1-4-2-1-4-2-1-4-2-.... 4-2-1 blok koji se ponavlja.
                {
                    Array.Resize(ref nizKolatzov, nizKolatzov.Length + 1); //Dodajemo jos jedno polje u nizu zbog upisa nove vrednosti
                                                                            // u sledecoj liniji koda.
                    nizKolatzov[i] = broj;

                    Console.Write("Odgovarajuci niz je: ");

                    foreach (int vrednost in nizKolatzov)
                    {
                        Console.Write($"{vrednost}, ");
                    }
                        Console.ReadKey();
                    return;
                }
            }
            
        }
    }
}

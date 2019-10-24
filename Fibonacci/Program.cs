using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Unesite koliko elemenata Fibonacijevog niza zelite da saberete: ");
            int kolicina = int.Parse ( Console.ReadLine());
            Console.Write(" \n ========================================== \n \n");
            long [] nizFibonacci = { 0, 1 }; //Pocetne vrednosti Fibonacijevog niza.

            if (kolicina < 0)
            {
                Console.WriteLine("Greska!");
                Console.ReadKey();
                return;
            }
            

             Array.Resize(ref nizFibonacci,  nizFibonacci.Length + kolicina - 2); //Prosirili smo niz za {kolicina -2}  mesta

            
            for (int index = 0; index < kolicina-2; index++)
            {
             
                nizFibonacci[index + 2] = nizFibonacci[index] + nizFibonacci[index + 1];  // Formiramo Fib. niz
                                                                                            
            }
            

            foreach (long broj in nizFibonacci )
            {
                Console.Write($"{broj}, ");   //Ispisujemo trazeni broj elemenata Fib. niza
            }

            int brojac = 0;
            long zbir=0;

            while (brojac<nizFibonacci.Length )
            {
                zbir = zbir + (nizFibonacci[brojac]); //Sumiramo sve elemente Fib. niza
                brojac++;

            }
            Console.WriteLine($"\n \n Zbir {kolicina} Fib. elemenata niza je: {zbir}"); //Ispisujemo zbir elemenata


            Console.ReadKey();   
        }
    }
}

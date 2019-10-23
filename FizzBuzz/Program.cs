using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Niz brojeva pocinje od 1. Molimo Vas unesite poslednji broj: ");
            int kraj = int.Parse(Console.ReadLine());


            if (kraj <= 1)
            {
                Console.WriteLine("Greska! Uneli ste broj jednak ili manji od 1.  ");
                Console.ReadKey();
                return;
            }

            else
            {
                int[] nizBrojeva = new int[kraj];

                for (int indeks = 0; indeks < nizBrojeva.Length; indeks++)
                {
                    nizBrojeva[indeks] = (indeks + 1);
                }

                foreach (int broj in nizBrojeva)
                {

                    Console.Write($"{broj}, ");

                }
                Console.WriteLine("\n ==========================================================");

                for (int index = 0; index < nizBrojeva.Length; index++)
                {
                    while (nizBrojeva[index]%3==0 && nizBrojeva[index] % 5 != 0)
                    {
                        Console.Write($"{nizBrojeva[index]}-Fizz, ");
                        break;
                    }
                    while (nizBrojeva[index] % 5 == 0 && nizBrojeva[index] % 3 != 0)
                    {
                        Console.Write($"{nizBrojeva[index]}- Buzz, ");
                        break;
                    }
                    while (nizBrojeva[index] % 3 == 0 && nizBrojeva[index] % 5==0)
                    {
                        Console.Write($"{nizBrojeva[index]}- FizzBuzz, ");
                        break;
                    }
                }








            }       
                
                
            Console.ReadKey();
        }
    }
}

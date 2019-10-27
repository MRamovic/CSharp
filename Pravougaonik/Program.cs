using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pravougaonik
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            while (true)
            {

                try
                {
                    Console.WriteLine("Unesite duzinu stranice a: ");
                    a = int.Parse(Console.ReadLine());
                    Console.WriteLine("Unesite duzinu stranice b: ");
                    b = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Uneli ste poresnu vrednost! Pokusajte ponovo! ");
                    Console.WriteLine();
                }

            }
            for (int n=1; n<=a; n++ )
            {
                

                for ( int m = 1; m <= b; m++)
                {
                   

                    if (n==1 || n == a)   
                    {
                        Console.Write("* "); //ispis stranice a
                    }
                    else if (n!=1)
                    {
                       if (m==1 ||m==b)
                        {
                            Console.Write("* "); //ispis stranice b
                        }else
                        {
                            Console.Write("  "); // ispis praznih polja unutar pravougaonika
                        }
                    }


                 
                       

                     
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}

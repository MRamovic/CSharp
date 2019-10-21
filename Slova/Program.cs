using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slova
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Unesite prvo slovo: ");
            char slovo1 = char.Parse(Console.ReadLine());

            Console.WriteLine("Unesite poslednje slovo: ");
            char slovo2 = char.Parse(Console.ReadLine());



            for (; ; )
            {
                if (slovo1 <= slovo2)
                {
                    Console.Write($"{slovo1}, ");
                    slovo1++;
                    if (slovo1 > slovo2)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Unesite ponovo prvo slovo (postujte abecedni redosled) ");
                    slovo1 = char.Parse(Console.ReadLine());

                    Console.WriteLine("Unesite ponovo poslednje slovo (postujte abecedni redosled) ");
                    slovo2 = char.Parse(Console.ReadLine());
                }
            }
            Console.ReadKey();
        }
    }
}

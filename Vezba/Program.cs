using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezba
{
    class Program
    {
        static void Main(string[] args)
        {
            //Operacije sa brojevima

            Console.WriteLine("Unesite vrednost za x: ");
            string broj = Console.ReadLine();
            decimal x = decimal.Parse(broj);
            Console.WriteLine("Unesite vrednost za y: ");
            broj = Console.ReadLine();
            decimal y = decimal.Parse(broj);
            Console.WriteLine("Unesite zeljenu operaciju (+, -, *, /)");

            string operacija = Console.ReadLine();

            switch (operacija)
            {
                case "+":
                    Console.WriteLine($"Zbir je {x + y}");
                    break;
                case "-":
                    Console.WriteLine($"Razlika je {x - y}");
                    break;
                case "*":
                    Console.WriteLine($"Proizvod je {x * y}");
                    break;
                case "/":
                    Console.WriteLine($"Kolicnik je {x / y}");
                    break;

            }

            Console.ReadKey();
        }
    }
}

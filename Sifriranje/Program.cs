using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifriranje
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int brojac, broj, i;
            string  unos;
            string promenljiva = null;

            while (true)
            {
                try
                {
                    Console.WriteLine("Unesite zeljeni tekst za sifriranje: ");
                    unos = Console.ReadLine();
                    Console.WriteLine("Unesite zeljeni broj za sifriranje: ");
                    broj = int.Parse(Console.ReadLine());

                    break;


                }
                catch
                {
                    Console.WriteLine("Molimo Vas unesite ispravan tekst i broj. ");
                }

            }


            while (true)
            { 

            Console.WriteLine("Izaberite:\n" +
                          "1 - Sifruj tekst\n" +
                          "2 - Desifruj tekst\n" +
                          "3 - Izlaz\n" +
                          "==================\n");

            char izbor = Console.ReadKey().KeyChar ;
            Console.WriteLine();

                switch (izbor)
                {
                    case '1':

                        Console.WriteLine("Sifrovani tekst:");
                        promenljiva = null;
                        foreach (char slovo in unos)
                        {
                            if (slovo > 96 && slovo < 123)
                            {
                                brojac = slovo + broj;

                                if (brojac > 122)
                                {
                                    brojac = brojac - 26;
                                    Console.Write((char)brojac);
                                }
                                else
                                {
                                    Console.Write((char)brojac);
                                }
                                
                                promenljiva += ($"{(char)(brojac)}");
                            }
                            else
                            {
                                Console.Write(slovo);
                                
                                promenljiva += ($"{(char)(slovo)}");
                            }
                           


                        }
                        Console.WriteLine();
                        
                        Console.ReadKey();
                        break;

                    case '2':
                        
                        {
                            Console.WriteLine("Desifrovani tekst:");

                            foreach (char slovo in promenljiva)
                            { if (slovo > 96 && slovo < 123)
                                {
                                    i = slovo - broj; ;
                                    if (i < 97)
                                    {
                                        i = i + 26;
                                        Console.Write($"{(char)(i)}");
                                    }
                                    else
                                    {
                                        Console.Write((char)i);
                                    }
                                }else
                                {
                                    Console.Write(slovo);
                                }

                            }
                            Console.WriteLine();
                            
                            break;
                        }

                        


                    case '3':
                        Console.WriteLine("Dovidjenja!");
                        Console.ReadKey();
                        return;

                    default:
                        {
                            Console.WriteLine("Greska! ");
                            break;
                        }

                }
            }
            
            Console.ReadKey();
        }
    }
}

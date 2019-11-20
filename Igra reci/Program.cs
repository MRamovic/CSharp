using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Igra_reci
{
    class Program
    {
        
        static void Main(string[] args)
        {

        string rec,rec2;
        char slovo;
        List<char> pomocnaRec=new List<char> ();
        int brojac=0, brPokusaja=0;
        List<string> BazaReci = new List<string>();
        List<(string Ime, string Prezime, int BrPokusaja)> TopLista = new List<(string, string, int)>();
        string[] Korisnik ;
        

        char unos;
            do
            {
                bool vrednost = false;
                Meni();
                unos = Console.ReadKey().KeyChar;
                Console.WriteLine();


                switch (unos)
                {

                    case '1':
                        bool izlaz = true;
                        Console.Write("Unesite ime i prezime: ");
                        Korisnik = Console.ReadLine().Split(' ');

                        rec = IzaberiRec(BazaReci);
                        IspisiRec(rec, pomocnaRec );
                        Console.WriteLine();

                        do
                        {
                            
                            Console.WriteLine("Da li zelite da pokusate da pogodite rec? (d/n)");
                            slovo = Console.ReadKey().KeyChar;
                            if (slovo == 'd')
                            {
                                brPokusaja++;
                                Console.Write("Unesite rec: ");
                                rec2 = Console.ReadLine();
                                vrednost = Pokusaj(rec, rec2);

                                if (vrednost)
                                {
                                    Console.WriteLine("Cestitamo! Pogodili ste!\n");
                                    izlaz = false;
                                }
                                else
                                {
                                    Console.WriteLine("Greska!\n");
                                }
                            }
                            else
                            {
                                Console.Write("Unesite slovo: ");
                                slovo = Console.ReadKey().KeyChar;
                                Console.WriteLine();
                                brPokusaja++;
                                vrednost = Provera(slovo, rec);
                                if (vrednost)
                                {
                                    rec.ToCharArray();
                                    UpisiSlovo(slovo, pomocnaRec, rec);
                                }
                                else
                                {
                                    Console.WriteLine("Greska! Pokusajte sa drugim slovom!");
                                }
                                IspisiPogodjenaSlova(pomocnaRec);
                            }

                            
                            
                        } while (izlaz);
                        {
                            TopLista.Add((Korisnik[0], Korisnik[1], brPokusaja));
                            Console.WriteLine($"Postovani {Korisnik[0]} {Korisnik[1]}, Vas rezultat je {brPokusaja} pokusaja! "); 
                        }
                       
                        break;
                    case '2':

                        break;
                    case '3':
                        Console.WriteLine($"Mozete da unesete jednu ili vise reci. Koristiti ';' izmedju reci! ");
                        DodajNovuRec(BazaReci );
                        break;
                    case '4':
                        break;

                    default:
                        Console.WriteLine("Greska!");
                        break;

                }

            }
            while (unos != '4');

            {
                Console.WriteLine("Dovidjenja!");
                Console.ReadKey();
                if (File.Exists("BazaReci.txt"))
                {
                    File.Delete("BazaReci.txt");
                }

               
                return;


            }
            
        }


        /* static void  OdabirReci(List <string> BazaReci)
         {
             int i = 0;
             OdabranaRec[i] = BazaReci[i];

             i++;
         }*/
         static void IspisiPogodjenaSlova(List <char> pomocnaRec)                           //metoda za ispis pogodjenih slova
        {
            Console.Write($"Vasa rec je: ");
            foreach (char slovo in pomocnaRec)
            {
                Console.Write($"{slovo} ");
            }
            Console.WriteLine();
        }

        static void UpisiSlovo(char slovo,  List<char> pomocnaRec, string rec)              //metoda za upis pogodjenog slova
        {
            for (int indeks=0; indeks<rec.Length; indeks++)
            {
                if (slovo==rec[indeks])
                {
                    pomocnaRec[indeks]=slovo;
                }
                
            }
        }
        static void IspisiRec(string rec, List<char> pomocnaRec)                                //metoda za ispis koliko slova ima rec
        {
            Console.Write("Vasa rec je: ");
            for (int i=0; i<rec.Length; i++ )
            {
                if (rec[i]== null)
                {
                    Console.Write(" ");
                    pomocnaRec.Add(' ');
                    
                }
                else
                {
                    Console.Write("_ ");
                    pomocnaRec.Add('_');
                }
            }

        }

            static bool Pokusaj(string rec, string pomocnaRec)                              //metoda za pokusaj da se pogodi rec
        {
           
            if (rec == pomocnaRec)
                return true;
            else
                return false;

        }
      /*  static int PronadjiIndeks(string rec, int brojac, char slovo)
        {
            for (int i = 0; i < rec.Length; i++)
            {
                if (slovo == rec[i])
                {
                    brojac = i;
                    return brojac;
                }

            }
            return brojac;

        }*/
        static bool Provera(char slovo, string rec )                                                        //metoda za proveru da li postoji slovo
        {
            for (int i=0; i<rec.Length; i++)
            {
                if (slovo == rec[i])
                {
                    return true;
                }
                
            }
            return false;
        }

        static string IzaberiRec(List<string> nizReci)                                                          //metoda za uzimanje reci iz baze

        {
            int i = 0;
            return nizReci[i];

        }
        static void DodajNovuRec(List<string> NizReci)                                      //metoda za dodavanje novih reci u fajl
        {

            string[] unos = Console.ReadLine().Split(';');

            for (int i = 0; i < unos.Length; i++)
            {
                File.AppendAllText("BazaReci.txt", Environment.NewLine + $"{unos[i]}");
                NizReci.Add(unos[i]);
            }
        }

        static void Meni()                                                                  //metoda za ispis menija
        {
            Console.Write("1 - Pogodi rec\n" +
                              "2 - Top lista\n" +
                              "3 - Dodaj novu rec\n" +
                              "4 - Izadji\n" +
                              "================\n" +
                              "Izaberite:");
        }
    }
}

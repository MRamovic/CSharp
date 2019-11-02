using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace POS
{
    class Program
    {
        static void Main(string[] args)
        {
            int kol = 0;
            string sifra = null;
            string naziv = null;
            int cena = 0;
            int kolicina = 0;
            

            File.WriteAllText("Meni.txt", " ");
            File.AppendAllText("Meni.txt", Environment.NewLine + "Artikli:\nSifra   Naziv   Cena    Kolicina ");

            //Napravili smo listu tuplova koja sadrzi sifru, naziv, cenu i kolicinu
            List<(string sifra, string naziv, int cena, int  kolicina)> POS = new List<(string, string, int, int)>();
            List<(string sifra1, string naziv1, int cena1, int kolicina1)> POSRacun= new List<(string, string, int, int)>() ;


            while (true)                                                                        // da nam ponavlja meni 
            {


                Console.Write("Meni\n" +                                                            // Glavni meni
                              "===================\n" +
                              "1 - Unos artikala\n" +
                              "2 - Dodaj kolicinu postojecem artiklu\n" +
                              "3 - Pregled artikala\n" +
                              "4 - Izdavanje racuna\n" +
                              "5 - Uklanjanje artikala\n" +
                              "6 - Pronadji sifru artikla\n" +
                              "7 - Izlaz\n" +
                              "Izaberite: ");


               char izbor =  Console.ReadKey().KeyChar;                                              //izbor u meniju
                Console.WriteLine();
                Console.WriteLine();


                switch (izbor)
                {

                    case '1':                                                                       //unos novih artikala

                        Console.Write("Unesite sifru artikla: ");
                        sifra = Console.ReadLine();
                        

                        for (int brojac = 0; brojac < POS.Count; brojac++)
                        {
                            if (POS[brojac].sifra.Equals(sifra))
                                {
                                Console.WriteLine($"Artikal vec postoji: {POS[brojac].naziv}.  Koristite drugu sifru!");
                                Console.WriteLine("Ako zelite da dodate kolicinu postojecem artiklu odaberite opciju '2 - Dodaj kolicinu postojecem artiklu'\n");
                                break;
                                }
                        }
                        try
                        {
                            Console.Write("Unesite naziv artikla: ");
                            naziv = Console.ReadLine();
                            Console.Write("Unesite cenu artikla: ");
                            cena = int.Parse ( Console.ReadLine());
                            Console.Write("Unesite kolicinu: ");
                            kolicina = int.Parse(Console.ReadLine());
                        }catch
                        {
                            Console.WriteLine("Greska u unosu podataka!");
                        }

                        

                        POS.Add((sifra, naziv, cena, kolicina));                                       //cuvanje artikla

                        File.AppendAllText("Meni.text", Environment.NewLine + $" {POS[POS.Count - 1].sifra},  {POS[POS.Count - 1].naziv },  " +
                                    $"{POS[POS.Count - 1].cena},  {POS[POS.Count - 1].kolicina }\n ");
                      
                        break;


                    case '2':

                        if (POS.Count == 0)
                        {
                            Console.WriteLine("Ne postoji nijedan artikal! Prvo unesite artikal opcija '1 - Unos artikala'\n");
                        }
                        else
                        {

                            Console.Write("Unesite sifru proizvoda: ");
                            sifra = Console.ReadLine();

                            for (int brojac = 0; brojac < POS.Count; brojac++)
                            {
                                if (POS[brojac].sifra.Equals(sifra))
                                {
                                    Console.WriteLine($"Izabrali ste artikal: {POS[brojac].naziv}");
                                    Console.Write("Unesite kolicinu za dodavanje artiklu: ");
                                    kolicina = int.Parse(Console.ReadLine());
                                    POS[brojac] = (POS[brojac].sifra, POS[brojac].naziv, POS[brojac].cena, POS[brojac].kolicina + kolicina);
                                    break;

                                }
                                if (brojac == POS.Count - 1)
                                {
                                    Console.WriteLine("Ne postoji artikal za unetu sifru! Prvo unesite artikal opcija '1 - Unos artikala' \n");
                                    break;
                                }
                            }
                        }




                        break;


                    case '3':                                                                       //ispisivanje unetih artikala

                        if (POS.Count == 0)
                        {
                            Console.WriteLine("Ne postoji nijedan artikal! Prvo unesite artikal opcija '1 - Unos artikala'\n");
                        }
                        else
                        {
                            Console.WriteLine("Artikli: \n==========");

                            foreach ((string sifra, string naziv, int cena, int kolicina) citac in POS)
                            {
                                Console.WriteLine($"Sifra: {citac.sifra}\nNaziv: {citac.naziv}\nCena: {citac.cena}\nKolicina: {citac.kolicina}\n-------------------");
                            }
                        }
                        break;



                    case '4':                                                                           //izdavanje racuna

                        
                        char izbor2=(char)0;

                        while (izbor2!='4')                                              
                        {
                           Console.Write("Meni:\n" +                                                  //meni za izdavanje racuna
                                          "---------------\n" +                                       
                                          "1 - Dodaj artikal na racun\n" +                           
                                          "2 - Ukloni artikal sa racuna\n" +                          
                                          "3 - Prikazi racun\n" +
                                          "4 - Zavrsi racun\n" +
                                          "Izaberite: ");                                          
                                                                                                  
                            izbor2 = Console.ReadKey().KeyChar ;                                   
                            Console.WriteLine("\n");
                            

                            switch (izbor2)

                            {
                                case '1':

                                    if (POS.Count == 0)
                                    {
                                        Console.WriteLine("Ne postoji nijedan artikal! Prvo dodajte artikal opcija '1 - Unos artikala'\n");
                                        izbor2 = '4';
                                    }
                                    else
                                    {

                                        Console.Write("Unesite sifru artikla: ");
                                        string dodajArtikal = Console.ReadLine();                      //dodajArtikal promenljiva
                                                                                                       // za dodavanje artikla na racun

                                        if (int.TryParse(dodajArtikal, out int sifra2))             //sifra2 promenljiva za proveru 
                                        {                                                           //da li postoji artikal sa tom sifrom
                                            for (int brojac = 0; brojac < POS.Count; brojac++)
                                            {

                                                if (POS[brojac].sifra.Contains(dodajArtikal))         //proveravamo da li postoji sifra artikla
                                                {
                                                    Console.Write($"Artikal: {POS[brojac].naziv}, unesite kolicinu: ");
                                                    kol = int.Parse(Console.ReadLine());
                                                    if (POS[brojac].kolicina > kol)
                                                    {

                                                        POS[brojac] = ((POS[brojac].sifra, POS[brojac].naziv, POS[brojac].cena, POS[brojac].kolicina - kol)); //kolicina artikla je umanjena za unos

                                                        POSRacun.Add((POS[brojac].sifra, POS[brojac].naziv, POS[brojac].cena, kol));

                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"Nema dovoljno artikla '{POS[brojac].naziv}'! Stanje artikla:{POS[brojac].kolicina}");
                                                    }
                                                }
                                            }
                                        }

                                        else
                                        {
                                            Console.WriteLine("Nepostojeca sifra!");
                                        }
                                    }
                                    break;

                                case '2':                                                      //uklanjanje artikala sa racuna

                                    if (POSRacun.Count == 0)
                                    {
                                        Console.WriteLine("Racun je prazan, niste dodali nijedan artikal!");
                                    }
                                    else
                                    {

                                        int indeks = 0;


                                        Console.Write("Unesite sifru artikla koji zelite da uklonite: ");
                                        string uklonitiArtikal = Console.ReadLine();



                                        if (indeks < POSRacun.Count)

                                        {
                                            for (int brojac = 0; brojac < POSRacun.Count; brojac++)
                                            {
                                                if (POSRacun[brojac].sifra1.Equals(uklonitiArtikal))
                                                {

                                                    kol = POSRacun[brojac].kolicina1;

                                                    for (int brojac2 = 0; brojac2 < POS.Count; brojac2++)
                                                    {
                                                        if (POS[brojac2].sifra.Contains(uklonitiArtikal))
                                                        {
                                                            POS[brojac2] = ((POS[brojac2].sifra, POS[brojac2].naziv, POS[brojac2].cena, POS[brojac2].kolicina + kol));
                                                            POSRacun.RemoveAt(brojac);
                                                        }
                                                    }


                                                }
                                                indeks++;
                                            }


                                        }
                                        else
                                        {
                                            Console.WriteLine("Ne postoji artikal na racunu ili ste uneli pogresnu sifru!");
                                        }
                                    }
                                        break;



                                case '3':                                                        // prikazivanje racuna

                                    Console.WriteLine("Sifra             Naziv artikla              Cena             Kolicina ");
                                    
                                   for (int brojac=0; brojac<POSRacun.Count; brojac++)
                                    {
                                       
                                        Console.Write($"{POSRacun[brojac].sifra1}                " +
                                            $"  {POSRacun[brojac].naziv1}                  " +
                                            $" {POSRacun[brojac].cena1}                   " +
                                            $" {POSRacun[brojac].kolicina1}\n");
                                        
                                    }

                                    Console.WriteLine();
                                    

                                    break;


                                case '4':                                                        //kraj racuna

                                    Console.WriteLine("Sifra             Naziv artikla              Cena           Kolicina ");
                                    int i = 0;
                                    int   zbir=0;
                                    while (true)
                                    {
                                        try
                                        {

                                            
                                           
                                            zbir = zbir + POSRacun[i].kolicina1 * POSRacun[i].cena1;
                                            i++;


                                            if (i > POSRacun.Count - 1)
                                            {

                                                break;
                                            }
                                        }catch
                                        {
                                            Console.WriteLine("Niste nista uneli za naplatu!");
                                            break;
                                        }
                                           
                                            
                                        
                                    }
                                    for (int brojac = 0; brojac < POSRacun.Count; brojac++)
                                    {

                                        Console.Write($"{POSRacun[brojac].sifra1}                  " +
                                            $"  {POSRacun[brojac].naziv1}                     " +
                                            $" {POSRacun[brojac].cena1}                   " +
                                            $" {POSRacun[brojac].kolicina1}\n");

                                    }
                                    POSRacun.Clear();
                                    Console.WriteLine($"Vas racun iznosi ukupno: {zbir } ");
                                    Console.WriteLine("Hvala! \n");
                                    


                                        break;
                                    

                            }
                        }

                        break;


            

                    case '5':                                                               // uklanjanje artikala

                        if (POS.Count == 0)
                        {
                            Console.WriteLine("Ne postoji nijedan artikal! Prvo unesite artikal opcija '1 - Unos artikala'\n");

                        }
                        else
                        {
                            Console.Write("Unesite naziv artikla ili sifru artikla: ");

                            string unos = Console.ReadLine();

                            if (int.TryParse(unos, out int sifraa))                              //pretrazivanje po sifri
                            {
                                if (sifraa - 1 < POS.Count)
                                {

                                    POS.RemoveAt(sifraa - 1);
                                }
                                else
                                {
                                    Console.WriteLine("Nepostojeca sifra!");
                                }
                            }
                            else                                                                // pretrazivanje po imenu
                            {
                                for (int i = 0; i < POS.Count; i++)
                                {
                                    if (POS[i].naziv.Contains(unos))
                                    {
                                        POS.RemoveAt(i);
                                        break;
                                    }
                                }
                            }
                        }
                        break;


                    case '6':

                        int indeks2 = 0;
                        
                        if (POS.Count == 0)
                        {
                            Console.WriteLine("Ne postoji nijedan artikal! Prvo unesite artikal opcija '1 - Unos artikala'\n");
                            break;
                        }
                        else if (indeks2<POS.Count )
                        {
                            indeks2++;
                            Console.Write("Unesite naziv artikla:");
                            string nazivArtikla = (Console.ReadLine());

                            for (int brojac = 0; brojac < POS.Count; brojac++)
                            {
                                if (POS[brojac].naziv.Contains(nazivArtikla))
                                {
                                    Console.WriteLine($"Sifra artikla '{POS[brojac].naziv}' je: {POS[brojac].sifra}");
                                    break;
                                }else
                                {
                                    Console.WriteLine("Ne postoji artikal ili ste uneli pogresan naziv!");
                                    break;
                                }
                            }
                            break;
                            
                        }
                        else {
                            Console.WriteLine("Ne postoji artikal ili ste uneli pogresan naziv!");
                            break;
                        }
                        



                    case '7':                                                                //izlaz
                        

                        Console.WriteLine("Dovidjenja!\n Hvala!");
                        Console.ReadKey();

                        return;


                    default:

                        Console.WriteLine("Greska!");

                        break;


                }



            }
           
        }
    }
}

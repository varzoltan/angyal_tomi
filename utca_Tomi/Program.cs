using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace utca_Tomi
{
    class Program
    {
        struct Adat
        {
            public int paros_paratlan;
            public int telek_hossz;
            public string ker_szin;
            public int hazszam;
        }
        static void Main(string[] args)
        {
            //Beolvasás
            Adat[] adatok = new Adat[1000];//Példányosítás
            StreamReader olvas = new StreamReader(@"C:\Users\Rendszergazda\Desktop\2018-oktober\kerites.txt");
            int n = 0;
            int paros = 0;
            int paratlan = -1;
            while (!olvas.EndOfStream)
            {
                string sor = olvas.ReadLine();
                string[] db = sor.Split();
                adatok[n].paros_paratlan = int.Parse(db[0]);
                adatok[n].telek_hossz = int.Parse(db[1]);
                adatok[n].ker_szin = db[2];
                if (db[0] == "0")
                {
                    paros += 2;
                    adatok[n].hazszam = paros;
                }
                else
                {
                    paratlan += 2;
                    adatok[n].hazszam = paratlan;
                }
                n++;
            }
            olvas.Close();

            //2.feladat
            Console.WriteLine("2. feladat");
            Console.WriteLine("Az eladott telkek száma: {0}", n);

            //3.feladat
            Console.WriteLine("3. feladat");
            if (adatok[n-1].paros_paratlan == 0)
            {
                Console.WriteLine("A páros oldalon adták el az utolsó telket.");
                Console.WriteLine("Az utolsó telek házszáma: {0}", adatok[n - 1].hazszam);
            }
            else
            {
                Console.WriteLine("A páratlan oldalon adták el az utolsó telket.");
                Console.WriteLine("Az utolsó telek házszáma: {0}", adatok[n - 1].hazszam);
            }

            //4.feladat
            string szin1 = null, szin2 = null;
            int szamlalo = 0;
            int k = 0;
            //Console.Write(");
            for (int i=0; i<n;i++)
            {
                if (adatok[i].paros_paratlan == 1 && adatok[i].ker_szin != ":" && adatok[i].ker_szin != "#")
                {
                    szamlalo++;
                    if ( szamlalo == 1)
                    {
                        szin1 = adatok[i].ker_szin;                              
                    }
                    if ( szamlalo == 2)
                    {
                        szin2 = adatok[i].ker_szin;
                        if (szin1 == szin2)
                        {
                            Console.WriteLine("A szomszédossal egyezik a kerítés színe: {0}",adatok[k].hazszam);
                        }                             
                        szin1 = szin2;
                        k = i;
                        szamlalo = 1;                                                         
                    }
                }   
            }

            //5. feladat
            Console.Write("Adjon meg egy házszámot! ");
            int hazszam = int.Parse(Console.ReadLine());
            for (int i = 0; i<n;i++)
            {
                if (hazszam == adatok[i].hazszam)
                {
                    if (adatok[i].ker_szin != ":" && adatok[i].ker_szin != "#") 
                    {
                        Console.WriteLine("A kerítés színe: " + adatok[i].ker_szin);
                    }
                    else
                    {
                        Console.WriteLine("A kerítés állapota: " + adatok[i].ker_szin);
                    }                 
                }               
            }

            //5.b feladat
            string szin = null;
            szin1 = null;
            szin2=null;
            for (int i = 'A' ;i <= 'Z'; i++)
            {
                for (int j = 0;j<n;j++)
                {
                    if (hazszam == adatok[j].hazszam && adatok[j].ker_szin != ":" && adatok[j].ker_szin != "#")
                    {
                        szin = adatok[j].ker_szin;
                    }
                    if (hazszam -2 == adatok[j].hazszam)
                    {
                        szin1 = adatok[j].ker_szin;
                    }
                    if (hazszam + 2 == adatok[j].hazszam)
                    {
                        szin2 = adatok[j].ker_szin;
                    }
                }
                if (szin != Convert.ToChar(i).ToString() && szin1 != Convert.ToChar(i).ToString() && szin2 != Convert.ToChar(i).ToString())
                {
                    Console.WriteLine("Egy lehetséges festési szín: {0}", Convert.ToChar(i));
                    break;
                }
            }

            //6.feladat
            
            for (int i = 0;i<n;i++)
            {
                if (adatok[i].paros_paratlan == 1)
                {
                    for (int j = 0;j<adatok[i].telek_hossz;j++)
                    {
                        Console.Write(adatok[i].ker_szin);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}

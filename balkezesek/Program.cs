using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace balkezesek
{
  class Program
  {
    static List<Jatekos> jatekosok = new List<Jatekos>();

    static void MasodikFeladat()
    {
      StreamReader file = new StreamReader("balkezesek.csv");
      file.ReadLine();

      while (!file.EndOfStream)
      {
        string[] a = file.ReadLine().Split(';');
        jatekosok.Add(
          new Jatekos(
                      a[0], a[1], a[2], Convert.ToInt32(a[3]),
                      Convert.ToInt32(a[4])
                      ) 
          );
      }

      file.Close();
    }

    static void HarmadikFeladat()
    {
      Console.WriteLine("3. feladat: {0}",jatekosok.Count);
    }

    static void NegyedikFeladat()
    {
      var oktober = from j in jatekosok
                    where j.Utolso.Contains("1999-10-")
                    select new { 
                                  Name = j.Nev,
                                  Mag = Math.Round( j.Magassag * 2.54,1) 
                    };
      Console.WriteLine("4. feladat");

      foreach (var o in oktober)
      {
        Console.WriteLine($"\t{o.Name}, {o.Mag:N1} cm");
      }
    }

    static void OtHat()
    {
      int evszam = 0;
      bool hibas;
      do
      {
        hibas = false;
        Console.Write("Kérek egy 1990 és 1999 közötti évszámot: ");
        evszam = Convert.ToInt32(Console.ReadLine());
        if (evszam < 1990 || evszam > 1999)
        {
          hibas = true;
          Console.Write("Hibás adat!");
        }
      } while (hibas);

      var eves = from j in jatekosok
                 where
                  Convert.ToInt32(j.Elso.Substring(0, 4)) <= evszam
                  &&
                  Convert.ToInt32(j.Utolso.Substring(0, 4)) >= evszam
                 select new { j.Suly };

      var evesLista = eves.ToList();

      //double szum = 0;

      //foreach (var e in evesLista)
      //{
      //  szum += e.Suly;
      //}

      //double atlag = Math.Round(szum / evesLista.Count(),2);

      Console.WriteLine("6. feladat: {0:N2} font",evesLista.Average(n => n.Suly));      
    }

    static void Hetedik()
    {
      var abc = from j in jatekosok
                orderby j.Nev
                group j by j.Nev[0] into abcTemp
                select abcTemp;

      foreach (var abcGroup in abc)
      {
        Console.WriteLine(abcGroup.Key);
        foreach (var item in abcGroup)
        {
          Console.WriteLine($"\t{item.Nev}");
        }
      }
                
    }

    static void Main(string[] args)
    {
      MasodikFeladat();
      HarmadikFeladat();
      NegyedikFeladat();
      OtHat();
      Hetedik();


      Console.ReadLine();
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrukkosTomb
{
  class Program
  {
    static int[] tomb = new int[100];

    static void Beolvasas()
    {
      StreamReader file = new StreamReader("adatok.csv");

      while (!file.EndOfStream)
      {
        // soronként beolvassuk "84;90;93;14;7;58;31;5;6;74"
        // split -> ; 
        // ? darab adat lesz -> 10 darab string típusú
        // konvertálni is kell

        for (int j = 0; j < 10; j++)
        {
          string sor = file.ReadLine();
          string[] szovegSzamok = sor.Split(';');

          for (int i = 0; i < 10; i++)
          {
            tomb[j*10+i] = Convert.ToInt32(szovegSzamok[i]);
          } 
        }
      }

      //for (int i = 0; i < 100; i++)
      //{
      //  Console.Write(tomb[i]+", ");
      //}

      file.Close();
    } // Beolvasás vége

    static void MinMax()
    {
      int min = tomb[0];

      for (int i = 1; i < 100; i++)
      {
        if (min > tomb[i])
        {
          min = tomb[i];
        }
      }

      int max = tomb[0];
      for (int i = 1; i < 100; i++)
      {
        if (max < tomb[i])
        {
          max = tomb[i];
        }
      }

      Console.WriteLine("\nA minimum: " + min);
      Console.WriteLine("A maximum: " + max);
    }

    static void Osszeg()
    {
      int osszeg = 0;
      for (int i = 0; i < 100; i++)
      {
        osszeg = osszeg + tomb[i];
      }
      Console.WriteLine("Az összegük: " + osszeg);
    }

    static void Sorrend()
    {
      for (int i = 0; i < 99; i++)
      {
        for (int j = i + 1 ; j < 100; j++)
        {
          if (tomb[i] > tomb[j])
          {
            int tmp = tomb[i];
            tomb[i] = tomb[j];
            tomb[j] = tmp;
          }
        }
      }
    }

    static void Kiir()
    {
      for (int i = 0; i < 100; i++)
      {
        if (i % 10 == 0 && i != 0)
        {
          Console.WriteLine();
        }
        Console.Write( tomb[i].ToString().PadLeft(4));
      }
    }


    static void Main(string[] args)
    {
      Beolvasas();
      Kiir();
      MinMax();
      Osszeg();
      Sorrend();
      Kiir();

      Console.ReadKey();
    }
  }
}

using System;
using System.Collections.Generic;

namespace As1_Sudoku
{
    class Program
    {
        static void Main()
        {
            Puzzel p = new Puzzel();
            p.LaadSudoku(1);
            Console.WriteLine("Initiële puzzel:");
            p.PrintPuzzel();

            Console.WriteLine();
            p.VulPuzzel();
            Console.WriteLine("Random gevulde puzzel:");
            p.PrintPuzzel();
            Console.WriteLine(p.BerekenHeuristischeWaarde());

            /*
            for(int r = 0; r < 9; r++)
                Console.WriteLine("Check op rij " + r + ": " + p.CheckRij(r));
            for (int k = 0; k < 9; k++)
                Console.WriteLine("Check op kolom: " + k + ": " + p.CheckKolom(k));            

            Console.WriteLine("Heuristische waarde: " + p.BerekenHeuristischeWaarde());
            */

            Console.WriteLine("\nGegenereerde toestanden:");
            List<Puzzel> toestanden = p.GenereerToestanden();
            Console.WriteLine("Aantal toestanden: " + toestanden.Count);

            // Print de verkregen toestanden.
            for (int i = 0; i < toestanden.Count; i++)
            {
                toestanden[i].PrintPuzzel();
                Console.WriteLine(toestanden[i].BerekenHeuristischeWaarde());
                Console.WriteLine();
            }

            // Verkrijg de beste toestand.
            int minHeuristischeWaarde = p.BerekenHeuristischeWaarde();
            int minIndex = -1;
            for (int i = 0; i < toestanden.Count; i++)
            {
                // Print de puzzel als deze de doeltoestand is.
                if (toestanden[i].BerekenHeuristischeWaarde() == 0)
                {
                    Console.WriteLine("Oplossing gevonden!");
                    toestanden[i].PrintPuzzel();
                    Console.WriteLine("Check h-waarde: " + toestanden[i].BerekenHeuristischeWaarde());
                }

                // Verkrijg de index van de beste puzzel.
                if (toestanden[i].BerekenHeuristischeWaarde() <= minHeuristischeWaarde)
                {
                    minHeuristischeWaarde = toestanden[i].BerekenHeuristischeWaarde();
                    minIndex = i;
                }
            }

            if (minIndex != -1)
                p = toestanden[minIndex];
            else
                throw new Exception("Er zijn geen toestanden gegenereerd.");

            Console.WriteLine("BESTE PUZZEL:");
            p.PrintPuzzel();
            Console.WriteLine(p.BerekenHeuristischeWaarde());


            Console.Read();
        }
    }
}

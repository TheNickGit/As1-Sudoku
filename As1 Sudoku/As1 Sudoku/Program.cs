using System;
using System.Collections.Generic;

namespace As1_Sudoku
{
    class Program
    {
        static void Main()
        {
            int maximaleStagnatie = 30;
            int aantalRandomVakjes = 2;

            Puzzel p = new Puzzel();
            p.LaadSudoku(1);
            Console.WriteLine("Initiële puzzel:");
            p.PrintPuzzel();

            Console.WriteLine();
            p.VulPuzzel();
            Console.WriteLine("Random gevulde puzzel:");
            p.PrintPuzzel();
            Console.WriteLine(p.BerekenHeuristischeWaarde());

            
            // De loop van het algoritme.
            int iteratie = 0;
            int huidigeStagnatie = 0;
            while (p.BerekenHeuristischeWaarde() != 0)
            //for(int f = 0; f < 30; f++)
            {
                int oudeHeuristischeWaarde = p.BerekenHeuristischeWaarde();
                p = HillClimbing(p);
                Console.WriteLine("Puzzel #" + iteratie + " - Heuristische waarde: " + p.BerekenHeuristischeWaarde());
                p.PrintPuzzel();
                if (oudeHeuristischeWaarde == p.BerekenHeuristischeWaarde())
                    huidigeStagnatie++;

                if (huidigeStagnatie == maximaleStagnatie)
                {
                    for (int i = 0; i < aantalRandomVakjes; i++)
                        p.RandomWalk();
                    huidigeStagnatie = 0;
                }
                //f++;
                iteratie++;
            }
            
            /*
            Console.WriteLine();
            p.RandomWalk(); p.PrintPuzzel(); Console.WriteLine(p.BerekenHeuristischeWaarde() + "\n");
            p.RandomWalk(); p.PrintPuzzel(); Console.WriteLine(p.BerekenHeuristischeWaarde() + "\n");
            p.RandomWalk(); p.PrintPuzzel(); Console.WriteLine(p.BerekenHeuristischeWaarde() + "\n");
            */
            Console.WriteLine("Gevonden oplossing:");
            p.PrintPuzzel();
            Console.WriteLine("Heuristische waarde check: " + p.BerekenHeuristischeWaarde());
            Console.Read();
        }

        public static Puzzel HillClimbing(Puzzel p)
        {
            //Console.WriteLine("\nGegenereerde toestanden:");
            List<Puzzel> toestanden = p.GenereerToestanden();
            Console.WriteLine("Aantal toestanden: " + toestanden.Count);

            /*
            // Print de verkregen toestanden.
            for (int i = 0; i < toestanden.Count; i++)
            {
                toestanden[i].PrintPuzzel();
                Console.WriteLine(toestanden[i].BerekenHeuristischeWaarde());
                Console.WriteLine();
            }
            */

            // Verkrijg de beste toestand.
            int minHeuristischeWaarde = p.BerekenHeuristischeWaarde();
            int minIndex = -1;
            for (int i = 0; i < toestanden.Count; i++)
            {
                /*
                // Print de puzzel als deze de doeltoestand is.
                if (toestanden[i].BerekenHeuristischeWaarde() == 0)
                {
                    Console.WriteLine("Oplossing gevonden!");
                    toestanden[i].PrintPuzzel();
                    Console.WriteLine("Check h-waarde: " + toestanden[i].BerekenHeuristischeWaarde());
                }
                */

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

            /*
            Console.WriteLine("BESTE PUZZEL:");
            p.PrintPuzzel();
            Console.WriteLine(p.BerekenHeuristischeWaarde());
            */
            return p;
        }
    }
}

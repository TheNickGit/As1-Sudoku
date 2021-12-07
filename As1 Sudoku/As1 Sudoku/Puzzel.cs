﻿using System;
using System.Collections.Generic;
using System.Text;

namespace As1_Sudoku
{
    class Puzzel
    {
        // De puzzel wordt bepaald door een 3D array van 9 bij 9
        public int[,] vakjes;

        public Puzzel()
        {
            vakjes = new int[9, 9];
            VulPuzzel();
        }

        /// <summary>
        /// Vul de puzzel met random getallen. Houdt nog geen rekening met correctheden.
        /// </summary>
        public void VulPuzzel()
        {
            /*
            var rand = new Random();
            for(int r = 0; r < 9; r++)
                for(int k = 0; k < 9; k++)
                {
                    vakjes[r, k] = rand.Next(1, 9);
                }
            */
            for (int vakIndex = 0; vakIndex < 9; vakIndex++)
                VulVak(vakIndex);
        }

        /// <summary>
        /// De indexen van de vakken zijn als volgt:
        /// [0][1][2]
        /// [3][4][5]
        /// [6][7][8]
        /// waarbij iedere vak 3x3 kleinere vakjes bevat.
        /// </summary>
        /// <param name="vakIndex"></param>
        internal void VulVak(int vakIndex)
        {
            int vakRijIndex = (vakIndex / 3) * 3;
            int vakKolomIndex = (vakIndex % 3) * 3;

            // Check al ingevulde nummers op duplicaten te voorkomen.
            List<int> beschikbareNummers = new List<int>();
            for (int i = 1; i <= 9; i++)
                beschikbareNummers.Add(i);
            for (int r = vakRijIndex; r < vakRijIndex + 3; r++)
                for (int k = vakKolomIndex; k < vakKolomIndex + 3; k++)
                {
                    int huidigNummer = vakjes[r, k];
                    if (huidigNummer != 0 && beschikbareNummers.Contains(huidigNummer))
                        beschikbareNummers.Remove(huidigNummer);
                }

            // Vul de overige vakjes in.
            Random rand = new Random();
            for (int r = vakRijIndex; r < vakRijIndex + 3; r++)
                for (int k = vakKolomIndex; k < vakKolomIndex + 3; k++)
                {
                    int huidigNummer = vakjes[r, k];
                    if (huidigNummer == 0)
                    {
                        int nieuwNummerIndex = rand.Next(0, beschikbareNummers.Count - 1);
                        int nieuwNummer = beschikbareNummers[nieuwNummerIndex];
                        beschikbareNummers.RemoveAt(nieuwNummerIndex);
                        vakjes[r, k] = nieuwNummer;
                    }
                }
        }

        /// <summary>
        /// Print een weergave van de puzzel naar console.
        /// </summary>
        public void PrintPuzzel()
        {
            for (int r = 0; r < 9; r++)
            {
                for (int k = 0; k < 9; k++)
                {
                    Console.Write("[" + vakjes[r, k] + "]");
                    if (k == 2 || k == 5)
                        Console.Write(":");
                }
                Console.WriteLine();
                if (r == 2 || r == 5)
                    Console.WriteLine("---------+---------+---------");
            }
        }

        /// <summary>
        /// Check een rij met de heuristische functie ingebouwd.
        /// Returnt het aantal cijfers dat niet op de juiste plek staat.
        /// </summary>
        public int CheckRij(int rijIndex)
        {
            List<int> gevondenNummers = new List<int>();
            int aMissendeNummers = 0; // Het aantal missende nummers, wat gelijk is aan het aantal duplicaten.

            // De loop. Checkt een nummer om te kijken of deze al eerder is gevonden.
            // Zo ja, incrementeer de teller.
            // Zo nee, voeg het nummer toe aan de lijst.
            for (int i = 0; i < 9; i++)
            {
                int huidigNummer = vakjes[rijIndex, i];
                if (gevondenNummers.Contains(huidigNummer))
                    aMissendeNummers++;
                else
                    gevondenNummers.Add(huidigNummer);
            }

            return aMissendeNummers;
        }

        /// <summary>
        /// Check een kolom met de heuristische functie ingebouwd.
        /// Returnt het aantal cijfers dat niet op de juiste plek staat.
        /// </summary>
        public int CheckKolom(int kolomIndex)
        {
            List<int> gevondenNummers = new List<int>();
            int aMissendeNummers = 0; // Het aantal missende nummers, wat gelijk is aan het aantal duplicaten.

            // De loop. Checkt een nummer om te kijken of deze al eerder is gevonden.
            // Zo ja, incrementeer de teller.
            // Zo nee, voeg het nummer toe aan de lijst.
            for (int i = 0; i < 9; i++)
            {
                int huidigNummer = vakjes[i, kolomIndex];
                if (gevondenNummers.Contains(huidigNummer))
                    aMissendeNummers++;
                else
                    gevondenNummers.Add(huidigNummer);
            }
            return aMissendeNummers;
        }
    }

}

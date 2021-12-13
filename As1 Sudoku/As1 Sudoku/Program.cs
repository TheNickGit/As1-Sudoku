using System;

namespace As1_Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            Puzzel p = new Puzzel();
            p.LaadSudoku(1);
            p.PrintPuzzel();
            Console.WriteLine("Check op eerste rij: " + p.CheckRij(0));
            Console.WriteLine("Check op eerste kolom: " + p.CheckKolom(0));

            

            Console.WriteLine();
            p.VulPuzzel();
            p.PrintPuzzel();

            for(int r = 0; r < 9; r++)
                Console.WriteLine("Check op rij " + r + ": " + p.CheckRij(r));
            for (int k = 0; k < 9; k++)
                Console.WriteLine("Check op kolom: " + k + ": " + p.CheckKolom(k));            

            Console.WriteLine("Heuristische waarde: " + p.BerekenHeuristischeWaarde());

            Console.Read();
        }
    }
}

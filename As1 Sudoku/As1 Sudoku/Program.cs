using System;

namespace As1_Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            Puzzel p = new Puzzel();
            p.VulPuzzel();
            p.PrintPuzzel();
            Console.WriteLine(p.CheckRij(0));
            Console.WriteLine(p.CheckKolom(0));
            Console.Read();
        }
    }
}

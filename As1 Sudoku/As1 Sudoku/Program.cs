﻿using System;

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
            Console.WriteLine("Check op eerste rij: " + p.CheckRij(0));
            Console.WriteLine("Check op eerste kolom: " + p.CheckKolom(0));

            Console.Read();
        }
    }
}

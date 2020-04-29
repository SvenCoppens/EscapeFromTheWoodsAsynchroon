using EscapeFromTheWoods_Asynchroon.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EscapeFromTheWoods_Asynchroon
{
    class ReportWriter
    {
        private string _reportsPath = @"D:\Programmeren Data en Bestanden\EscapeFromTheWoods\reports";
        public void WriteReport(Wood wood)
        {
            Console.WriteLine($"REPORT: started writing report for {wood.Id}");
            using (StreamWriter writer = File.CreateText(Path.Combine(_reportsPath, $"Wood {wood.Id} Log.txt")))
            {
                int treeStep = 0;
                int clearedMonkeys;
                do
                {
                    clearedMonkeys = 0;
                    foreach(Monkey monkey in wood.Monkeys)
                    {
                        if (treeStep < monkey.VisitedTrees.Count)
                            writer.WriteLine($"{monkey.Name} is in tree {monkey.VisitedTrees[treeStep].ID} at ({monkey.VisitedTrees[treeStep].X},{monkey.VisitedTrees[treeStep].Y})");
                        else
                            clearedMonkeys++;
                    }
                    treeStep++;
                } while (clearedMonkeys!=wood.Monkeys.Count);
            }
            Console.WriteLine($"REPORT: finished writing report for {wood.Id}");
        }
    }
}

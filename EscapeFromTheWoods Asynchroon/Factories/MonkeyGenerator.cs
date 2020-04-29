using EscapeFromTheWoods_Asynchroon.interfaces;
using EscapeFromTheWoods_Asynchroon.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EscapeFromTheWoods_Asynchroon.Factories
{
    class MonkeyGenerator : iMonkeyGenerator
    {
        private List<Monkey> Monkeys { get; set; }
        private Dictionary<int, string> MonkeyNames { get; set; }
        private string MonkeyPath { get; set; }
        public MonkeyGenerator()
        {
            MonkeyNames = new Dictionary<int, string>();
            MonkeyPath = @"D:\Programmeren Data en Bestanden\EscapeFromTheWoods\Monkeys.txt";
            LoadMonkeys();
        }
        private void LoadMonkeys()
        {
            Monkeys = new List<Monkey>();
            if (File.Exists(MonkeyPath))
            {
                using(StreamReader reader = File.OpenText(MonkeyPath))
                {
                    reader.ReadLine();
                    string line = null;
                    while ((line = reader.ReadLine())!=null)
                    {
                        string[] splitLine = line.Split(";");
                        MonkeyNames.Add(int.Parse(splitLine[0]), splitLine[1]);
                    }
                }
            }
            else
                throw new FileNotFoundException($"File Monkeys.txt was not found at {MonkeyPath}");
        }
        private void SaveMonkeys()
        {
            using (StreamWriter writer = File.CreateText(MonkeyPath))
            {
                writer.WriteLine("Id;Name");
                foreach(Monkey monkey in Monkeys)
                {
                    writer.WriteLine($"{monkey.Id};{monkey.Name}");
                }
            }
        }
        public List<Monkey> GenerateMonkeys(int amount)
        {
            List<Monkey> monkeyResult = new List<Monkey>();
            if (Monkeys.Count < amount)
            {
                for (int i = monkeyResult.Count; i < amount; i++)
                {
                    CreateMonkey();
                }
                SaveMonkeys();
            }
            for (int i = 0; i < amount; i++)
            {
                //create now instances of the Monkeys with the same Id and name but a seperate list of visited trees so multiple Woods can be run at the same time if ever needed.
                monkeyResult.Add(new Monkey(Monkeys[i].Id,Monkeys[i].Name));
            }
            return monkeyResult;
        }
        private void CreateMonkey()
        {
            int Id = Monkeys.Count + 1;
            if (Id < MonkeyNames.Count)
                Monkeys.Add(new Monkey(Id, MonkeyNames[Id]));
            else
                Monkeys.Add(new Monkey(Id, $"Monkey{Id}"));
        }
    }
}

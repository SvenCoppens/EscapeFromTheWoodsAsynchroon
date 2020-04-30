using EscapeFromTheWoods_Asynchroon.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EscapeFromTheWoods_Asynchroon.Models
{
    class Wood : iWood
    {
        public int Id { get; set; }
        public int maximumX { get; set; }
        public int MaximumY { get; set; }
        public List<iTree> Trees { get; set; }
        public List<iMonkey> Monkeys { get; set; }
        private int _escapedMonkeys = 0;
        public Wood(int id,int X,int Y,List<iMonkey> monkeys,List<iTree> trees)
        {
            Id = id;
            maximumX = X;
            MaximumY = Y;
            Monkeys = monkeys;
            Trees = trees;
            SetInitialPositions();
        }
        public void SetInitialPositions()
        {
            List<int> takenIndexes = new List<int>(Trees.Count);
            Random random = new Random();
            for(int i = 0; i < Monkeys.Count; i++)
            {
                int index = random.Next(Trees.Count);
                while (takenIndexes.Contains(index))
                {
                    index = random.Next(Trees.Count);
                }
                Monkeys[i].VisitedTrees = new List<iTree> { Trees[index] };
            }
        }
        public void LetTheMonkeysLoose()
        {
            Console.WriteLine($"WOOD: started calculating escape route for Wood{Id}");
            bool finished = false;
            do
            {
                finished = AdvanceOneStep();
            } while (!finished);
            Console.WriteLine($"WOOD: finished calculating escape route for Wood{Id}");
        }
        public bool AdvanceOneStep()
        {
            _escapedMonkeys = 0;
            foreach(Monkey monkey in Monkeys)
            {
                if (!monkey.Escaped)
                {
                    monkey.JumpToNextTree(this);
                }
                else
                    _escapedMonkeys++;
            }
            return _escapedMonkeys == Monkeys.Count;
        }
    }
}

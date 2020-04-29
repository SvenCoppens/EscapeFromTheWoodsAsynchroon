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
        public List<Tree> Trees { get; set; }
        public List<Monkey> Monkeys { get; set; }
        private int _escapedMonkeys = 0;
        public Wood(int id,int X,int Y,List<Monkey> monkeys,List<Tree> trees)
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
                Monkeys[i].VisitedTrees.Add(Trees[index]);
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
            foreach(Monkey monkey in Monkeys)
            {
                if (!monkey.Escaped)
                {
                    JumpToNextTree(monkey);
                }
            }
            return _escapedMonkeys == Monkeys.Count;
        }
        public void JumpToNextTree(Monkey monkey)
        {
            Tree currentTree = monkey.VisitedTrees[monkey.VisitedTrees.Count - 1];
            int currentX = currentTree.X;
            int currentY = currentTree.Y;

            List<Tree> tempTrees = Trees.Except(monkey.VisitedTrees).ToList();
            tempTrees = tempTrees.OrderBy(t => Math.Sqrt(Math.Pow(t.X - currentX, 2) + Math.Pow(t.Y - currentY, 2))).ToList();
            double distanceToBorder = (new List<Double>() { MaximumY - currentY, maximumX - currentX, currentY, currentX }).Min();

            double distanceToClosestTree = Math.Sqrt(Math.Pow(tempTrees[0].X - currentX, 2) + Math.Pow(tempTrees[0].Y - currentY, 2));
            if (distanceToBorder <= distanceToClosestTree)
            {
                _escapedMonkeys++;
                monkey.HasEscaped();
            }
            else
            {
                monkey.VisitedTrees.Add(tempTrees[0]);
            }
        }
        
    }
}

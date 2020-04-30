using EscapeFromTheWoods_Asynchroon.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EscapeFromTheWoods_Asynchroon.Models
{
    class Monkey : iMonkey
    {
        public Monkey(int id, string name)
        {
            Id = id;
            Name = name;
            VisitedTrees = new List<iTree>();
            Escaped = false;
        }
        public bool Escaped {  set; get; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<iTree> VisitedTrees { set; get; }
        public void JumpToNextTree(iWood wood)
        {
            iTree currentTree = VisitedTrees[VisitedTrees.Count-1];
            int currentX = currentTree.X;
            int currentY = currentTree.Y;

            List<iTree> tempTrees = wood.Trees.Except(VisitedTrees).ToList();
            tempTrees = tempTrees.OrderBy(t => Math.Sqrt(Math.Pow(t.X - currentX, 2) + Math.Pow(t.Y - currentY, 2))).ToList();
            double distanceToBorder = (new List<Double>() { wood.MaximumY - currentY, wood.maximumX - currentX, currentY, currentX }).Min();

            double distanceToClosestTree = Math.Sqrt(Math.Pow(tempTrees[0].X - currentX, 2) + Math.Pow(tempTrees[0].Y - currentY, 2));
            if (distanceToBorder <= distanceToClosestTree)
            {
                HasEscaped();
            }
            else
            {
                VisitedTrees.Add(tempTrees[0]);
            }
        }
        public void HasEscaped()
        {
            Escaped = true;
        }
    }
}

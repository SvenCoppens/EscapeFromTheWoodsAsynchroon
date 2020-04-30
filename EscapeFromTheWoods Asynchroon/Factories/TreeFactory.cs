using EscapeFromTheWoods_Asynchroon.interfaces;
using EscapeFromTheWoods_Asynchroon.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EscapeFromTheWoods_Asynchroon.Factories
{
    class TreeFactory : iTreeFactory
    {
        private int X { get; set; }
        private int Y { get; set; }
        public TreeFactory(int x,int y)
        {
            X = x;
            Y = y;
        }
        public List<iTree> MakeTrees(int amount,TreeTypes treetype)
        {
            switch (treetype)
            {
                case TreeTypes.Standard:
                    return MakeStandardTrees(amount);
                default:
                    return MakeStandardTrees(amount);
            }
        }
        public List<iTree> MakeStandardTrees(int amount)
        {
            List<iTree> trees = new List<iTree>();
            Dictionary<int, List<int>> doubleCheck = new Dictionary<int, List<int>>();
            for(int i = 0; i < amount; i++)
            {
                Random random = new Random();
                int x = random.Next(X);
                int y = random.Next(Y);
                Tree nextTree = new Tree(i, x, y);
                if (doubleCheck.ContainsKey(x))
                {
                    if (doubleCheck[x].Contains(y))
                    {
                        i--;
                    }
                    else
                    {
                        trees.Add(nextTree);
                        doubleCheck[x].Add(y);
                    }
                }
                else
                {
                    trees.Add(nextTree);
                    doubleCheck.Add(x, new List<int> { y });
                }
            }
            return trees;
        }
    }
}

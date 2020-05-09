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
        public List<Tree> MakeTrees(int amount,int xDimension,int yDimension)
        {
            List<Tree> trees = new List<Tree>();
            Dictionary<int, List<int>> doubleCheck = new Dictionary<int, List<int>>();
            for (int i = 0; i < amount; i++)
            {
                Random random = new Random();
                int x = random.Next(xDimension);
                int y = random.Next(yDimension);
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

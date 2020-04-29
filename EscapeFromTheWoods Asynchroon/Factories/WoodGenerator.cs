using EscapeFromTheWoods_Asynchroon.interfaces;
using EscapeFromTheWoods_Asynchroon.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EscapeFromTheWoods_Asynchroon.Factories
{
    class WoodGenerator
    {
        public iMonkeyGenerator MonkeyGenerator { get; set; }
        public iTreeFactory TreeFactory { get; set; }
        public WoodGenerator(iMonkeyGenerator monkeyGenerator)
        {
            MonkeyGenerator = monkeyGenerator;
        }
        public Wood CreateWood(int maxX,int maxY,int numberOfMonkeys, int numberOfTrees)
        {
            TreeFactory = new TreeFactory(maxX, maxY);
            int iD = IdGenerator.GetNextId();
            List<Monkey> monkeys = FillWithMonkeys(numberOfMonkeys);
            List<Tree> trees = FillWithTrees(numberOfTrees);
            Wood wood = new Wood(iD, maxX, maxY,monkeys,trees);
            return wood;
        }
        public List<Monkey> FillWithMonkeys(int amount)
        {
            return MonkeyGenerator.GenerateMonkeys(amount);
        }
        public List<Tree> FillWithTrees(int amount)
        {
            return TreeFactory.MakeTrees(amount);
        }
        
    }
}
